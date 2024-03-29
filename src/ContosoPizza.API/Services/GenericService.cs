using System.Linq;
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;

using ContosoPizza.API.Data;
using ContosoPizza.API.Models;
using ContosoPizza.API.Services.IServices;

namespace ContosoPizza.API.Services;

public class GenericService<T> : IGenericService<T> where T : BaseModel
{
    private readonly DbContext _dbContext;

    private readonly DbSet<T> _dbSet;

    public GenericService(DatabaseContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public T Add(T obj)
    {
        _dbSet.Add(obj);
        _dbContext.SaveChanges();
        return obj;
    }

    public void Delete(int id)
    {
        T obj = _dbSet.First(obj => obj.Id == id);
        _dbSet.Remove(obj);
        _dbContext.SaveChanges();
    }

    public bool Exists(int id)
    {
        if (_dbSet.FirstOrDefault(obj => obj.Id == id) is null)
            return false;
        return true;
    }

    public IEnumerable<T> Get()
    {
        return _dbSet
                .AsNoTracking()
                .ToList();
    }

    public T Get(int id)
    {
        return _dbSet
                .AsNoTracking()
                .First(obj => obj.Id == id);
    }

    public void Update(int id, T newObj)
    {
        T existingObj = _dbSet.Single(obj => obj.Id == id);
        _dbSet.Entry(existingObj).CurrentValues.SetValues(newObj);
        _dbContext.SaveChanges();
    }
}
