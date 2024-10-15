namespace APIFilmeStudy.Repository;
public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAsync();
    Task<T> GetByIdAsync(int id);
    T GetById(int id);
    void Commit();
    bool Create(T model);
    bool Update(T model);
    bool Delete(T model);
}

