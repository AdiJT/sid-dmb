using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

public class IdUpacara : ValueObject, IEquatable<IdUpacara>
{
    private const string ValidPattern = "^UB[0-9]{3}$";

    public string Value { get; }

    private IdUpacara(string value)
    {
        Value = value;
    }

    public bool Equals(IdUpacara? other) => base.Equals(other);

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override int GetHashCode() => base.GetHashCode();

    public override bool Equals(object? obj) => obj is not null && obj is IdUpacara other && base.Equals(other);

    public static Result<IdUpacara> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdUpacara.TidakValid", "Id valid dimulai UB dan 3 angka. Contoh UB001");

        return new IdUpacara(value);
    }

    public static async Task<IdUpacara> Generate(IRepositoriUpacaraBudaya repositoriUpacaraBudaya)
    {
        var newId = (await repositoriUpacaraBudaya.GetAll())
            .Select(u => int.Parse(u.Id.Value.Substring(2)))
            .Order()
            .LastOrDefault() + 1;

        return new($"UB{newId:D3}");
    }
}
