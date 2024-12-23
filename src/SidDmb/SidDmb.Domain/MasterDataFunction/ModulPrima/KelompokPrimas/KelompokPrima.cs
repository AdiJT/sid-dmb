using SidDmb.Domain.Abstracts;
using SidDmb.Domain.MasterDataFunction.ModulPrima.KegiatanPrimas;

namespace SidDmb.Domain.MasterDataFunction.ModulPrima.KelompokPrimas;

public class KelompokPrima : Entity<IdKelompok>, IAuditableEntity
{
    public required string Nama { get; set; }
    public required string Dekripsi { get; set; }
    public required int JumlahAnggota { get; set; }
    public required string KetuaKelompok { get; set; }
    public required int TahunBerdiri { get; set; }
    public required FokusKegiatanKelompokPrima FokusKegiatan { get; set; }
    public required string ProgramUnggulan { get; set; }
    public required string Alamat { get; set; }
    public required string KontakInformasi { get; set; }
    public required Uri MediaPromosi { get; set; }
    public required int JumlahProgramDilaksanakan { get; set; }

    public DateTime TanggalDiinputkan { get; set; }
    public DateTime TanggalPembaruanData { get; set; }

    public List<KegiatanPrima> DaftarKegiatanPrima { get; set; } = [];
}