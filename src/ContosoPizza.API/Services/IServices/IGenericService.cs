using System.Collections.Generic;

namespace ContosoPizza.API.Services.IServices;

public interface IGenericService<T>
{
    T Add(T obj);
    void Delete(int id);
    bool Exists(int id);
    IEnumerable<T> Get();
    T Get(int id);
    void Update(int id, T obj);
}
