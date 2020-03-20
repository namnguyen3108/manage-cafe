using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAL
{
    public class BaseModel
    {
        public string con = @"Data Source = DESKTOP-UT034N2\SQLEXPRESS; Initial Catalog = MANAGE_CAFE; User ID = sa; Password=n@mnguyen3108";

        private SqlConnection db = null;

        public SqlConnection getInstance()
        {
            if (db == null)
            {
                db = new SqlConnection(con);
            }
            return db;
        }
        protected B getSpecificName<B>(SqlDataReader sqlResult, string columnName)
        {
            var recordResult = default(B);
            try
            {
                int orderColumn = sqlResult.GetOrdinal(columnName);
                if (orderColumn >= 0)
                {
                    recordResult = (B)sqlResult[orderColumn];
                }
                //return default(T);
            }
            catch (Exception ex)
            {
                ////return ẽ
                //throw ex;
            }
            return recordResult;
        }
    }
}