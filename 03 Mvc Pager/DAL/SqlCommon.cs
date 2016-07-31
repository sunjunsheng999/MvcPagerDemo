using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// 分页通用类
    /// </summary>
    public sealed class SqlCommon
    {
        /// <summary>
        /// 通用分页存储过程，有条件查询，有排序字段，按照排序字段的降序排列
        /// </summary>
        /// <param name="PageSize">每页记录数</param>
        /// <param name="CurrentCount">当前记录数量（页码*每页记录数）</param>
        /// <param name="TableName">表名称</param>
        /// <param name="Where">查询条件，例："ID>1000 AND Name like '%LiLinFeng%'" 排序条件，直接在后面加，例：" ORDER BY ID DESC,NAME ASC"</param>
        /// <param name="TotalCount">记录总数</param>
        /// <returns></returns>
        public static DataSet GetList(string connectionString, string Order, int PageSize, int CurrentCount, string TableName, string Where, out int TotalCount)
        {
            SqlParameter[] parmList =
                {
                    new SqlParameter("@PageSize",PageSize),
                    new SqlParameter("@CurrentCount",CurrentCount),
                    new SqlParameter("@TableName",TableName),
                    new SqlParameter("@Where",Where),
                    new SqlParameter("@Order",Order),
                    new SqlParameter("@TotalCount",SqlDbType.Int,4)
                };
            parmList[5].Direction = ParameterDirection.Output;
            DataSet ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "prPager", parmList);
            TotalCount = Convert.ToInt32(parmList[5].Value);
            return ds;
        }
    }
}
