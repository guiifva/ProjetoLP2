using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLP2.Model
{
    class Ticket
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public DateTime data { get; set; }
        public int prioridade { get; set; } // 1 Baixa, 2 Normal, 3 Alta
        public string status { get; set; }
       
    }
}
