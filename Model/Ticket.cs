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
        public DateTime data { get; set; }
        public string categoria { get; set; }
        public string software { get; set; }
        public string prioridade { get; set; }
        public string descricao { get; set; }
        public string responsavel { get; set; }
        public string msgErro { get; set; }

    }
}
