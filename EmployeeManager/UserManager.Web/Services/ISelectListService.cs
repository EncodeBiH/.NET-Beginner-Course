using Microsoft.AspNetCore.Mvc.Rendering;

namespace UserManager.Web.Services;

public interface ISelectListService
{
    List<SelectListItem> GetDepartments();
}