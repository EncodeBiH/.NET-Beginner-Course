namespace UserManager.BusinessLogic;

public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _context;

    public BaseService(ApplicationDbContext context)
    {
        _context = context;
    }


    public virtual void Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);

        _context.SaveChanges();
    }
}
