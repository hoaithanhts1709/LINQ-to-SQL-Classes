using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenShoe.Dao
{
    class DataProvider
    {
        private static DataProvider instance;

        private DataProvider(){}
        internal static DataProvider Instance
        {
            get
            {
                if(instance ==null)
                {
                    instance = new DataProvider();
                }
                return instance;
            }
            
            private set => instance = value;
        }//Cap Instance
        string conection = @"Data Source=(local);Initial Catalog=MenShoeEntities;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        
        public List<T> ConvertToList<T>(DataTable dt)
        {
            var columnNames = dt.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return dt.AsEnumerable().Select(row => {
                var objT = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(objT, row[pro.Name]);
                        }
                        catch (Exception ex) { }
                    }
                }
                return objT;
            }).ToList();
        }

        public DataTable ExcuteQuery(string query, object[] parameter =null)
        {

            DataTable dataTable = new DataTable();
            using (SqlConnection SQLconnection = new SqlConnection(conection))
            {
                SQLconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, SQLconnection);
                if(parameter !=null)
                {
                    string[] listpara = query.Split(' ');
                    int i = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                SQLconnection.Close();
            }
            return dataTable;
        }
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int i = 0;
            using (SqlConnection SQLconnection = new SqlConnection(conection))
            {
                SQLconnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, SQLconnection);
               
                if (parameter != null)
                {
                    string[] listpara = query.Split(' ');
                    int j = 0;
                    foreach (string item in listpara)
                    {
                        if (item.Contains("@"))
                        {
                            sqlCommand.Parameters.AddWithValue(item, parameter[j]);
                            j++;
                        }
                    }
                }
                i = sqlCommand.ExecuteNonQuery();
                SQLconnection.Close();
            }
            return i;
        }
    }
}
