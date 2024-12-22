using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.KalenderAcaras;

public class IdAcara : ValueObject, IEquatable<IdAcara>
{
    public const string ValidPattern = "^AC[0-9]{3}$";

    public string Value { get; }

    private IdAcara(string value)
    {
        Value = value;
    }

    public bool Equals(IdAcara? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<IdAcara> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdAcara.TidakValid", "Id valid dimulai AC dan diikuti 3 angka. Contoh : AC001");

        return new IdAcara(value);
    }

    public static async Task<IdAcara> Generate(IRepositoriKalenderAcara repositoriKalenderAcara)
    {
        var lastId = (await repositoriKalenderAcara.GetAll())
            .Select(k => int.Parse(k.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault();

        return new($"AC{lastId + 1:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}
