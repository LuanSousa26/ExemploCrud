using System;

namespace ExemploCrud
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; }
        public string EmailCliente { get; set; }
        public string CPF { get; set; } 
        public System.DateTime DataCadastro{get;set;}
    }
}