using Employee_CRUD.Interfaces;
using Employee_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Employee_CRUD.Models.EmpModel;

namespace Employee_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IOperations _operations;

        public SettingsController(IOperations operations)
        {
            _operations = operations;
        }
        #region "Post"
        [HttpPost("AddJobs")]
        public async Task<int> AddJobs(EmpModel.Jobs jobs)
        {
            return await _operations.AddJobs(jobs);
        }
        [HttpPost("AddDepartment")]
        public async Task<int> AddDepartment(EmpModel.Departments departments)
        {
            return await _operations.AddDepartment(departments);
        }
        #endregion

        #region "Get"
        [HttpGet("GetJobsAsync")]
        public async Task<List<Jobs>> GetJobsAsync()
        {
            return await _operations.GetJobsAsync();
        }

        [HttpGet("GetDepartmentsAsync")]
        public async Task<List<Departments>> GetDepartmentsAsync()
        {
            return await _operations.GetDepartmentsAsync();
        }
        #endregion

        #region "Delete"
        [HttpDelete ("DeleteJob/{jobId}")]
        public async Task DeleteJob(int jobId)
        {
            await _operations.DeleteJob(jobId);
        }


        [HttpDelete("DeleteDepartment/{departmentId}")]
        public async Task DeleteDepartment(int departmentId)
        {
            await _operations.DeleteDepartment(departmentId);
        }
        #endregion
    }
}
