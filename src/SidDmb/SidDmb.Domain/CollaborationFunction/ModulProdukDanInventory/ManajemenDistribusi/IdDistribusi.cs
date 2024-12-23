using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.ManajemenDistribusi;

public class IdDistribusi : ValueObject, IEquatable<IdDistribusi>
{
    public const string ValidPattern = "^MD[0-9]{3}$";

    public string Value { get; }

    private IdDistribusi(string value) => Value = value;

    public bool Equals(IdDistribusi? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();

    public static Result<IdDistribusi> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdDistribusi.TidakValid", "Id valid dimulai MD dan diikuti 3 angka");

        return new IdDistribusi(value);
    }

    public static async Task<IdDistribusi> Generate(IRepositoriDistribusi repositoriDistribusi)
    {
        var newId = (await repositoriDistribusi.GetAll())
            .Select(d => int.Parse(d.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"MD{newId:D3}");
    }
}
