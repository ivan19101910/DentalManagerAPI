namespace DentalManagerAPI.DAL
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
