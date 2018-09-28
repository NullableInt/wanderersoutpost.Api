using System;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace dndChar.Api.Util
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OperationAttribute : Attribute, IActionConstraint
    {
        private readonly string _actionName;

        public OperationAttribute(string actionName)
        {
            _actionName = actionName;
        }

        public int Order { get; set; }

        public string ActionName => _actionName;

        public bool Accept(ActionConstraintContext context)
        {
            return RequiredJsonContentAttribute.IsValidForRequest(context.RouteContext.HttpContext.Request.EnableRewind(), "type", _actionName);
        }
    }
}