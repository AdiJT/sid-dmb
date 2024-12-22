namespace SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

public interface IRepositoriFasilitasDestinasiWisata
{
    Task<FasilitasDestinasiWisata?> Get(int id);
    Task<List<FasilitasDestinasiWisata>> GetAll();

    void Add(FasilitasDestinasiWisata fasilitas);
    void Update(FasilitasDestinasiWisata fasilitas);
    void Delete(FasilitasDestinasiWisata fasilitas);
}
