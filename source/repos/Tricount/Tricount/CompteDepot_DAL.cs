using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Tricount.DAL
{
    public class CompteDepot_DAL : Depot_DAL<Compte_DAL>
    {
        public override List<Compte_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, Prenom, Nom, id_Soiree from Compte";
            var reader = commande.ExecuteReader();

            var listeDeCompte = new List<Compte_DAL>();

            while (reader.Read())
            {
                var p = new Compte_DAL(reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3));

                listeDeCompte.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeCompte;
        }

        public override Compte_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, Prenom, Nom,id_Soiree from Compte where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ID));
            var reader = commande.ExecuteReader();

            var listeDeCompte = new List<Compte_DAL>();

            Compte_DAL p;
            if (reader.Read())
            {
                p = new Compte_DAL(reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.GetString(2),
                                    reader.GetInt32(3));
            }
            else
                throw new Exception($"Pas de Compte dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }

        public override Compte_DAL Insert(Compte_DAL compte)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Compte(Prenom, Nom,id_Soiree)"
                                    + " values (@Prenom, @Nom,@id_Soiree); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@Prenom", compte.Prenom));
            commande.Parameters.Add(new SqlParameter("@Nom", compte.Nom));
            commande.Parameters.Add(new SqlParameter("@id_Soiree", compte.id_Soiree));

            var id = Convert.ToInt32((decimal)commande.ExecuteScalar());

            compte.ID = id;

            DetruireConnexionEtCommande();

            return compte;
        }

        public override Compte_DAL Update(Compte_DAL compte)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Compte set Prenom=@Prenom, Nom=@Nom, pseudo=@pseudo Argent=@Argent)"
                                    + " where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", compte.ID));
            commande.Parameters.Add(new SqlParameter("@Prenom", compte.Prenom));
            commande.Parameters.Add(new SqlParameter("@Nom", compte.Nom));
            commande.Parameters.Add(new SqlParameter("@id_Soiree", compte.id_Soiree));

            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour le point d'ID {compte.ID}");
            }

            DetruireConnexionEtCommande();

            return compte;
        }

        public override void Delete(Compte_DAL compte)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Compte where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", compte.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer le point d'ID {compte.ID}");
            }

            DetruireConnexionEtCommande();
        }
    }
}
