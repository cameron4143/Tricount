using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tricount.METIER
{
    class PotCommunCompteMetier
    {

        public int ID { get; set; }
        public int ID_PotCommun { get; set; }
        public int ID_Compte { get; set; }

        public PotCommunCompteMetier(int id, int id_PotCommun, int id_Compte)
        {
            ID = id;
            ID_PotCommun = id_PotCommun;
            ID_Compte = id_Compte;
        }
    }
}
