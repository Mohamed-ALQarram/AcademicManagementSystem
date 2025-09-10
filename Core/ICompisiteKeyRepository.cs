namespace Core
{
    public interface ICompisiteKeyRepository<T, Tkey> where T : class
    {
        public T GetById(Tkey key);
        public void Delete(Tkey key);

    }
}
