using SidDmb.Domain.Abstracts;
using SidDmb.Domain.CollaborationFunction.ModulManajemenEvent;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenLaporanEvent;

public class PelaporanEvent : Entity<IdLaporanEvent>, IAuditableEntity
{
    public required DateOnly TanggalPelaporan { get; set; }
    public required double PengeluaranEvent { get; set; }
    public required string UlasanSingkatEvent { get; set; }
    public required string FeedbackPeserta { get; set; }
    public required Uri FotoDokumentasi { get; set; }
    public required Uri VideoDokumentasi { get; set; }
    public required Uri LaporanDetail { get; set; }
    public required string MasukanKolaborator { get; set; }
    public required string RekomendasiUntukEventBerikutnya { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public Event Event { get; set; }
}

public class IdLaporanEvent : ValueObject, IEquatable<IdLaporanEvent>
{
    public const string ValidPattern = "^LE[0-9]{3}$";

    public string Value { get; set; }

    private IdLaporanEvent(string value)
    {
        Value = value;
    }

    public bool Equals(IdLaporanEvent? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdLaporanEvent> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdLaporanEvent.TidakValid", "Id valid dimulai oleh LE dan diikuti 3 angka. Contoh LE001");

        return new IdLaporanEvent(value);
    }

    public static async Task<IdLaporanEvent> Generate(IRepostoriLaporanEvent repostoriLaporanEvent)
    {
        var newId = (await repostoriLaporanEvent.GetAll())
            .Select(e => int.Parse(e.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"LE{newId:D3}");
    }
}

public interface IRepostoriLaporanEvent
{
    Task<PelaporanEvent?> Get(IdLaporanEvent id);
    Task<List<PelaporanEvent>> GetAll();

    void Add(PelaporanEvent pelaporanEvent);
    void Update(PelaporanEvent pelaporanEvent);
    void Delete(PelaporanEvent pelaporanEvent);
}