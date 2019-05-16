using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoLP2.Model
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        
        public bool funcionario { get; set; } // usuario normal = false, funcionario = true
    }
}
