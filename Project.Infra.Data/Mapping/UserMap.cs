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
    public class UserMap : EntityTypeConfiguration<User>

    {
     public UserMap()
        {
           ToTable("User");

           HasKey(c => c.Id);

           Property(c => c.DocumentNumber)
                .IsRequired()
                .HasColumnName("Cpf");

           Property(c => c.BirthDate)
                .IsRequired()
                .HasColumnName("BirthDate");

           Property(c => c.Name)
                .IsRequired()
                .HasColumnName("Name");
        }        
    }
}
