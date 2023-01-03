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

        public Usuario RegistrarNovoUsuario(int cpf, string titular, string senha, double saldo )
        {   
            Usuario usuario = new Usuario(cpf,titular,senha,saldo);
            usuarios.Add(usuario);
            return usuario;
       
        }

        public void DeletarUsuario(int buscacpf)
        {
            
            Usuario u = usuarios.Find(x=>x.Cpf == buscacpf);
            usuarios.Remove(u);
            while(u==null)
            {
                Console.WriteLine("Usuário não encontrado.");
                Console.WriteLine("Digite novamente o cpf do usuário que vc quer deletar:");
                buscacpf = int.Parse(Console.ReadLine()); 
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
        
        public void DetalhesUsuario(int buscacpf2)
        {
            Usuario u = usuarios.Find(x=>x.Cpf == buscacpf2);
            
            while(u==null)
            {
               Console.WriteLine("Usuário não encontrado.");
               Console.WriteLine("Digite novamente o cpf do usuário que vc quer buscar:"); 
               buscacpf2 = int.Parse(Console.ReadLine());
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
        }

        public void ValidarCPF()
        {
            foreach(Usuario obj in usuarios)
            {
                //se o cpf passado bater com o cpf de algum usuário
                //apresentar mensagem invalida e pede um cpf valido

                //tratar excessões

                //se possivel algoritmo de cpf

                //manipular conta
            }
        }

        public void Sacando()
        {

        }

        public void Depositando()
        {

        }

        public void Transferindo()
        {
            
        }
    }
}