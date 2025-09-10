namespace Core
{
    public interface ISingleKeyRepository<T> where T : class
    {
        public T GetById(int id);
        public void Delete(int id);

    }
}
