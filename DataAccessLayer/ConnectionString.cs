using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class ConnectionString
    {
        public static string ConStrOnline = @"data source=veksis.database.windows.net;initial catalog=BemBlog_DB;persist security info=True;user id=veksis;password=kksju72m!;MultipleActiveResultSets=True";
        public static string ConStrLocal = @"Data Source=.\SQLEXPRESS; Initial Catalog=BemBlog_DB; Integrated Security=True";
    }
}
