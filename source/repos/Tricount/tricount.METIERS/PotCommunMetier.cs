using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tricount.METIER
{
    class PotCommunMetier
    {

       
        public int ID { get; set; }
        public DateTime soiree { get; set; }
        public float cagnotte { get; set; }

        public PotCommunMetier(int id, DateTime DateSoiree, float PotCommun)
        {
            ID = id;
            soiree = DateSoiree;
            cagnotte = PotCommun;
        }
    }
}
