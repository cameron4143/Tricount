using System;
using System.Data.SqlClient;

namespace Tricount.DAL
{
    public class PotCommun_DAL
    {
        //Déclaration des entrer de la Base de donnée
        public int ID { get;  set; }
        public DateTime DateSoiree { get; set; }
        public string Lieu { get; set; }

        //Constructeur
        public PotCommun_DAL(int id, DateTime datesoiree, string lieu) 
            => (ID,DateSoiree,Lieu) = (id, datesoiree, lieu);

        public PotCommun_DAL( DateTime datesoiree, string lieu)
            => ( DateSoiree, Lieu) = ( datesoiree, lieu);

        //Insert dans la Base de donnée
        public void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into PotCommun(id,PotCommun,DateSoiree,TitreSoiree,Lieu)"
                                + " values (@id, @PotCommun, @DateSoiree,@TitreSoiree,@Lieu)";
                commande.Parameters.Add(new SqlParameter("@id", ID));
                commande.Parameters.Add(new SqlParameter("@DateSoiree", DateSoiree));
                commande.Parameters.Add(new SqlParameter("@Lieu", Lieu));

                commande.ExecuteNonQuery();
            }
        }
    }
}