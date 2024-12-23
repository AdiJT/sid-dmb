using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class RepositoriAktivitasDestinasiWisata : IRepositoriAktivitasDestinasiWisata
{
    private readonly AppDbContext _appDbContext;

    public RepositoriAktivitasDestinasiWisata(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<AktivitasDestinasiWisata?> Get(int id) => await _appDbContext.AktivitasDestinasiWisata
        .Include(x => x.DaftarDestinasiWisata)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<AktivitasDestinasiWisata>> GetAll() => await _appDbContext.AktivitasDestinasiWisata
        .Include(x => x.DaftarDestinasiWisata)
        .ToListAsync();

    public void Add(AktivitasDestinasiWisata aktivitasDestinasiWisata) => _appDbContext.AktivitasDestinasiWisata.Add(aktivitasDestinasiWisata);

    public void Update(AktivitasDestinasiWisata aktivitasDestinasiWisata) => _appDbContext.AktivitasDestinasiWisata.Update(aktivitasDestinasiWisata);

    public void Delete(AktivitasDestinasiWisata aktivitasDestinasiWisata) => _appDbContext.AktivitasDestinasiWisata.Remove(aktivitasDestinasiWisata);
}
