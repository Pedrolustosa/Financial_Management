namespace Domain.Interfaces.Generics
{
    public interface IGeneric<T> where T : class
    {
        Task Add(T Item);

        Task Update(T Item);

        Task Delete(T Item);

        Task<T?> GetEntityById(int Id);

        Task<List<T>> List();
    }
}
