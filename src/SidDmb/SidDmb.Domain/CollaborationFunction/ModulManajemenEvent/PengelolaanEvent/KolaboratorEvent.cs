using SidDmb.Domain.Abstracts;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

public class KolaboratorEvent : JoinEntity<Event, Kolaborator, IdEvent, int>
{
    public string MasukanKolaborator { get; set; } = string.Empty;
    public string RekomedasiEventBerikutnya { get; set; } = string.Empty;
}