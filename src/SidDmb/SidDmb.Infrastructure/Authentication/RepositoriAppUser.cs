using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.Authentication;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.Authentication;

internal class RepositoriAppUser : IRepositoriAppUser
{
    private readonly AppDbContext _appDbContext;

    public RepositoriAppUser(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AppUser?> Get(int id) => await _appDbContext.AppUser
        .Include(x => x.Kolaborator)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<AppUser>> GetAll() => await _appDbContext.AppUser
        .Include(x => x.Kolaborator)
        .ToListAsync();

    public async Task<AppUser?> GetByUserName(string userName) => await _appDbContext.AppUser
        .Include(x => x.Kolaborator)
        .FirstOrDefaultAsync(x => x.UserName == userName);
}