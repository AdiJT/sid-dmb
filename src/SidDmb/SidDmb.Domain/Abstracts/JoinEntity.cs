namespace SidDmb.Domain.Abstracts;

public abstract class JoinEntity<TEntity1, TEntity2, T1, T2> : IEquatable<JoinEntity<TEntity1, TEntity2, T1, T2>>
    where T1 : IEquatable<T1>
    where T2 : IEquatable<T2>
    where TEntity1 : Entity<T1>
    where TEntity2 : Entity<T2>
{
    public required T1 Entity1Id { get; set; }
    public required T2 Entity2Id { get; set; }

    public required TEntity1 Entity1 { get; set; }
    public required TEntity2 Entity2 { get; set; }

    public bool Equals(JoinEntity<TEntity1, TEntity2, T1, T2>? other) => 
        other is not null && 
        other.GetType() == GetType() && 
        other.Entity1 == Entity1 && 
        other.Entity2 == Entity2;

    public override bool Equals(object? obj) =>
        obj is not null &&
        obj is JoinEntity<TEntity1, TEntity2, T1, T2> other &&
        other.GetType() == GetType() &&
        other.Entity1 == Entity1 &&
        other.Entity2 == Entity2;

    public override int GetHashCode() => HashCode.Combine(Entity1, Entity2);

    public static bool operator==(JoinEntity<TEntity1, TEntity2, T1, T2>? left, JoinEntity<TEntity1, TEntity2, T1, T2>? right) =>
        left is not null &&
        left.Equals(right);

    public static bool operator !=(JoinEntity<TEntity1, TEntity2, T1, T2>? left, JoinEntity<TEntity1, TEntity2, T1, T2>? right) => !(left == right);
}