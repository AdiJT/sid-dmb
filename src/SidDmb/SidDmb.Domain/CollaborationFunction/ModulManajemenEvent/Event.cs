using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent;

public class Event : Entity<IdEvent>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required DateTime TanggalWaktu { get; set; }
    public required string Lokasi { get; set; }
    public required string Penyelenggara { get; set; }
    public required string KontakInformasi { get; set; }
    public required TargetPeserta TargetPeserta { get; set; }
    public required int JumlahPesertaMaksimal { get; set; }
    public required StatusPendaftaran StatusPendaftaran { get; set; }
    public required string Sponsor { get; set; }
    public required double Anggaran { get; set; }
    public required double Pendapatan { get; set; }
    public required string[] Kolaborator { get; set; }
    public required Uri MediaPromosi { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}

public enum KategoriEvent
{
    Budaya, Olahraga, Edukasi, Lainnya
}

public enum TargetPeserta
{
    Umum, Pelajar, Keluarga, Lainnya
}

public enum StatusPendaftaran
{
    Buka, Penuh, Tutup
}

public class IdEvent : ValueObject, IEquatable<IdEvent>
{
    public const string ValidPattern = "^EV[0-9]{3}$";

    public string Value { get; set; }

    private IdEvent(string value)
    {
        Value = value;
    }

    public bool Equals(IdEvent? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdEvent> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdEvent.TidakValid", "Id valid dimulai oleh EV dan diikuti 3 angka. Contoh EV001");

        return new IdEvent(value);
    }

    public static async Task<IdEvent> Generate(IRepostoriEvent repostoriEvent)
    {
        var newId = (await repostoriEvent.GetAll())
            .Select(e => int.Parse(e.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"EV{newId:D3}");
    }
}

public interface IRepostoriEvent
{
    Task<Event?> Get(IdEvent id);
    Task<List<Event>> GetAll();

    void Add(Event @event);
    void Update(Event @event);
    void Delete(Event @event);
}