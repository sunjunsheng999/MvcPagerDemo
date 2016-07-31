using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
    public class Info
    {
        private static readonly string connectionString = "server=127.0.0.1;database=MvcPager;uid=sa;pwd=123456;";
        public static List<Model.Info> GetInfos(string Title, int PageSize, int CurrentCount, out int TotalCount)
        {
            string Order = string.Format("InfoID DESC");
            string TableName = string.Format("Info");
            string Where = " 1=1";
            if (!string.IsNullOrEmpty(Title))
            {
                Where += string.Format(" AND Title LIKE '%{0}%'", Title);
            }
            DataSet ds = SqlCommon.GetList(connectionString, Order, PageSize, CurrentCount, TableName, Where, out TotalCount);
            List<Model.Info> result = new List<Model.Info>();
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result.Add(new Model.Info() { InfoID = Convert.ToInt32(dr["InfoID"]), Title = dr["Title"].ToString(), Content = dr["Content"].ToString() });
                }
            }
            return result;
        }
    }
}
