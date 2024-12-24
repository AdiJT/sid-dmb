using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.DestinasiWisatas;

internal class RepositoriDestinasiWisata : IRepositoriDestinasiWisata
{
    private readonly AppDbContext _appDbContext;

    public RepositoriDestinasiWisata(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<DestinasiWisata?> Get(IdDestinasi id) => await _appDbContext.DestinasiWisata
        .Include(x => x.DaftarLaporanKunjungan)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<DestinasiWisata>> GetAll() => await _appDbContext.DestinasiWisata
        .Include(x => x.DaftarLaporanKunjungan)
        .ToListAsync();

    public void Add(DestinasiWisata destinasi) => _appDbContext.DestinasiWisata.Add(destinasi);

    public void Update(DestinasiWisata destinasi) => _appDbContext.DestinasiWisata.Update(destinasi);

    public void Delete(DestinasiWisata destinasi) => _appDbContext.DestinasiWisata.Remove(destinasi);
}
