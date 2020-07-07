using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace StudeskDAL
{
    public static class Common
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["StudeskConnection"].ConnectionString;
            }
        }
        public static string DBNullToString(this object value)
        {
            return (DBNull.Value.Equals(value) ? string.Empty : Convert.ToString(value));
        }
        public static Boolean DBNullToBoolean(this object value)
        {
            return (DBNull.Value.Equals(value) ? false : Convert.ToBoolean(value));
        }
        public static DateTime? DBNullToDateTime(this object value)
        {
            if (DBNull.Value.Equals(value))
                return null;
            else
                return Convert.ToDateTime(value);
        }
        public static decimal? DBNullToDecimal(this object value)
        {
            return (DBNull.Value.Equals(value) ? null : (decimal?)value);
        }
        public static int DBNullToInteger(this object value)
        {
            return (DBNull.Value.Equals(value) ? default(int) : int.Parse(value.ToString()));
        }
        public static SqlParameter[] SetParameters(object objData)
        {
            Type objType = null;
            int i = 0;
            if (objData != null)
            {
                objType = objData.GetType();
            }
            SqlParameter[] param = new SqlParameter[objType.GetProperties().Length];
            foreach (PropertyInfo propertyInfo in objType.GetProperties())
            {
                param[i] = new SqlParameter("@" + propertyInfo.Name.ToString(), propertyInfo.GetValue(objData));
                //param[i].DbType = propertyInfo.GetType();
                i++;
            }
            return param;
        }
        public static string InsUpdDel(string ProcName, SqlParameter[] p)
        {
            try
            {
                SqlConnection cn = new SqlConnection(ConnectionString);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(ProcName, cn);

                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in p)
                {
                    cmd.Parameters.Add(param);
                }
                cmd.ExecuteNonQuery();
                cn.Close();
                return "1";
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message.ToString();
            }
        }
        public static DataTable GetAllData(string ProcName)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection cn = new SqlConnection(ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter(ProcName, ConnectionString);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                dt.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt.NewRow();

                dr["Error"] = "Error :" + ex.Message;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        public static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
        public static DataTable InsertGet(string ProcName, SqlParameter[] p)
        {
            DataTable dt = new DataTable();
            try
            {
                //SqlConnection cn = new SqlConnection(ConnectionString);
                //SqlDataAdapter da = new SqlDataAdapter(ProcName, ConnectionString);
                //da.Fill(dt);
                SqlConnection cn = new SqlConnection(ConnectionString);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(ProcName, cn);

                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in p)
                {
                    cmd.Parameters.Add(param);
                }
                object obj = cmd.ExecuteScalar();
                dt.Columns.Add(new DataColumn("Return_Value", typeof(Int32)));
                DataRow dr = dt.NewRow();

                dr["Return_Value"] = obj.ToString();
                dt.Rows.Add(dr);                
                cn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                dt.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt.NewRow();

                dr["Error"] = "Error :" + ex.Message;
                dt.Rows.Add(dr);
            }
            return dt;            
        }
        public static DataTable GetAllDataParameterized(string ProcName, SqlParameter[] p)
        {

            DataTable dt = new DataTable();
            try
            {
                SqlConnection cn = new SqlConnection(ConnectionString);
                if (cn.State == ConnectionState.Open)
                    cn.Close();
                cn.Open();
                SqlCommand cmd = new SqlCommand(ProcName, cn);

                cmd.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter param in p)
                {
                    cmd.Parameters.Add(param);
                }

                SqlDataReader dr = cmd.ExecuteReader();

                dt.Load(dr);
            }
            catch (Exception ex)
            {
                dt.Columns.Add(new DataColumn("Error", typeof(string)));
                DataRow dr = dt.NewRow();

                dr["Error"] = "Error :" + ex.Message;
                dt.Rows.Add(dr);
            }
            return dt;
        }

    }
}
