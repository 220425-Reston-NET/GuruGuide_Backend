namespace GuruGuideDL
{
    public interface IRepository<T>
    {
        void Add(T g_resource);

        List<T> GetAll();

        void Update(T g_resource);
    }
}