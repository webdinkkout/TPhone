namespace CellPhoneS.Interfaces;

public interface IBaseService<TEntity>
{
    public List<TEntity> FindAll();
    public TEntity FindById(int id);
    public bool Create(TEntity entity);
    public bool Update(TEntity entity);
    public bool DeleteById(int id);
}