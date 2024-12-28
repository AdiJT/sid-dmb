using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulProdukDanInventory.SertifikasiDanLegalitas;

internal class SertifikasiConfiguration : IEntityTypeConfiguration<Sertifikasi>
{
    public void Configure(EntityTypeBuilder<Sertifikasi> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdSertifikasi.Create(s).Value);

        builder.HasOne(x => x.Produk).WithOne().HasForeignKey<Sertifikasi>("ProdukId");
        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarSertifikasi).UsingEntity<KolaboratorSertifikasi>(
            l => l.HasOne(x => x.Entity2).WithMany(x => x.DaftarKolaboratorSertifikasi).HasForeignKey(x => x.Entity2Id),
            r => r.HasOne(x => x.Entity1).WithMany(x => x.DaftarKolaboratorSertifikasi).HasForeignKey(x => x.Entity1Id));
    }
}