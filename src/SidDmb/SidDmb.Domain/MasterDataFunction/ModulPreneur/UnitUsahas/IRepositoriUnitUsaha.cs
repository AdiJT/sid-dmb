namespace SidDmb.Domain.MasterDataFunction.ModulPreneur.UnitUsahas;

public interface IRepositoriUnitUsaha
{
    Task<UnitUsaha?> Get(IdUnitUsaha id);
    Task<List<UnitUsaha>> GetAll();

    void Add(UnitUsaha unitUsaha);
    void Update(UnitUsaha unitUsaha);
    void Delete(UnitUsaha unitUsaha);
}