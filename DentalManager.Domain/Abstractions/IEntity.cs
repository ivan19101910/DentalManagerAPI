namespace DentalManager.Domain;

public interface IEntity<T>
{
    T Id { get; set; }
}
