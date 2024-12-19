namespace SidDmb.Domain.Abstracts;

public abstract class Entity<T> : IEquatable<Entity<T>>
    where T : IEquatable<T>
{
    public required T Id { get; set; }

    public override bool Equals(object? obj) =>
        obj is not null && obj is Entity<T> other && 
        other.GetType() == GetType() && 
        other.Id.Equals(Id);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(Entity<T>? other) => other is not null && other.GetType() == GetType() && other.Id.Equals(Id);

    public static bool operator==(Entity<T>? left, Entity<T>? right) => left is not null && left.Equals(right);
    public static bool operator!=(Entity<T>? left, Entity<T>? right) => !(left == right);
}