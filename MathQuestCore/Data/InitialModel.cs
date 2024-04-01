using MathQuestCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathQuestCore.Data
{
    internal class InitialModel
    {
        public static readonly List<Utilisateur> Utilisateurs = new List<Utilisateur>()
        {
            new Utilisateur
            {
                UtilisateurId = 1,
                Pseudo = "Dupont",
                Score = 3

            },
            new Utilisateur
            {
                UtilisateurId = 2,
                Pseudo = "Duti",
                Score = 0

            },
        };

        public static readonly List<Lecon> Lecons = new List<Lecon>()
        {
            new Lecon
            {
                LeconId = 1,
                Titre = "Test1",
                Contenu = "Test numero 1"
            },
            new Lecon
            {
                LeconId = 2,
                Titre = "Test2",
                Contenu = "Test numero 2"
            },
        };
    }
}
