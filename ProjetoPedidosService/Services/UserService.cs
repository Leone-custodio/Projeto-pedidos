using ProjetoPedidosDomain.Models;
using ProjetoPedidosInfra.Interfaces;
using ProjetoPedidosService.Commands;
using ProjetoPedidosService.Interfaces;

namespace ProjetoPedidosService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public UserCommandResult Create(User user)
        {
            if (CheckCpf(user.CPF) == false & IsCpf(user.CPF))
            {
                _repository.Create(user);

                return UserCommandResult.Result(true, $"Usuário {user.Name} cadastrado com sucesso !", user);
            }
            else
            {
                return UserCommandResult.Result(false, "Erro ao cadastrar o usuário favor verificar os seus dados !", null);
            }
        }

        public UserCommandResult Delete(string id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return UserCommandResult.Result(false, $"O usuário id = {id} não existe no banco de dados", null);
            }
            else
            {
                _repository.Delete(id);

                return UserCommandResult.Result(true, $"Usuário {user.Name} excluído com sucesso!", null);
            }
        }

        public UserCommandResult GetAll()
        {
            var result = _repository.GetAll();
            if (result.Count == 0)
            {
                return UserCommandResult.ResultList(true, "Não tem usuários cadastrados no sistema no momento", result);
            }
            else
            {
                return UserCommandResult.ResultList(true, "Busca realizada com sucesso!", result);
            }
        }

        public UserCommandResult GetByCpf(string cpf)
        {
            var user = _repository.GetByCpf(cpf);

            if (user == null)
            {
                return UserCommandResult.Result(false, $"Usuário id {cpf} não existe no banco de dados !", null);
            }
            else
            {
                return UserCommandResult.Result(true, "Usuário encontrado com sucesso!", user);
            }
        }

        public UserCommandResult Update(string id, User user)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return UserCommandResult.Result(false, $"O usuário id = {id} não existe no banco de dados", null);
            }
            else
            {
                _repository.Update(id, user);

                return UserCommandResult.Result(true, $"Usuário {user.Name} atualizado com sucesso!", user);
            }
        }

        public UserCommandResult GetPassword(string cpf, string password)
        {
            var user = _repository.GetByCpf(cpf);

            if(user == null) 
            {
                return UserCommandResult.Result(false, $"O usuário cpf = {cpf} não existe no banco de dados", null);
            }

            if (password != user.Password) 
            {
                return UserCommandResult.Result(false, "Senha inválida, digite novamente", null);
            }

            return UserCommandResult.Result(true, $"Bem vindo {user.Name} !!!", user);
        }

        public UserCommandResult UpdatePassword(string? cpf, string? password, string? newPassword)
        {
            var user = _repository.GetByCpf(cpf);

            if (user == null)
            {
                return UserCommandResult.Result(false, $"O usuário cpf = {cpf} não existe no banco de dados", null);
            }

            if (password != user.Password)
            {
                return UserCommandResult.Result(false, "Senha atual inválida, digite novamente", null);
            }

            if (newPassword == password)
            {
                return UserCommandResult.Result(false, "Erro ao atualizar a senha, a nova senha não pode ser igual a senha antiga", null);
            }

            user.Password = newPassword;
            var newUser = _repository.Update(user.Id, user);

            return UserCommandResult.Result(true, "Senha atualizada com sucesso", newUser);
        }

        private bool CheckCpf(string? cpf)
        {
            var result = _repository.GetByCpf(cpf);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        private static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;

            for (int j = 0; j < 10; j++)
                if (j.ToString().PadLeft(11, char.Parse(j.ToString())) == cpf)
                    return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
      
    }
}
