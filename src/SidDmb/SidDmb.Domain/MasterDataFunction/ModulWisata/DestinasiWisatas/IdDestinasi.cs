using SidDmb.Domain.Abstracts;
using SidDmb.Domain.Shared;
using System.Text.RegularExpressions;

namespace SidDmb.Domain.MasterDataFunction.ModulWisata.DestinasiWisatas;

public class IdDestinasi : ValueObject, IEquatable<IdDestinasi>
{
    private const string ValidPattern = "^DW[0-9]{3}$";

    public string Value { get; }

    private IdDestinasi(string value)
    {
        Value = value;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public bool Equals(IdDestinasi? other) => base.Equals(other);

    public static Result<IdDestinasi> Create(string value)
    {
        if (!Regex.IsMatch(value, ValidPattern))
            return new Error("IdDestinasi.TidakValid", "ID valid dimulai oleh DW dan diikuti 3 angka");

        return new IdDestinasi(value);
    }

    public static async Task<IdDestinasi> Generate(IRepositoriDestinasiWisata repositoriDestinasiWisata)
    {
        var lastId = (await repositoriDestinasiWisata.GetAll())
            .Select(d => int.Parse(d.Id.Value.Substring(2)))
            .OrderBy(i => i)
            .LastOrDefault();

        return new($"DW{lastId + 1:D3}");
    }

    public override bool Equals(object? obj) => base.Equals(obj);

    public override int GetHashCode() => base.GetHashCode();
}
