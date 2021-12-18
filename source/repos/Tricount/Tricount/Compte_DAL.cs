using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Tricount.DAL
{
    public class Compte_DAL
    {
        public int ID { get;  set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public int id_Soiree { get; set; }

        public Compte_DAL(int id, string prenom, string nom,int id_soiree ) => (ID,Prenom,Nom, id_Soiree)=(id,prenom,nom, id_soiree);

        public Compte_DAL( string prenom, string nom, int id_soiree) => (  Prenom, Nom, id_Soiree) = (  prenom, nom, id_soiree);


        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Compte(id,Prenom,Nom,id_Soiree)"
                                + " values (@id, @Prenom, @Nom, @id_Soiree)";
                commande.Parameters.Add(new SqlParameter("@id", ID));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));
                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@id_Soiree", id_Soiree));

                commande.ExecuteNonQuery();
            }
        }
    }
}