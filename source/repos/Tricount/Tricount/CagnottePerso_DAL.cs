using System;
using System.Data.SqlClient;

namespace Tricount.DAL
{
    public class CagnottePerso_DAL
    {
        public int id { get; private set; }
        public float Argent { get; set; }
        

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into CagnottePerso(id,Argent)"
                                + " values (@id, @Argent)";
                commande.Parameters.Add(new SqlParameter("@id", id));
                commande.Parameters.Add(new SqlParameter("@Argent", Argent));

                commande.ExecuteNonQuery();
            }
        }
    }
}