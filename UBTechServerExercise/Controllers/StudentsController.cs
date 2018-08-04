using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace UBTechServerExercise.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        // GET: api/Students/GetSearchString/{search string}
        [Route("Api/Students/GetSearchString/{searchString}")]
        public IEnumerable<tbl_StudentsList> GetSearchString(string searchString)
        {
            tbl_StudentsList[] res;

            if (searchString.Length < 2)
            {
                return new tbl_StudentsList[0];
            }

            using (var context = new Database1Entities())
            {
                var blog = from el in context.tbl_StudentsList
                           where el.FirstName.IndexOf(searchString) >= 0 || el.LastName.IndexOf(searchString) >= 0
                           select el;

                res = blog.ToArray();
            }

            return res;
        }
    }
}
