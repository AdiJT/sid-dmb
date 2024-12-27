namespace SidDmb.Domain.Abstracts;

public interface IJoinEntityRepository<TJoinEntity>
    where TJoinEntity : class
{
    void Add(TJoinEntity entity);
    void Update(TJoinEntity entity);
    void Delete(TJoinEntity entity);
}