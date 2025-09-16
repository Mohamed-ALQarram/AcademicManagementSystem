namespace Core
{
    public interface ICompositeKeyRepository<T, Tkey> : IRepository<T> where T : class
    {
        public T? GetById(Tkey key);
        public void Delete(Tkey key);

    }
}
