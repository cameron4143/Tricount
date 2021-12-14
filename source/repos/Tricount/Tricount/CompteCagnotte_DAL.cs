using System;
using System.Data.SqlClient;

namespace Tricount.DAL
{
    class CompteCagnotte_DAL
    {
        public int id { get; private set; }
        public int id_Compte { get; set; }
        public int id_Cagnotte { get; set; }


        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into CompteCagnotte(id,id_Compte,id_Cagnotte)"
                                + " values (@id, @id_Compte, @id_Cagnotte)";
                commande.Parameters.Add(new SqlParameter("@id", id));
                commande.Parameters.Add(new SqlParameter("@id_Compte", id_Compte));
                commande.Parameters.Add(new SqlParameter("@id_Cagnotte", id_Cagnotte));

                commande.ExecuteNonQuery();
            }
        }

    }
}
