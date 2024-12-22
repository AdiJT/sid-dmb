namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent;

public interface IRepostoriPelaporanEvent
{
    Task<LaporanEvent?> Get(IdLaporanEvent id);
    Task<List<LaporanEvent>> GetAll();

    void Add(LaporanEvent pelaporanEvent);
    void Update(LaporanEvent pelaporanEvent);
    void Delete(LaporanEvent pelaporanEvent);
}