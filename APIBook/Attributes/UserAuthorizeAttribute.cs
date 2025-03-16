using APIBook.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace APIBook.Attributes
{
	public class UserAuthorizeAttribute : Attribute, IAsyncActionFilter
	{
		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
			var allowAnonymous = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(typeof(AllowAnonymousAttribute), false).Any();
			if (allowAnonymous)
			{
				await next();
			}
			else
			{
				var isCheckPermission = (context.ActionDescriptor as ControllerActionDescriptor).MethodInfo.GetCustomAttributes(typeof(PermissionDescriptionAttribute), false).Any();
				if (isCheckPermission)
				{
					var controllerName = context.ActionDescriptor.RouteValues["controller"].ToString();
					var actionName = context.ActionDescriptor.RouteValues["action"].ToString();

					var userClaim = context.HttpContext.User.Claims.FirstOrDefault(n => n.Type == ClaimTypes.NameIdentifier);
					if (userClaim != null)
					{
						var userId = new Guid(userClaim.Value);
						var permissionService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
						var user = await permissionService.GetUserFromCache(userId);
						if (user.IsAdmin.HasValue && user.IsAdmin.Value)
						{
							await next();
						}
						else
						{
							if (user.UserPermissions.Contains($"{controllerName}-{actionName}"))
								await next();
							else
								context.Result = new ContentResult()
								{
									StatusCode = StatusCodes.Status403Forbidden,
									ContentType = "application/json",
									Content = "Bạn không có quyền thực hiện hành động này !"
								};
						}
						

					}
				}
				else await next();
			}
		}
	}
}
