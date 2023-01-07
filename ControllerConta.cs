using System;
using projetobanco;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace projetobanco
{

    public class ControllerConta
    {
        private List<Usuario> usuarios;
        
        
        public ControllerConta()
        {
            usuarios = new List<Usuario>();
            
        }

        public Usuario RegistrarNovoUsuario(long cpf, string titular, string senha, double saldo )
        {   
            Usuario usuario = new Usuario(cpf,titular,senha,saldo);
            usuarios.Add(usuario);
            return usuario;
       
        }

        public void DeletarUsuario(long buscacpf)
        {
            
            Usuario u = usuarios.Find(x=>x.Cpf == buscacpf);
            usuarios.Remove(u);
            while(u==null)
            {
                Console.WriteLine("Usuário não encontrado.");
                Console.WriteLine("Digite novamente o cpf do usuário que vc quer deletar:");
                buscacpf = long.Parse(Console.ReadLine()); 
                u = usuarios.Find(x=>x.Cpf == buscacpf);
                usuarios.Remove(u); 
            }
            Console.WriteLine($"O usuário com o cpf: {u.Cpf} foi deletado");
        }

        public void ListarTodasAsContas()
        {
            foreach(Usuario obj in usuarios)
            {
                Console.WriteLine(obj.ToString());
            }
        }
        
        public void DetalhesUsuario(long buscacpf2)
        {
            Usuario u = usuarios.Find(x=>x.Cpf == buscacpf2);
            
            while(u==null)
            {
               Console.WriteLine("Usuário não encontrado.");
               Console.WriteLine("Digite novamente o cpf do usuário que vc quer buscar:"); 
               buscacpf2 = long.Parse(Console.ReadLine());
               u = usuarios.Find(x=>x.Cpf == buscacpf2);
               u.ToString();
            }
            Console.WriteLine(u.ToString());
        }

        public void TotalBanco()
        {
            double total=0;
            foreach(Usuario obj in usuarios)
            {
                total+=obj.Saldo;
            }

            Console.WriteLine($"total no banco é: {total:F2}");
            Console.WriteLine();
        }


        public long CPFigual(long cpf)
        {
            Usuario u = usuarios.Find(x=>x.Cpf == cpf);
            
            while(u!=null)
            {
               Console.WriteLine("Usuário já existente.");
               Console.WriteLine("Digite um novo cpf:"); 
               cpf = long.Parse(Console.ReadLine());
               u = usuarios.Find(x=>x.Cpf == cpf);
               
            }
            return cpf;
        }

        public long CPFvalido(String cpf)
        {
            
            //Regex regex = new Regex(@"([0-9]{11}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})",RegexOptions.IgnoreCase);
            Regex regex = new Regex(@"([0-9]{11})",RegexOptions.IgnoreCase);

            var combinou = regex.Match(cpf);
            
            while(!combinou.Success)
            {
                Console.WriteLine("CPF inválido.");
                Console.Write("Informe um cpf para validação(somente numeros): ");
                cpf = Console.ReadLine();
                // regex = new Regex(@"([0-9]{11}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})",RegexOptions.IgnoreCase);
                regex = new Regex(@"([0-9]{11})",RegexOptions.IgnoreCase);
                combinou = regex.Match(cpf);
                
            }
            
           return long.Parse(cpf);
        }

        public Usuario ValidacaoConta()
        {
            Console.WriteLine("Informe o cpf:");
            long cpfmanipula = long.Parse(Console.ReadLine());
            Console.WriteLine("Informe a senha:");
            string senhamanipula = Console.ReadLine();
            Usuario u = usuarios.Find(x=>x.Cpf == cpfmanipula && x.Senha ==senhamanipula );
            
            while(u==null)
            {
               Console.WriteLine("Usuário não encontrado.");
               Console.WriteLine("Digite novamente os dados correntamente"); 
               Console.WriteLine("Digite o cpf"); 
               cpfmanipula = long.Parse(Console.ReadLine());
               Console.WriteLine("Informe a senha:");
               senhamanipula = Console.ReadLine();
               u = usuarios.Find(x=>x.Cpf == cpfmanipula && x.Senha ==senhamanipula );
               u.ToString();

               
            }
            Console.WriteLine();
            Console.WriteLine(u.ToString());

            return u;
        }

        public Usuario DestinoValido()
        {
            Console.WriteLine("Informe o cpf:");
            long cpfdestino = long.Parse(Console.ReadLine());
            Usuario u = usuarios.Find(x=>x.Cpf == cpfdestino);
            
            while(u==null)
            {
               Console.WriteLine("Usuário não encontrado.");
               Console.WriteLine("Digite novamente os dados correntamente"); 
               Console.WriteLine("Digite o cpf"); 
               cpfdestino = long.Parse(Console.ReadLine());
               u = usuarios.Find(x=>x.Cpf == cpfdestino);
               u.ToString();
               
            }
            Console.WriteLine();
            Console.WriteLine(u.ToString());

            return u;
        }

        
        /* tratar algumas excessões
           -FEITO para cpf igual, saque,deposito,transferencia,
           -FEITO cpf invalido em buscas
           -FEITO cpf 11 digitos
        */
        //se possivel algoritmo de cpf


        public void Sacando(Usuario logado)
        {
            Console.WriteLine("Digite a quantia que deseja sacar:");
            double saque = double.Parse(Console.ReadLine());
            logado.Sacar(saque);

            if(saque <= logado.Saldo)
            {
                Console.WriteLine($"A conta do cpf {logado.Cpf} sacou um valor de {saque:F2}");
            }
            
        }

        public void Depositando(Usuario logado)
        {
            Console.WriteLine("Digite a quantia que deseja depositar:");
            double deposito = double.Parse(Console.ReadLine());
            logado.Depositar(deposito);
            Console.WriteLine($"A conta do cpf {logado.Cpf} depositou um valor de {deposito:F2}");
            
        }

        public void Transferindo(Usuario logado,Usuario contadestino, double valorTransferir)
        {
           
            logado.Sacar(valorTransferir);
            if(valorTransferir <= logado.Saldo)
            {
                contadestino.Depositar(valorTransferir);
                Console.WriteLine($"A conta do cpf {logado.Cpf} transferiu um valor de {valorTransferir:F2} na conta {contadestino.Cpf}");
            }
            
            
        }
    }
}