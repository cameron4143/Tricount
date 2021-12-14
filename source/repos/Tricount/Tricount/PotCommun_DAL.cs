using System;
using System.Data.SqlClient;

namespace Tricount.DAL
{
    public class PotCommun_DAL
    {
        public int id { get; private set; }
        public DateTime DateSoiree { get; set; }
        public float PotCommun { get; set; }

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into PotCommun(id,PotCommun,DateSoiree)"
                                + " values (@id, @PotCommun, @DateSoiree)";
                commande.Parameters.Add(new SqlParameter("@id", id));
                commande.Parameters.Add(new SqlParameter("@PotCommun", PotCommun));
                commande.Parameters.Add(new SqlParameter("@DateSoiree", DateSoiree));

                commande.ExecuteNonQuery();
            }
        }
    }
}