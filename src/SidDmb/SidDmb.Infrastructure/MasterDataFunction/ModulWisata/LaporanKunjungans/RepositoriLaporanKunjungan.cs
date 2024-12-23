using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulWisata.LaporanKunjungans;

internal class RepositoriLaporanKunjungan : IRepositoriLaporanKunjungan
{
    private readonly AppDbContext _appDbContext;

    public RepositoriLaporanKunjungan(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<LaporanKunjungan?> Get(IdKunjungan id) => await _appDbContext.LaporanKunjungan
        .Include(x => x.DestinasiWisata).ThenInclude(d => d.DaftarAktivitas)
        .Include(x => x.DestinasiWisata).ThenInclude(d => d.DaftarFasilitas)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<LaporanKunjungan>> GetAll() => await _appDbContext.LaporanKunjungan
        .Include(x => x.DestinasiWisata).ThenInclude(d => d.DaftarAktivitas)
        .Include(x => x.DestinasiWisata).ThenInclude(d => d.DaftarFasilitas)
        .ToListAsync();

    public void Add(LaporanKunjungan laporanKunjungan) => _appDbContext.LaporanKunjungan.Add(laporanKunjungan);

    public void Update(LaporanKunjungan laporanKunjungan) => _appDbContext.LaporanKunjungan.Update(laporanKunjungan);

    public void Delete(LaporanKunjungan laporanKunjungan) => _appDbContext.LaporanKunjungan.Remove(laporanKunjungan);
}