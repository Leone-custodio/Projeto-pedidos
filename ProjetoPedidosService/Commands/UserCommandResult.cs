using ProjetoPedidosDomain.Models;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Commands
{
    public class UserCommandResult :IUserCommandResult
    {
        public bool Success { get; set; }
        public string? Message { get; set; }

        public static UserResult Result(bool success, string? message,User? user) 
        {
            return new UserResult {  Success = success, Message = message, User = user };
        }
        
        public static UserListResult ResultList(bool success, string? message, List<User>? users) 
        {
            return new UserListResult {  Success = success, Message = message, Users = users };
        }
    }

    public class UserResult : UserCommandResult
    {
        public User? User { get; set; }
    }

    public class UserListResult : UserCommandResult
    {
        public List<User>? Users { get; set; }
    }
}
