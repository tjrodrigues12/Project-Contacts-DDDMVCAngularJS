using System;
using System.Collections.Generic;
using System.Text;

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using FluentValidation;
using System.Data.Entity;
using Project.Domain.Entities;

namespace Project.Infra.Data.Mapping
{
    public class ContactMap : EntityTypeConfiguration<User>

    {
     public ContactMap()
        {
           ToTable("Contact");

            HasKey(c => c.Id);      
            
           Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }        
    }
}
