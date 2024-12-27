using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulManajemenEvent.PengelolaanEvent;

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

    public static async Task<IdEvent> Generate(IRepositoriEvent repostoriEvent)
    {
        var newId = (await repostoriEvent.GetAll())
            .Select(e => int.Parse(e.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"EV{newId:D3}");
    }
}
