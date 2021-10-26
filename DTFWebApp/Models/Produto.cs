using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTFWebApp.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public string marca { get; set; }
        public string categoria { get; set; }
        public string tamanho { get; set; }
        public string descricao { get; set; }
        public int quantidade { get; set; }
        public double valor { get; set; }
        public string imagem { get; set; }
        public bool status { get; set; }
    }
}
