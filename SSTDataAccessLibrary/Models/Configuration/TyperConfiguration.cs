using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSTDataAccessLibrary.Models.Configuration
{
    internal class TyperConfiguration : IEntityTypeConfiguration<Typer>
    {
        public void Configure(EntityTypeBuilder<Typer> builder)
        {
            builder.HasData(
                new Typer
                {
                    UserName = "test",
                    Login = "test",
                    Email = "test@test.com",
                }
                );
        }
    }
}
