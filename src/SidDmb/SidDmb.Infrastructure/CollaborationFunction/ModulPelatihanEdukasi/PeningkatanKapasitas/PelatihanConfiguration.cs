using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulPelatihanEdukasi.PeningkatanKapasitas;

internal class PelatihanConfiguration : IEntityTypeConfiguration<Pelatihan>
{
    public void Configure(EntityTypeBuilder<Pelatihan> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdPelatihan.Create(s).Value);

        builder.HasMany(x => x.DaftarKolaborator).WithMany(x => x.DaftarPelatihan);
    }
}