namespace SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

public interface IRepositoriDestinasiWisata
{
    Task<DestinasiWisata?> Get(IdDestinasi id);
    Task<List<DestinasiWisata>> GetAll();

    void Add(DestinasiWisata destinasi);
    void Update(DestinasiWisata destinasi);
    void Delete(DestinasiWisata destinasi);
}
