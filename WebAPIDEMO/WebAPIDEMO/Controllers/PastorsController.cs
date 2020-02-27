using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ELCSADataAccess;

namespace WebAPIDEMO.Controllers
{
    public class PastorsController : ApiController
    {
        public IEnumerable<Pastor> Get()
        {
            //will return a list of all pastors
            using (ELCSAEntities entities = new ELCSAEntities())
            {
                return entities.Pastors.ToList();
            }
        }

        public Pastor Get( int id)
        {
            //will return a list of all pastors
            using (ELCSAEntities entities = new ELCSAEntities())
            {
                // was not the same data type
                return entities.Pastors.FirstOrDefault(e => e.Parish_ID== id);
            }
        }
    }
}
