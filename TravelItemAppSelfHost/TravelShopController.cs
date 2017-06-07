using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelItemAppSelfHost
{
    public class TravelShopController : System.Web.Http.ApiController
    {
        public List<string> GetLocationNames()
        {
            DataTable lcResult = clsDbConnection.GetDataTable("SELECT LocationName FROM Location", null);
            List<string> lcLocationNames = new List<string>();
            foreach (DataRow dr in lcResult.Rows)
                lcLocationNames.Add((string)dr[0]);
                return lcLocationNames;
        }
    }
}
