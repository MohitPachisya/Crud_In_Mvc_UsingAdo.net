using StudentMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StudentMvcProject.Serivce
{

    public class RegService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        public void RegInsertData(RegModel objmodel)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", string.IsNullOrWhiteSpace(objmodel.Name) ? "-" : objmodel.Name);
                cmd.Parameters.AddWithValue("@City", string.IsNullOrWhiteSpace(objmodel.City) ? "-" : objmodel.City);
                if (objmodel.Age == null || objmodel.Age == 0)
                {
                    cmd.Parameters.AddWithValue("@Age", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Age", objmodel.Age);
                }
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
        }
        public List<RegModel> GetData()
        {
            try
            {
                List<RegModel> list = new List<RegModel>();
                con.Open();
                SqlCommand cmd = new SqlCommand("GetSp", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new RegModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        City = dr["City"].ToString(),
                        Age = dr["Age"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Age"])
                    });
                }
                return list;
            }
            catch
            {
                throw;
            }
        }
        public List<RegModel> GetDataById(RegModel ItemId)
        {
            try
            {
                List<RegModel> list = new List<RegModel>();
                con.Open();
                SqlCommand cmd = new SqlCommand("GetSpById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ItemId.Id);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new RegModel
                    {
                        Name = reader["Name"].ToString(),
                        City = reader["City"].ToString(),
                        Age = Convert.ToInt32(reader["Age"])
                    });
                }
                con.Close();
                return list;
            }
            catch
            {
                throw;
            }
        }
        public void RegDeleteData(RegModel ItemId)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ItemId.Id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
        }

        public void RegUpdateData(RegModel ItemId)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", ItemId.Id);
                cmd.Parameters.AddWithValue("@Name", ItemId.Name);
                cmd.Parameters.AddWithValue("@City", ItemId.City);
                cmd.Parameters.AddWithValue("@Age", ItemId.Age);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                throw;
            }
        }
    }
}