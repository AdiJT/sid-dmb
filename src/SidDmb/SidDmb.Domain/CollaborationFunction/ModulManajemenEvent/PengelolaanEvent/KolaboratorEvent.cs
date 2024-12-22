using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

public class KolaboratorEvent : Entity<int>
{
    public required string Nama { get; set; }

    public List<Event> DaftarEvent { get; set; } = [];
}
