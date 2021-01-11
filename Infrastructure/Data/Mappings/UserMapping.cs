using curso.api.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace curso.api.Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        // The configure method is required by interface IEntityTypeConfiguration.
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable("tb_users"); // create table name
            builder.HasKey(p => p.Code); // reference the primary key in entity
            builder.Property(p => p.Code).ValueGeneratedOnAdd(); // auto increment
            builder.Property(p => p.Name); // reference the name in entity
            builder.Property(p => p.Email); // reference the email in entity
            builder.Property(p => p.Password); // reference the password in entity
        }
    }
}