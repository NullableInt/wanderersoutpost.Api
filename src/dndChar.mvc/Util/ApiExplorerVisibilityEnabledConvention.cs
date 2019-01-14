using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace dndChar.Api.Util
{
    public class ApiExplorerVisibilityEnabledConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                if (controller.ApiExplorer.IsVisible != null) continue;
                controller.ApiExplorer.IsVisible = true;
                controller.ApiExplorer.GroupName = controller.ControllerName;
            }
        }
    }
}
