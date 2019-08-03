using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Dynamic;
using Project.Domain.Entities;
using Project.Service.Validators;

namespace Project.Service.Services
{
    public class ContactService : BaseService<Contact>
    {

        public IQueryable<Contact> Get(string firstLetter, string search, string sortName, string sortDirection)
        {

            string ordering = string.Format("{0} {1}", sortName, sortDirection);

            var query = this.Get()
                .Where(c => (c.FirstLetterName().ToUpper() == firstLetter.ToUpper()
                            || firstLetter.Equals("ALL")) &&
                      (string.IsNullOrEmpty(search) ||
                       c.Name.Contains(search) ||
                       c.CellPhone.Contains(search) ||
                       c.HomePhone.Contains(search) ||
                       c.CommercialPhone.Contains(search) ||
                       c.Email.Contains(search)))
                .OrderBy(ordering);                

            return query.AsQueryable<Contact>();
        }

        public Contact Post(Contact contact)
        {
            var obj = this.Post<ContactValidator>(contact);
            return obj;

        }

    }
}
