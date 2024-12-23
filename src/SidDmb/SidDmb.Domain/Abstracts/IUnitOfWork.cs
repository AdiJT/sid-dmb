using SidDmb.Domain.Shared;

namespace SidDmb.Domain.Abstracts;

public interface IUnitOfWork
{
    Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default);
}
