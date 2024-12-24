namespace SidDmb.Domain.Authentication;

public interface IRepositoriAppUser
{
    Task<AppUser?> Get(int id);
    Task<AppUser?> GetByUserName(string userName);
    Task<List<AppUser>> GetAll();
}