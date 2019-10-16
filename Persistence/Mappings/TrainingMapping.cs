﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class TrainingMapping : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> builder)
        {
            builder.ToTable("Trainings", "Core");

            builder.HasKey(t => t.Id)
                .ForSqlServerIsClustered(false);

            builder.Property(t => t.Id)
                .ValueGeneratedNever();
        }
    }
}
