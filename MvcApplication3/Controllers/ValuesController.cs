using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication3.Controllers
{
    public class Book
    {
        public int id {get;set;}
        public string name { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/values
        // set header to Accept:application/json to get json back.
        public IEnumerable<Book> Get()
        {
            return new Book[] { new Book{id=1, name ="value1"}, 
                new Book{id=2, name="value2" } };
        }

        // GET api/values/5
        // to get json back: set header to Accept:application/json 
        public Book Get(int id)
        {
            return new Book { id = 2, name = "value2" };
        }

        // POST api/values   new insert
        // 
        public HttpResponseMessage Post([FromBody]Book value)
        {
            try
            {
                // ModelState.IsValid tells you if any model errors have been added to ModelState
                if (ModelState.IsValid)
                {
                    
                    // TODO: do insert in db.
                    return Request.CreateResponse(HttpStatusCode.OK, string.Format("id: {0}, name: {1}", value.id, value.name));
                     
                }
                else
                {
                    var errors = ModelState
                        .Where(s => s.Value.Errors.Count > 0)
                        .Select(s => new KeyValuePair<string, string>(s.Key, s.Value.Errors.First().ErrorMessage))
                        .ToArray();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
                    // something like this will return for bad data:
                    // [{"Key":"value.id","Value":"The value 'pl' is not valid for id."}]
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/values/5   update
        public HttpResponseMessage Put(int id, [FromBody]Book value)
        {
            // TODO: simplar to post, instead insert, do update
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            // TODO: simplar to post, instead insert, do delete
            return Request.CreateResponse(HttpStatusCode.NotImplemented);
        }
    }
}