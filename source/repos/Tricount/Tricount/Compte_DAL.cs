using System;
using System.Data.SqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace Tricount.DAL
{
    public class Compte_DAL
    {
        public int id { get; private set; }
        public string pseudo { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public Image PP;

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Compte(id,pseudo,Prenom,Nom,PP)"
                                + " values (@id, @pseudo, @Prenom, @Nom, @PP)";
                commande.Parameters.Add(new SqlParameter("@id", id));
                commande.Parameters.Add(new SqlParameter("@pseudo", pseudo));
                commande.Parameters.Add(new SqlParameter("@Prenom", Prenom));
                commande.Parameters.Add(new SqlParameter("@Nom", Nom));
                commande.Parameters.Add(new SqlParameter("@PP", PP));

                commande.ExecuteNonQuery();
            }
        }
    }
}