using Employee_CRUD.Models;

namespace Employee_CRUD.Interfaces
{
    public interface IOperations
    {

        Task<int> AddJobs(EmpModel.Jobs jobs);
        Task<int> AddDepartment(EmpModel.Departments departments);
        Task DeleteJob(int jobId);
        Task DeleteDepartment(int departmentId);

        Task<List<EmpModel.Departments>> GetDepartmentsAsync();
        Task<List<EmpModel.Jobs>> GetJobsAsync();
    }
}
