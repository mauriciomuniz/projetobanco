using System;
using projetobanco;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Usuario ValidacaoConta()
        {
            Console.WriteLine("Informe o cpf:");
            long cpfmanipula = int.Parse(Console.ReadLine());
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
            Console.WriteLine(u.ToString());

            return u;
        }

        

        
        /* tratar algumas excessões
           -feitas para cpf invalidos, saques,depositos, contas inexistentes 
        */
        //se possivel algoritmo de cpf

        //falta transferência

        public void Sacando(Usuario logado)
        {
            Console.WriteLine("Digite a quantia que deseja sacar:");
            double saque = double.Parse(Console.ReadLine());
            logado.Sacar(saque);
            
        }

        public void Depositando(Usuario logado)
        {
            Console.WriteLine("Digite a quantia que deseja depositar:");
            double deposito = double.Parse(Console.ReadLine());
            logado.Depositar(deposito);
            
        }

        public void Transferindo(Usuario logado)
        {
            Console.WriteLine("Informe o cpf destino:");
            long cpfdestino = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantia que deseja transferir:");
            double transferir = double.Parse(Console.ReadLine());
            
        }
    }
}