using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

internal class RepositoriSertifikasi : IRepositoriSertifikasi
{
    private readonly AppDbContext _appDbContext;

    public RepositoriSertifikasi(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Sertifikasi?> Get(IdSertifikasi id) => await _appDbContext.Sertifikasi
        .Include(x => x.Produk).ThenInclude(p => p.DaftarKolaborator)
        .Include(x => x.DaftarKolaborator)
        .Include(x => x.DaftarKolaboratorSertifikasi)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Sertifikasi>> GetAll() => await _appDbContext.Sertifikasi
        .Include(x => x.Produk).ThenInclude(p => p.DaftarKolaborator)
        .Include(x => x.DaftarKolaborator)
        .Include(x => x.DaftarKolaboratorSertifikasi)
        .ToListAsync();

    public void Add(Sertifikasi sertifikasi) => _appDbContext.Add(sertifikasi);

    public void Update(Sertifikasi sertifikasi) => _appDbContext.Update(sertifikasi);

    public void Delete(Sertifikasi sertifikasi) => _appDbContext.Remove(sertifikasi);
}