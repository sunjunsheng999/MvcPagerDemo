using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    /// <summary>
    /// ��ҳͨ����
    /// </summary>
    public sealed class SqlCommon
    {
        /// <summary>
        /// ͨ�÷�ҳ�洢���̣���������ѯ���������ֶΣ����������ֶεĽ�������
        /// </summary>
        /// <param name="PageSize">ÿҳ��¼��</param>
        /// <param name="CurrentCount">��ǰ��¼������ҳ��*ÿҳ��¼����</param>
        /// <param name="TableName">������</param>
        /// <param name="Where">��ѯ����������"ID>1000 AND Name like '%LiLinFeng%'" ����������ֱ���ں���ӣ�����" ORDER BY ID DESC,NAME ASC"</param>
        /// <param name="TotalCount">��¼����</param>
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
