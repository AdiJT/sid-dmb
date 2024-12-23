using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;

namespace SidDmb.Infrastructure.Database;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly ILogger<UnitOfWork> _logger;

    public UnitOfWork(AppDbContext appDbContext, ILogger<UnitOfWork> logger)
    {
        _appDbContext = appDbContext;
        _logger = logger;
    }

    public async Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            UpdateAuditableEntity();
            await _appDbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception occured when try to save changes to storage");

            return new Error(
                "IUnitOfWork.SaveChangesAsyncGagal",
                $"Penyimpanan ke database gagal karena kesalahan tidak terduga (Exception : {ex.Message})");
        }
    }

    public void UpdateAuditableEntity()
    {
        var entities = _appDbContext.ChangeTracker.Entries<IAuditableEntity>().ToList();

        foreach (var entity in entities.Where(e => e.State == EntityState.Added))
        {
            entity.Entity.TanggalDiinputkan = DateTime.Now;
            entity.Entity.TanggalPembaruanData = entity.Entity.TanggalDiinputkan;
        }

        foreach (var entity in entities.Where(e => e.State == EntityState.Modified))
            entity.Entity.TanggalPembaruanData = DateTime.Now;
    }
}
