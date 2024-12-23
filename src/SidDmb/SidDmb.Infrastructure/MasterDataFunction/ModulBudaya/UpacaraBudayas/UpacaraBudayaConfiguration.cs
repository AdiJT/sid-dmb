using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya.UpacaraBudayas;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya.UpacaraBudayas;

internal class UpacaraBudayaConfiguration : IEntityTypeConfiguration<UpacaraBudaya>
{
    public void Configure(EntityTypeBuilder<UpacaraBudaya> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdUpacara.Create(s).Value);
        builder.Property(x => x.WaktuPelaksanaan).HasColumnType("timestamp without time zone");

        builder.HasMany(x => x.FasilitasPendukung).WithMany(x => x.DaftarUpacaraBudaya);
    }
}