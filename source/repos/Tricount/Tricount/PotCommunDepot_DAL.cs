using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tricount.DAL
{
    public class PotCommunDepot_DAL : Depot_DAL<PotCommun_DAL>
    {

        public override List<PotCommun_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, DateSoiree, Lieu from PotCommun";
            var reader = commande.ExecuteReader();

            var listeDePotCommun = new List<PotCommun_DAL>();

            while (reader.Read())
            {
                var p = new PotCommun_DAL(reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetString(2));

                listeDePotCommun.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDePotCommun;
        }

        public override PotCommun_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, DateSoiree, Lieu from PotCommun where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var listeDePotCommun = new List<PotCommun_DAL>();

            PotCommun_DAL p;
            if (reader.Read())
            {
                p = new PotCommun_DAL(reader.GetInt32(0),
                                    reader.GetDateTime(1),
                                    reader.GetString(2));
            }
            else
                throw new Exception($"Pas de Pot commun dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }

        public override PotCommun_DAL Insert(PotCommun_DAL PotCommun)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into PotCommun(DateSoiree, Lieu)"
                                    + " values ( @DateSoiree, @Lieu); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@DateSoiree", PotCommun.DateSoiree));
            commande.Parameters.Add(new SqlParameter("@Lieu", PotCommun.Lieu));

            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            PotCommun.ID = id;

            DetruireConnexionEtCommande();

            return PotCommun;
        }

        public override PotCommun_DAL Update(PotCommun_DAL potCommun)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update PotCommun set DateSoiree=@DateSoiree, Lieu=@Lieu)"
                                    + " where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", potCommun.ID));
            commande.Parameters.Add(new SqlParameter("@DateSoiree", potCommun.DateSoiree));
            commande.Parameters.Add(new SqlParameter("@Lieu", potCommun.Lieu));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le Pot commun d'ID { potCommun.ID}");
            }

            DetruireConnexionEtCommande();

            return potCommun;
        }

        public override void Delete(PotCommun_DAL potCommun)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from PotCommun where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", potCommun.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le Pot Commun d'ID {potCommun.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
