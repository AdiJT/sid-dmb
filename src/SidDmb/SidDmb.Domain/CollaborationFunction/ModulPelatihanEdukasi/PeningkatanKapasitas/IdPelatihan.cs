using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

public class IdPelatihan : ValueObject, IEquatable<IdPelatihan>
{
    public const string ValidPattern = "^PC[0-9]{3}$";

    public string Value { get; }

    private IdPelatihan(string value)
    {
        Value = value;
    }

    public bool Equals(IdPelatihan? other) => base.Equals(other);

    public override bool Equals(object? obj) => base.Equals(obj);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdPelatihan> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdPelatihan.TidakValid", "Id valid dimulai PC dan diikuti 3 angka. Contoh ME001");

        return new IdPelatihan(value);
    }

    public static async Task<IdPelatihan> Generate(IRepositoriPelatihan repositoriPelatihan)
    {
        var newId = (await repositoriPelatihan.GetAll())
            .Select(m => int.Parse(m.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"PC{newId:D3}");
    }
}
