using ERPSystem.DataAccess.Map.Base;
using ERPSystem.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPSystem.DataAccess.Map
{
    public class CategoryMap:BaseMap<Category>
    {

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.Property(x=>x.Name).HasMaxLength(500).IsRequired();
        }
    }
}
