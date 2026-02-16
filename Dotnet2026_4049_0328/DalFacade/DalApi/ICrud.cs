

namespace DalApi;

 public interface ICrud<T>
{
    int Create(T item);
    //T Read(int id);
    T? Read(Func<T, bool> filter); 
    List<T?> ReadAll(Func<T, bool>? filter = null); 
    void Delete(int id);
    void Update(T item);
}
