using Employee_CRUD.Models;
using Employee_CRUD.Interfaces;
using Microsoft.Data.SqlClient;
using static Employee_CRUD.Models.EmpModel;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_CRUD.Data
{
    public class DataAccess : IEmpOperaction, IOperations,ILogin
    {
        string SQLstring = "";
        int _isAdd = 0;
        private readonly IConfiguration _config;

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        #region "Emp Operation"

        public async Task<int> NewEmpAsync(EmpModel.Emp emp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection
                            (_config.GetConnectionString("conn")))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand("InsertEmployee", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                        cmd.Parameters.AddWithValue("@FullName", emp.FullName);
                        cmd.Parameters.AddWithValue("@Email", emp.Email);
                        cmd.Parameters.AddWithValue("@Tel", emp.Tel);
                        cmd.Parameters.AddWithValue("@Address", emp.Address);
                        cmd.Parameters.AddWithValue("@JobId", emp.JobId);
                        cmd.Parameters.AddWithValue("@DepartmentId", emp.DepartmentId);
                        cmd.Parameters.AddWithValue("@JoinedDate", emp.JoinedDate);
                        cmd.Parameters.AddWithValue("@UserId", emp.UserId);
                        _isAdd = await cmd.ExecuteNonQueryAsync();
                        await cmd.DisposeAsync();
                        await conn.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

            return _isAdd;
        }

        public async Task DeleteEmpAsync(int empId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection
                            (_config.GetConnectionString("conn")))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand("delete from Employee where EmpId=@EmpId", conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@EmpId", empId);
                    
                         await cmd.ExecuteNonQueryAsync();
                        await cmd.DisposeAsync();
                        await conn.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {

              
            }

        

        }
        public async Task<List<ViewEmp>> GetAllEmpsAsync()
        {
            List<ViewEmp> listOfData = new List<ViewEmp>();

            using (SqlConnection conn = new SqlConnection
               (_config.GetConnectionString("conn")))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("select *from ViewEmployee order by fullname", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader drAsync = await cmd.ExecuteReaderAsync();
                    while (await drAsync.ReadAsync())
                    {
                        listOfData.Add(new ViewEmp
                        {
                            EmpId = Convert.ToInt32(drAsync["EmpId"].ToString()),
                            JobId = Convert.ToInt32(drAsync["JobId"].ToString()),
                            DepartmentId = Convert.ToInt32(drAsync["DepartmentId"].ToString()),
                            Email = drAsync["Email"].ToString(),
                            FullName = drAsync["FullName"].ToString(),
                            Address = drAsync["Address"].ToString(),
                            Tel = drAsync["Tel"].ToString(),
                            JobName = drAsync["JobName"].ToString(),
                            DepartmentName = drAsync["DepartmentName"].ToString(),
                            JoinedDate =Convert.ToDateTime(drAsync["JoinedDate"].ToString()),
                        });
                    }
                    await drAsync.CloseAsync();
                    await conn.DisposeAsync();

                }
            }
            return listOfData;
        }
        public async Task<List<ViewEmp>> GetEmpByIdAsync(int empId)
        {
            List<ViewEmp> listOfData = new List<ViewEmp>();

            using (SqlConnection conn = new SqlConnection
               (_config.GetConnectionString("conn")))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("select *from ViewEmployee where empId=@empId", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@empId", empId);
                    SqlDataReader drAsync = await cmd.ExecuteReaderAsync();
                    
                    while (await drAsync.ReadAsync())
                    {
                        listOfData.Add(new ViewEmp
                        {
                            EmpId = Convert.ToInt32(drAsync["EmpId"].ToString()),
                            Email = drAsync["Email"].ToString(),
                            FullName = drAsync["FullName"].ToString(),
                            Address = drAsync["Address"].ToString(),
                            Tel = drAsync["Tel"].ToString(),
                            JobName = drAsync["JobName"].ToString(),
                            DepartmentName = drAsync["DepartmentName"].ToString(),
                            JoinedDate = Convert.ToDateTime(drAsync["JoinedDate"].ToString()),
                        });
                    }
                    await drAsync.CloseAsync();
                    await conn.DisposeAsync();

                }
            }
            return listOfData;
        }
        #endregion

        #region "Settings Operation"
        public async Task<List<Departments>> GetDepartmentsAsync()
        {
            List<Departments> listOfData = new List<Departments>();

            using (SqlConnection conn = new SqlConnection
               (_config.GetConnectionString("conn")))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = new SqlCommand("select *from Departments order by departmentname", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader drAsync = await cmd.ExecuteReaderAsync();
                    while (await drAsync.ReadAsync())
                    {
                        listOfData.Add(new Departments
                        {
                            DepartmentId = Convert.ToInt32(drAsync["DepartmentId"].ToString()),
                            DepartmentName = drAsync["DepartmentName"].ToString(),
                        });
                    }
                    await drAsync.CloseAsync();
                    await conn.DisposeAsync();

                }
            }
            return listOfData;
        }


        public async Task<List<Jobs>> GetJobsAsync()
        {
            List<Jobs> listOfData = new List<Jobs>();

            using (SqlConnection conn = new SqlConnection
               (_config.GetConnectionString("conn")))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();

                    SqlCommand cmd = new SqlCommand("select *from jobs order by jobname", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    SqlDataReader drAsync = await cmd.ExecuteReaderAsync();
                    while (await drAsync.ReadAsync())
                    {
                        listOfData.Add(new Jobs
                        {
                            JobId = Convert.ToInt32(drAsync["JobId"].ToString()),
                            JobName = drAsync["JobName"].ToString(),
                        });
                    }
                    await drAsync.CloseAsync();
                    await conn.DisposeAsync();

                }
            }
            return listOfData;
        }

        public async Task<int> AddJobs(EmpModel.Jobs jobs)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection
                            (_config.GetConnectionString("conn")))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand("InsertJob", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@JobId", jobs.JobId);
                        cmd.Parameters.AddWithValue("@JobName", jobs.JobName);

                        _isAdd = await cmd.ExecuteNonQueryAsync();
                        await cmd.DisposeAsync();
                        await conn.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

            return _isAdd;
        }

        public async Task<int> AddDepartment(EmpModel.Departments departments)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection
                            (_config.GetConnectionString("conn")))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand("InsertDepartment", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DepartmentId", departments.DepartmentId);
                        cmd.Parameters.AddWithValue("@DepartmentName", departments.DepartmentName);

                        _isAdd = await cmd.ExecuteNonQueryAsync();
                        await cmd.DisposeAsync();
                        await conn.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {

                return 0;
            }

            return _isAdd;
        }

        public async Task DeleteJob(int jobId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection
                            (_config.GetConnectionString("conn")))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand("delete from Jobs where JobId=@JobId", conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@JobId", jobId);

                        await cmd.ExecuteNonQueryAsync();
                        await cmd.DisposeAsync();
                        await conn.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {


            }
        }

        public async Task DeleteDepartment(int departmentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection
                            (_config.GetConnectionString("conn")))
                {
                    if (conn.State == System.Data.ConnectionState.Closed)
                    {
                        await conn.OpenAsync();
                        SqlCommand cmd = new SqlCommand("delete from Departments where DepartmentId=@DepartmentId", conn);
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@DepartmentId", departmentId);

                        await cmd.ExecuteNonQueryAsync();
                        await cmd.DisposeAsync();
                        await conn.DisposeAsync();

                    }
                }
            }
            catch (Exception ex)
            {


            }
        }


        #endregion

        #region "Security Area"
        public async Task<LoginModel.AuthenticatedResponse> UserAccessLogin(LoginModel login)
        {
            LoginModel.AuthenticatedResponse token = new LoginModel.AuthenticatedResponse();
          
            using (SqlConnection conn = new SqlConnection
               (_config.GetConnectionString("conn")))
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    await conn.OpenAsync();
                    token.Token = "";
                    SqlCommand cmd = new SqlCommand("select *from Users where Username=@userName And Password=@Password", conn);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserName", login.UserName);
                    cmd.Parameters.AddWithValue("@Password", login.Password);
                    SqlDataReader drAsync = await cmd.ExecuteReaderAsync();
                    while (await drAsync.ReadAsync())
                    {
                        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                        var tokeOptions = new JwtSecurityToken(
                            issuer: "http://localhost/Employee",
                            audience: "http://localhost/Employee",
                            expires: DateTime.Now.AddHours(1),
                            signingCredentials: signinCredentials
                        );
                        token.Token = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                       
                    }
                    await drAsync.CloseAsync();
                    await conn.DisposeAsync();

                }
            }
            return (token);
        }
        #endregion
    }
}
