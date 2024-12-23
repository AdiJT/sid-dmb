using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.MasterDataFunction.ModulBudaya;

namespace SidDmb.Infrastructure.MasterDataFunction.ModulBudaya;

internal class FasilitasConfiguration : IEntityTypeConfiguration<Fasilitas>
{
    public void Configure(EntityTypeBuilder<Fasilitas> builder)
    { 
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.DaftarSitusBudaya).WithMany(x => x.DaftarFasilitas);
        builder.HasMany(x => x.DaftarSeniBudaya).WithMany(x => x.FasilitasPertunjukan);
        builder.HasMany(x => x.DaftarUpacaraBudaya).WithMany(x => x.FasilitasPendukung);
    }
}