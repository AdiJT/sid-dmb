using Microsoft.EntityFrameworkCore;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;
using SidDmb.Infrastructure.Database;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulPelatihanEdukasi.MateriEdukasiDanPembelajaran;

internal class RepositoriMateri : IRepositoriMateri
{
    private readonly AppDbContext _appDbContext;

    public RepositoriMateri(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Materi?> Get(IdMateri id) => await _appDbContext.Materi
        .Include(x => x.DaftarKolaborator)
        .FirstOrDefaultAsync(x => x.Id == id);

    public async Task<List<Materi>> GetAll() => await _appDbContext.Materi
        .Include(x => x.DaftarKolaborator)
        .ToListAsync();

    public void Add(Materi materiEdukasiDanPembelajaran) => _appDbContext.Materi.Add(materiEdukasiDanPembelajaran);

    public void Update(Materi materiEdukasiDanPembelajaran) => _appDbContext.Materi.Update(materiEdukasiDanPembelajaran);

    public void Delete(Materi materiEdukasiDanPembelajaran) => _appDbContext.Materi.Remove(materiEdukasiDanPembelajaran);
}