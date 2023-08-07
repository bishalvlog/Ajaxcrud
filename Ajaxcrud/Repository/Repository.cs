using Ajaxcrud.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Ajaxcrud.Repository
{
    public class Repository : IRepository
    {
        string cs = "Server=DESKTOP-24P8ERF;Database=Ajaxcrud;Trusted_Connection=True; MultipleActiveResultSets=true;TrustServerCertificate=True";

        public int Add(Employee employee)
        {
            int i;
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", employee.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@State", employee.State);
                cmd.Parameters.AddWithValue("@Country", employee.Country);
                cmd.Parameters.AddWithValue("@Action", "Insert");

                i = cmd.ExecuteNonQuery();
                con.Close();
                return i;


            }
         
        }

        public int Delete(int Id)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("DeleteEmployee", conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                i = com.ExecuteNonQuery();

            }
            return i;
        }

        public List<Employee> GetAll()
        {

            List<Employee> list = new List<Employee>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand com = new SqlCommand("selectEmployee", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Employee
                    {
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        Name = reader["Name"].ToString(),
                        Age = Convert.ToInt32(reader["Age"]),
                        State = reader["State"].ToString(),
                        Country = reader["Country"].ToString()
                    });
                }
                return list;
            }
        }


        public int Update(Employee employee)
        {
            int i;
            using (SqlConnection conn = new SqlConnection(cs))
            {
                conn.Open();
                SqlCommand com = new SqlCommand("InsertUpdateEmployee",conn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", employee.EmployeeId);
                com.Parameters.AddWithValue("@Name", employee.Name);
                com.Parameters.AddWithValue("@Age", employee.Age);
                com.Parameters.AddWithValue("@State", employee.State);
                com.Parameters.AddWithValue("@Country", employee.Country);
                com.Parameters.AddWithValue("@Action", "Update");
                i = com.ExecuteNonQuery();
                return i;
                conn.Close();
            }
            
        }
    }
}

