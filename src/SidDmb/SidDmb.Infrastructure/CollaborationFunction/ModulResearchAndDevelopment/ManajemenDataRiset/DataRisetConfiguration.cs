﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SidDmb.Domain.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

namespace SidDmb.Infrastructure.CollaborationFunction.ModulResearchAndDevelopment.ManajemenDataRiset;

internal class DataRisetConfiguration : IEntityTypeConfiguration<DataRiset>
{
    public void Configure(EntityTypeBuilder<DataRiset> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).HasConversion(i => i.Value, s => IdDataRiset.Create(s).Value);

        builder.HasMany(x => x.DaftarKolaboratorPenelitian).WithMany(x => x.DaftarDataRiset).UsingEntity<KolaboratorDataRiset>(
            l => l.HasOne(x => x.Entity2).WithMany(x => x.DaftarKolaboratorDataRiset).HasForeignKey(x => x.Entity2Id),
            r => r.HasOne(x => x.Entity1).WithMany(x => x.DaftarKolaboratorDataRiset).HasForeignKey(x => x.Entity1Id)); ;
    }
}