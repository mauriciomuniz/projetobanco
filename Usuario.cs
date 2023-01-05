using System;
using projetobanco;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projetobanco
{

    public class Usuario
    {
        public long Cpf{get;set;}
        public string Titular{get;set;}
        public string Senha{get;set;}
        public double Saldo{get;set;}
        
        

        public Usuario(long cpf, string titular, string senha, double saldo )
        {
            this.Cpf=cpf;
            this.Titular=titular;
            this.Senha=senha;
            this.Saldo=saldo;
        }

        public Double VerSaldo()
        {
            return Saldo;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine($"A conta do cpf {Cpf} depositou um valor de {valor:F2}");
        }
        public void Sacar(double valor)
        {   
            if(valor <= Saldo)
            {
                Saldo -= valor;
                Console.WriteLine($"A conta do cpf {Cpf} sacou um valor de {valor:F2}");
            }
            else
            {
                Console.WriteLine("Saque não pode ser realizado. Saldo insuficiente");
            }
            
        }

        public override string ToString()
        {
            return $"cpf: {Cpf}\ntitular: {Titular}\nsaldo: {Saldo:F2}\n";
        }

    }
}