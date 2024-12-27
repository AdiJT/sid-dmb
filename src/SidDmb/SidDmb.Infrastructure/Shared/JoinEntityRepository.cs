using SidDmb.Domain.Abstracts;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.Shared;

internal class JoinEntityRepository<TJoinEntity> : IJoinEntityRepository<TJoinEntity>
    where TJoinEntity : class
{
    private readonly AppDbContext _appDbContext;

    public JoinEntityRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public void Add(TJoinEntity entity) => _appDbContext.Set<TJoinEntity>().Add(entity);

    public void Update(TJoinEntity entity) => _appDbContext.Set<TJoinEntity>().Update(entity);

    public void Delete(TJoinEntity entity) => _appDbContext.Set<TJoinEntity>().Remove(entity);
}