using CellPhoneS.Data;
using CellPhoneS.Interfaces;

namespace CellPhoneS.Common;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext dbContext;

    protected BaseRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public virtual bool Create(TEntity entity)
    {
        this.dbContext.Set<TEntity>().Add(entity);
        var rows = this.dbContext.SaveChanges();
        if (rows <= 0)
        {
            return false;
        }

        return true;
    }

    public virtual bool DeleteById(int id)
    {
        var deleteEntity = this.dbContext.Set<TEntity>().Find(id);
        if (deleteEntity == null)
        {
            return false;
        }


        this.dbContext.Set<TEntity>().Remove(deleteEntity);
        var rows = this.dbContext.SaveChanges();
        if (rows <= 0)
        {
            return false;
        }

        return true;
    }

    public virtual List<TEntity> FindAll()
    {
        return this.dbContext.Set<TEntity>().ToList();
    }

    public virtual TEntity FindById(int id)
    {
        return this.dbContext.Set<TEntity>().Find(id);
    }

    public virtual bool Update(TEntity entity)
    {
        this.dbContext.Set<TEntity>().Update(entity);
        var rows = this.dbContext.SaveChanges();
        if (rows <= 0)
        {
            return false;
        }

        return true;
    }
}