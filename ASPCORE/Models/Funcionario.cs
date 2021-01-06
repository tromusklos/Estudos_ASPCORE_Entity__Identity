using System.Security.Cryptography.X509Certificates;
using System;

namespace ASPCORE.Models
{
    public class Funcionario
    {
        public int Id{get; set;}
        public string Nome{get;set;}
        public float Salario{get;set;}
        public string Cpf{get;set;}
    }
}