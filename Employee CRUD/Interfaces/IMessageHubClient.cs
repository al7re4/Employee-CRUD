using Employee_CRUD.Models;

namespace Employee_CRUD.Interfaces
{
    public interface IMessageHubClient
    {
        Task SendMessage(EmpModel.Messages messages);
    }
}
