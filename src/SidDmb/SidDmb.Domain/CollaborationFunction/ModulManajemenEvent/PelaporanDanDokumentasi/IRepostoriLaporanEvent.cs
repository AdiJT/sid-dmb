namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PelaporanDanDokumentasi;

public interface IRepostoriLaporanEvent
{
    Task<LaporanEvent?> Get(IdLaporanEvent id);
    Task<List<LaporanEvent>> GetAll();

    void Add(LaporanEvent laporanEvent);
    void Update(LaporanEvent laporanEvent);
    void Delete(LaporanEvent laporanEvent);
}