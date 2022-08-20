using Employee_CRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace Employee_CRUD.Interfaces
{
    public interface ILogin
    {
        Task<LoginModel.AuthenticatedResponse> UserAccessLogin(LoginModel login);
    }
}
