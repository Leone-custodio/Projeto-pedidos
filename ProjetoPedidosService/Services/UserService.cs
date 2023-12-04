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

        public CommandResult Create(User user)
        {
            if (CheckCpf(user.CPF) == false & IsCpf(user.CPF))
            {
                _repository.Create(user);

                return new CommandResult(true, "Usuário cadastrado com sucesso !", new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.CPF
                });
            }
            else
            {
                return new CommandResult(false, $"O cpf {user.CPF} está em uso ou inválido !", false);
            }
        }

        public CommandResult Delete(string? id)
        {
            var user = _repository.GetById(id);
            if (user == null)
            {
                return new CommandResult(false, $"O usuário id = {id} não existe no banco de dados", false);
            }
            else
            {
                _repository.Delete(id);

                return new CommandResult(true, $"Usuário {user.Name} excluído com sucesso!", null);
            }
        }

        public CommandResult GetAll()
        {
            var result = _repository.GetAll();
            if (result.Count == 0)
            {
                return new CommandResult(true, "Não tem usuários cadastrados no sistema no momento", result);
            }
            else 
            {
                return new CommandResult(true, "Busca realizada com sucesso!", result);
            }
        }

        public CommandResult GetById(string id)
        {
            var user = _repository.GetById(id);

            if (user == null)
            {
                return new CommandResult(false, $"Usuário id {id} não existe no banco de dados !", false);
            }
            else
            {
                return new CommandResult(true, "Usuário encontrado com sucesso!", new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.CPF
                });
            }
        }

        public CommandResult Update(string id, User user)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return new CommandResult(false, $"O usuário id = {id} não existe no banco de dados", false);
            }
            else
            {
                _repository.Update(id, user);

                return new CommandResult(true, $"Usuário {user.Name} atualizado com sucesso!", new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.CPF
                });
            }
        }

        private bool CheckCpf(string cpf)
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
