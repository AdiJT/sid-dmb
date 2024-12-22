namespace SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

public interface IRepositoriAktivitasDestinasiWisata
{
    Task<AktivitasDestinasiWisata?> Get(int id);
    Task<List<AktivitasDestinasiWisata>> GetAll();

    void Add(AktivitasDestinasiWisata fasilitas);
    void Update(AktivitasDestinasiWisata fasilitas);
    void Delete(AktivitasDestinasiWisata fasilitas);
}