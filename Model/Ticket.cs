using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Model
{
    class Ticket
    {
        public int ticketId { get; set; }
        public string usuario { get; set; }
        public string data { get; set; }
        public string categoria { get; set; }
        public string software { get; set; }
        public int prioridade { get; set; } // 0 - Baixa 1 - media 2 - alta
        public string descricao { get; set; }
        public string setor { get; set; }
        public string msgErro { get; set; }
        public int status { get; set; } // 0 - em andamento / 1 - concluido
    }
}
