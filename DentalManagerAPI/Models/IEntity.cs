﻿namespace DentalManagerAPI.Models
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
