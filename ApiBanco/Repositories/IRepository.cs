namespace ApiBanco.Repositories
{
    public interface IRepository<T> where T : class
    {
        void Delete(T item);
        T? Get(object id);
        IEnumerable<T> GetAll();
        void Insert(T item);
        void Update(T item);
    }
}