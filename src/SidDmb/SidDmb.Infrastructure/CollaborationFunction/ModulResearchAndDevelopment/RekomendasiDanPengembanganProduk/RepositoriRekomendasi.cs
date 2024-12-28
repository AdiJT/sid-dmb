using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

internal class RepositoriRekomendasi : IRepositoriRekomendasi
{
    private readonly AppDbContext _appDbContext;

    public RepositoriRekomendasi(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Rekomendasi?> Get(IdRekomendasi id) => await _appDbContext.Rekomendasi
        .Include(x => x.DaftarKolaborator)
        .Include(x => x.DaftarKolaboratorRekomendasi)
        .Include(x => x.ProdukTerkait)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Rekomendasi>> GetAll() => await _appDbContext.Rekomendasi
        .Include(x => x.DaftarKolaborator)
        .Include(x => x.DaftarKolaboratorRekomendasi)
        .Include(x => x.ProdukTerkait)
        .ToListAsync();

    public void Add(Rekomendasi rekomendasi) => _appDbContext.Rekomendasi.Add(rekomendasi);

    public void Update(Rekomendasi rekomendasi) => _appDbContext.Rekomendasi.Update(rekomendasi);

    public void Delete(Rekomendasi rekomendasi) => _appDbContext.Rekomendasi.Remove(rekomendasi);
}