using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuestCore.Model
{
    internal class Lecon
    {
        public int LeconId { get; set; }

        public string Titre { get; set; }
        public string Contenu { get; set; }
        public List<LeconLu>? LeconLus { get; set; }
    }
}
