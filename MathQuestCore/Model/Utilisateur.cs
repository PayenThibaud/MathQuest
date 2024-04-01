using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuestCore.Model
{
    public class Utilisateur
    {
        public int UtilisateurId { get; set; }

        public string Pseudo {  get; set; }
        public int Score { get; set; }
        public List<LeconLu>? LeconLus { get; set;}
    }
}
