using Employee_CRUD.Data;
using Employee_CRUD.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using static Employee_CRUD.Models.EmpModel;

namespace Employee_CRUD.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmpOperaction _emp;
        private readonly IHubContext<MessageHub, IMessageHubClient> _messageHub;

        public EmployeeController(IEmpOperaction emp,
            IHubContext<MessageHub, IMessageHubClient> messageHub)
        {
            _emp = emp;
            _messageHub = messageHub;
        }

        #region "Get"
        
        [HttpGet("GetAllEmpsAsync")]
        public async Task<List<ViewEmp>> GetAllEmpsAsync()
        {
            return await _emp.GetAllEmpsAsync();
        }
        [HttpGet("GetEmpByIdAsync/{empId}")]
        public async Task<List<ViewEmp>> GetEmpByIdAsync(int empId)
        {
            return await _emp.GetEmpByIdAsync(empId);
        }

        #endregion

        #region "Post"
        [HttpPost("AddEmployee")]
        public async Task<int> NewEmpAsync(Models.EmpModel.Emp emp)
        {
            return await _emp.NewEmpAsync(emp);
        }

        //using SignalR
        [HttpPost("SendMessage")]
        public async Task SendMessage(Models.EmpModel.Messages messages)
        {
            await _messageHub.Clients.All.SendMessage(messages);
        }

        #endregion

        #region "Delete"
        [HttpDelete("DeleteEmpAsync/{empId}")]
        public async Task DeleteEmpAsync(int empId)
        {
            await _emp.DeleteEmpAsync(empId);
        }
        #endregion



    }
}
