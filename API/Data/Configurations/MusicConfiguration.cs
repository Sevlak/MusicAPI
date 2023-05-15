using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API.Data.Configurations
{
    public class MusicConfiguration: IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.Property(m => m.Duration)
                .HasConversion(m => m.TotalSeconds, d => TimeSpan.FromSeconds(d));
        }
    }
}