using System;
using System.IO;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Newtonsoft.Json;

namespace dndChar.Api.Util
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class RequiredJsonContentAttribute : Attribute, IActionConstraint
    {
        public RequiredJsonContentAttribute(string contentKey, string contentValue)
        {
            ContentKey = contentKey;
            ContentValue = contentValue;
        }

        public string ContentKey { get; }

        public string ContentValue { get; }

        public int Order { get; set; }

        public static bool IsValidForRequest(HttpRequest request, string contentKey, string contentValue)
        {
            if (string.IsNullOrEmpty(contentValue))
                return true;

            if (!Regex.IsMatch(contentKey, @"^[a-z][A-za-z]|^([a-z][A-za-z]+\.)[a-z][A-za-z]+$"))
                return false;

            return IsValidForBody(request, contentKey, contentValue);
        }

        private static bool IsValidForBody(HttpRequest request, string contentKey, string contentValue)
        {
            string value = null;
            if ((request.ContentLength == null || request.ContentLength > 0)
                && request.ContentType != null
                && MediaTypeHeaderValue.TryParse(request.ContentType, out var contentType)
                && contentType.MediaType.Equals("application/json", StringComparison.OrdinalIgnoreCase))
            {
                var sr = new StreamReader(request.Body);
                request.HttpContext.Response.RegisterForDispose(sr);
                var jr = new JsonTextReader(sr);
                request.HttpContext.Response.RegisterForDispose(jr);
                dynamic content = new JsonSerializer().Deserialize(jr);
                request.Body.Seek(0L, SeekOrigin.Begin);

                try
                {
                    var contentKeyParts = contentKey.Split('.');
                    int contentKeyPartCount = contentKeyParts.Length;
                    foreach (var contentKeyPart in contentKeyParts)
                    {
                        if (string.IsNullOrWhiteSpace(content.ToString()) && string.IsNullOrWhiteSpace(request.Path))
                            value = "initiate";

                        content = content[contentKeyPart] ?? content[char.ToUpper(contentKeyPart[0]) + contentKeyPart.Substring(1)];
                        if (content == null)
                            break;

                        if (--contentKeyPartCount == 0)
                            value = content.ToString();
                    }
                }
                catch
                {
                    // Ignore
                }
            }
            else if ((request.Path.HasValue && request.Path == "/") || string.IsNullOrWhiteSpace(request.Path))
            {
                // Empty body defaults to initiate if posted to root.
                value = "initiate";
            }

            return string.Compare(contentValue, value, StringComparison.OrdinalIgnoreCase) == 0;
        }

        public bool Accept(ActionConstraintContext context)
        {
            return IsValidForRequest(context.RouteContext.HttpContext.Request.EnableRewind(), ContentKey, ContentValue);
        }
    }
}