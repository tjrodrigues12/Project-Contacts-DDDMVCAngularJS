using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    [Table("dbo.User")]
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string  DocumentNumber { get; set; }
    }
}
