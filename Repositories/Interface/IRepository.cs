namespace WebApplication1.Repositories.Interface
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();

        public T? Get(int id);

        public T Insert(T entity);
    }
}
