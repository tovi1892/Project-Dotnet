

namespace NewFolder
{
    interface ICrudcs
    {
        int Creat(T item);
        T? Read(int id);
        List<T> ReadAll();
        void Update(testc item);
        void Delete(int id);
    }
}
