using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManager.BusinessLogic;

namespace UserManager.Web.Services;

public class SelectListService : ISelectListService
{
    private readonly ApplicationDbContext _context;

    public SelectListService
    (
        ApplicationDbContext context
    )
    {
        _context = context;
    }

    public List<SelectListItem> GetDepartments()
    {
        return _context
            .Departments
            .AsNoTracking()
            .Select(x => new SelectListItem(x.Code, x.Id.ToString()))
            .ToList();
    }
}
