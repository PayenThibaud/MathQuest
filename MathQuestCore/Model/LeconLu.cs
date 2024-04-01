using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuestCore.Model
{
    internal class LeconLu
    {
        public int UtilisateurId { get; set; }
        public Utilisateur? Utilisateur { get; set; }

        public int LeconId { get; set; }
        public Lecon? Lecon { get; set; }
    }
}
