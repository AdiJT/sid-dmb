namespace SidDmb.Domain.Abstracts;

public interface IAuditableEntity
{
    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }
}
