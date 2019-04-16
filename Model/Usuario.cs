using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLP2.Model
{
    class Usuario
    {
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int id { get; set; }
        public bool funcionario { get; set; } // usuario normal = false, funcionario = true
    }
}
