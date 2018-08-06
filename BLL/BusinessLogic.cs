using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    /// <summary>
    /// business layer of the application
    /// </summary>
    public class BusinessLogic
    {
        public tbl_StudentsList[] GetSearchString(string searchString)
        {
            DataLayer mDataLayer = new DataLayer();
            return mDataLayer.GetSearchString(searchString).ToArray();
        }
    }
}
