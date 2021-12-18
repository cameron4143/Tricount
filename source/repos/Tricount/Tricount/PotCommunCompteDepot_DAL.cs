using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount
{
    public class PotCommunCompteDepot_DAL : Depot_DAL<PotCommunCompte_DAL>
    {

        public override List<PotCommunCompte_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, Montant,id_PotCommun, id_Compte";
            var reader = commande.ExecuteReader();

            var listeDeCompte = new List<PotCommunCompte_DAL>();

            while (reader.Read())
            {
                var p = new PotCommunCompte_DAL(reader.GetInt32(0),
                                    reader.GetDouble(1),
                                    reader.GetInt32(2),
                                    reader.GetInt32(3));

                listeDeCompte.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeCompte;
        }

        public override PotCommunCompte_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id,Montant, id_PotCommun, id_Compte from PotCommunCompte where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var listeDeCompte = new List<PotCommunCompte_DAL>();

            PotCommunCompte_DAL p;
            if (reader.Read())
            {
                p = new PotCommunCompte_DAL(reader.GetInt32(0),
                                    reader.GetDouble(1),
                                    reader.GetInt32(2),
                                    reader.GetInt32(3));
            }
            else
                throw new Exception($"Rien dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }

        public override PotCommunCompte_DAL Insert(PotCommunCompte_DAL PotCommun)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into PotCommunCompte(id,Montant, id_Compte, id_PotCommun)"
                                    + " values (@id,@Montant, @id_Compte, @id_PotCommun); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@id", PotCommun.ID));
            commande.Parameters.Add(new SqlParameter("@Montant", PotCommun.Montant));
            commande.Parameters.Add(new SqlParameter("@id_Compte", PotCommun.id_Compte));
            commande.Parameters.Add(new SqlParameter("@id_PotCommun", PotCommun.id_PotCommun));

            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            PotCommun.ID = id;

            DetruireConnexionEtCommande();

            return PotCommun;
        }

        public override PotCommunCompte_DAL Update(PotCommunCompte_DAL PotCommun)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Compte set  Montant=@Montant, id_Compte=@id_Compte, id_PotCommun=@id_PotCommun)"
                                    + " where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", PotCommun.ID));
            commande.Parameters.Add(new SqlParameter("@Montant", PotCommun.Montant));
            commande.Parameters.Add(new SqlParameter("@id_PotCommun", PotCommun.id_PotCommun));
            commande.Parameters.Add(new SqlParameter("@id_Compte", PotCommun.id_Compte));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour l'ID {PotCommun.ID}");
            }

            DetruireConnexionEtCommande();

            return PotCommun;
        }

        public override void Delete(PotCommunCompte_DAL PotCommun)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Compte where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", PotCommun.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le l'ID {PotCommun.ID}");
            }

            DetruireConnexionEtCommande();
        }

    }

}