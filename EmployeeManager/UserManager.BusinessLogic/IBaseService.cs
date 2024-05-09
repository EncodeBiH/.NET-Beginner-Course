namespace UserManager.BusinessLogic;

public interface IBaseService<TEntity> where TEntity : class
{
    void Create(TEntity entity);
}
