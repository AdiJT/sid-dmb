namespace SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.RekomendasiDanPengembanganProduk;

public interface IRepositoriRekomendasi
{
    Task<Rekomendasi?> Get(IdRekomendasi id);
    Task<List<Rekomendasi>> GetAll();

    void Add(Rekomendasi rekomendasi);
    void Update(Rekomendasi rekomendasi);
    void Delete(Rekomendasi rekomendasi);
}