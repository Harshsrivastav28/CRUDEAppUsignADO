using CRUDEAppUsignADO.Models;
using System.Data;
using System.Data.SqlClient;

namespace CRUDEAppUsignADO
{
    public class EmployeeDataAccessLayer
    {
        string cs = ConnectionString.dbcs;

        public List<Employees> getAllEmployees()
        {
            List<Employees> emplist = new List<Employees>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employees emp = new Employees();

                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString();
                    emp.City = reader["City"].ToString();

                    emplist.Add(emp);
                }
            }

            return emplist;
        }
        public Employees GetEmployeeById(int id)
        {
            Employees emp = new Employees();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from employees where id = @id", con);
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString();
                    emp.Gender = reader["Gender"].ToString();
                    emp.Age = Convert.ToInt32(reader["Age"]);
                    emp.Designation = reader["Designation"].ToString();
                    emp.City = reader["City"].ToString();

                }
            } 
                return emp;
            }




        public void AddEmployees(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@City", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateEmployees(Employees emp)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", emp.Id);

                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Designation", emp.Designation);
                cmd.Parameters.AddWithValue("@City", emp.City);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}