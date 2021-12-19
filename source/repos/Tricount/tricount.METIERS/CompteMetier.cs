using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tricount.METIERS
{
    class CompteMetier
    {
        
        public int ID { get; set; }
        public string nametag { get; set; }
        public string prenom { get; set; }
        public string nom { get; set; }

        
        public CompteMetier(int id, string pseudo, string Prenom, string Nom)
        {
            ID = id;
            nametag = pseudo;
            prenom = Prenom;
            nom = Nom;
        }
    }
}
