using System;

using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    [Table("dbo.Contact")]
    public class Contact : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime AddDate { get; set; }

        public string CellPhone { get; set; }

        public string CommercialPhone { get; set; }

        public string HomePhone { get; set; }

        /// <summary>
        /// Return first letter of the nome
        /// </summary>
        /// <returns></returns>
        public string FirstLetterName()
        {
            return this.Name.Substring(0, 1);
        }

    }

        
}
