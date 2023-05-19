namespace API.Data
{
    public interface IRepository<T>
    {
        public Task<T> Create(T m);
        public Task<T> Get(int Id);
        public Task<IAsyncEnumerable<T>> GetAll();
        public Task<T> Update(T m);
        public Task<T> Delete(T m);
    }
}