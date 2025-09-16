namespace Core
{
    public interface ISingleKeyRepository<T>:IRepository<T> 
    {
        public T GetById(int id);
        public void Delete(int id);

    }
}
