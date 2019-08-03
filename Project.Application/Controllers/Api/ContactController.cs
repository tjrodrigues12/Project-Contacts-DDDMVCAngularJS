using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Project.Domain.Entities;
using Project.Service.Services;

namespace Project.Application.Controllers.Api
{
    public class ContactController : ApiController
    {

        #region List

        // GET: api/Contact
        [HttpGet]
        public object Get(string firstLetter, string search, int pageIndex, int pageSize, string sortName, string sortDirection)
        {
            object obj = null;

            try
            {
                var service = new ContactService();

                var data = service.Get(firstLetter, search, sortName, sortDirection).Skip(pageIndex).Take(pageSize).ToList();
                var totalItems = service.Get(firstLetter, search, sortName, sortDirection).Count();

                obj = new
                {
                    result = data,
                    count = totalItems,
                    message = string.Empty
                };
            }
            catch (Exception ex)
            {
                obj = new
                {
                    result = "",
                    count = 0,
                    message = ex.Message
                };
            }

            return obj;
        }

        #endregion


        // GET: api/Contact/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        [HttpPost]
        public void Post([FromBody] Contact contact)
        {
            object obj = null;

            try
            {
                var service = new ContactService();

                var result = service.Post(contact);

                obj = new
                {
                    result = result,
                    message = ""
                };
            }
            catch (Exception ex)
            {
                obj = new
                {
                    result = "",
                    message = ex.Message
                };
            }

        }

        // PUT: api/Contact/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Contact/5
        public void Delete(int id)
        {
        }
    }
}
