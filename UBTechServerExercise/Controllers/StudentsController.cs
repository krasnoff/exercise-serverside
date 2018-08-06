using DAL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace UBTechServerExercise.Controllers
{
    /// <summary>
    /// controller for the get students web.api call
    /// </summary>
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StudentsController : ApiController
    {
        // GET: api/Students/GetSearchString/{search string}
        /// <summary>
        /// web.pai controller.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [Route("Api/Students/GetSearchString/{searchString}")]
        public IEnumerable<tbl_StudentsList> GetSearchString(string searchString)
        {
            tbl_StudentsList[] res;

            BusinessLogic mBusinessLogic = new BusinessLogic();
            res = mBusinessLogic.GetSearchString(searchString);

            return res;
        }
    }
}
