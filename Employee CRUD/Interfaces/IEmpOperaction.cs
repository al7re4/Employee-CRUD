using Employee_CRUD.Models;

namespace Employee_CRUD.Interfaces
{
    public interface IEmpOperaction
    {
        Task<int> NewEmpAsync(EmpModel.Emp emp);
        Task DeleteEmpAsync(int empId);
   


        Task<List<EmpModel.ViewEmp>> GetAllEmpsAsync();
        Task<List<EmpModel.ViewEmp>> GetEmpByIdAsync(int empId);
       
    }
}
