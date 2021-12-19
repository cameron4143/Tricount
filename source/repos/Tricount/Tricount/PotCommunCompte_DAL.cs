using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tricount.DAL
{
    public class PotCommunCompte_DAL
    {
        //Déclaration des entrer de la Base de donnée
        public int ID { get;  set; }
        public int id_PotCommun { get; set; }
        public int id_Compte { get; set; }
        public double Montant { get; set; }

        //Constructeur
        public PotCommunCompte_DAL(int id, double montant,int id_potcommun, int id_compte)
           => (ID, Montant, id_PotCommun, id_Compte ) = (id, montant,id_potcommun, id_compte);

        public PotCommunCompte_DAL( double montant, int id_potcommun, int id_compte)
           => ( Montant, id_PotCommun, id_Compte) = ( montant, id_potcommun, id_compte);


        //Insert dans la Base de donnée
        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into PotCommunCompte(id,Montant,id_Compte,id_PotCommun)"
                                + " values (@id,@Montant, @id_Compte, @id_PotCommun)";
                commande.Parameters.Add(new SqlParameter("@id", ID));
                commande.Parameters.Add(new SqlParameter("@Montant", Montant));
                commande.Parameters.Add(new SqlParameter("@id_Compte", id_Compte));
                commande.Parameters.Add(new SqlParameter("@id_PotCommun", id_PotCommun));

                commande.ExecuteNonQuery();
            }
        }
    }
}
