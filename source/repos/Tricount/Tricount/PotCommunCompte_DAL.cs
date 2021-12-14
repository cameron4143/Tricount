using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tricount.DAL
{
    class PotCommunCompte_DAL
    {

        public int id { get; private set; }
        public int id_PotCommun { get; set; }
        public int id_Compte { get; set; }


        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into PotCommunCompte(id,id_Compte,id_PotCommun)"
                                + " values (@id, @id_Compte, @id_PotCommun)";
                commande.Parameters.Add(new SqlParameter("@id", id));
                commande.Parameters.Add(new SqlParameter("@id_Compte", id_Compte));
                commande.Parameters.Add(new SqlParameter("@id_PotCommun", id_PotCommun));

                commande.ExecuteNonQuery();
            }
        }
    }
}
