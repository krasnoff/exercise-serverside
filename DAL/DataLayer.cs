using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// represents the data layer of the application
    /// </summary>
    public class DataLayer
    {
        /// <summary>
        /// actual execute of the database query
        /// simple query which selects all the students that their last name or first name contains the string parameter (searchString)
        /// </summary>
        /// <param name="searchString">string parameter</param>
        /// <returns></returns>
        public IEnumerable<tbl_StudentsList> GetSearchString(string searchString)
        {
            tbl_StudentsList[] res;

            // returns an empty array if the length of the string parameter length is smaller than 2. insure that there will be no access to database in this case.
            if (searchString.Length < 2)
            {
                return new tbl_StudentsList[0];
            }

            try
            {
                // run query through entity framework
                using (var context = new SchoolDataBaseEntities())
                {
                    var blog = from el in context.tbl_StudentsList
                               where el.FirstName.IndexOf(searchString) >= 0 || el.LastName.IndexOf(searchString) >= 0
                               select el;

                    res = blog.ToArray();
                }
            }
            catch (Exception ex)
            {
                // in case of error returns an empty string and write error in the Event Viewer.
                res = new tbl_StudentsList[0];
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Application";
                    eventLog.WriteEntry("Error In School Application:\n" + ex.Message + "\n" + ex.StackTrace, EventLogEntryType.Error, 101, 1);
                }
            }

            return res;
        }
    }
}
