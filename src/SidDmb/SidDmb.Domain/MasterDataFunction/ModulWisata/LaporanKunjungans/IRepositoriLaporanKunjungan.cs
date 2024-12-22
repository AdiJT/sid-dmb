namespace SidDmb.Domain.MasterDataFunction.ModulWisata.LaporanKunjungans;

public interface IRepositoriLaporanKunjungan
{
    Task<LaporanKunjungan?> Get(IdKunjungan id);
    Task<List<LaporanKunjungan>> GetAll();

    void Add(LaporanKunjungan laporanKunjungan);
    void Update(LaporanKunjungan laporanKunjungan);
    void Delete(LaporanKunjungan laporanKunjungan);
}