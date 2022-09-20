namespace MyFirstWebApp.Services
{
    public interface IRepo<K,T>
    {
        Task<T> Add(T item);
        Task<T> Get(K key);
        Task<ICollection<T>> GetAll();
        Task<T> Update(T item);
        Task<T> Delete(K key);

    }
}
