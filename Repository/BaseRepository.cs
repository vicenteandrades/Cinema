
using APIFilmeStudy.Context;
using Microsoft.EntityFrameworkCore;

namespace APIFilmeStudy.Repository;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public BaseRepository(FilmeContext context)
    {
        _context = context;
    }

    protected FilmeContext _context { get; set; }
    public async Task<IEnumerable<T>> GetAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }
    public bool Create(T model)
    {
        if (model is not null) 
        {
            _context.Set<T>().Add(model);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
    public bool Update(T model)
    {
        if (model is not null)
        {
            _context.Set<T>().Update(model);
            _context.SaveChanges();
            return true;
        }

        return false;
    }
    public bool Delete(T model)
    {
        if (model is not null)
        {
            _context.Set<T>().Remove(model);
            _context.SaveChanges();
            return true;
        }

        return false;
    }


}

