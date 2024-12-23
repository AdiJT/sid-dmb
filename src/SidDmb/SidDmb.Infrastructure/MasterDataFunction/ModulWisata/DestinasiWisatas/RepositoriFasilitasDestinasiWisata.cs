using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class RepositoriFasilitasDestinasiWisata : IRepositoriFasilitasDestinasiWisata
{
    private readonly AppDbContext _appDbContext;

    public RepositoriFasilitasDestinasiWisata(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<FasilitasDestinasiWisata?> Get(int id) => await _appDbContext.FasilitasDestinasiWisata
        .Include(x => x.DaftarDestinasiWisata)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<FasilitasDestinasiWisata>> GetAll() => await _appDbContext.FasilitasDestinasiWisata
        .Include(x => x.DaftarDestinasiWisata)
        .ToListAsync();

    public void Add(FasilitasDestinasiWisata fasilitasDestinasiWisata) => _appDbContext.FasilitasDestinasiWisata.Add(fasilitasDestinasiWisata);

    public void Update(FasilitasDestinasiWisata fasilitasDestinasiWisata) => _appDbContext.FasilitasDestinasiWisata.Update(fasilitasDestinasiWisata);

    public void Delete(FasilitasDestinasiWisata fasilitasDestinasiWisata) => _appDbContext.FasilitasDestinasiWisata.Remove(fasilitasDestinasiWisata);
}