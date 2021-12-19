using System;
using Xunit;
using Tricount.DAL;

namespace Tricount.DAL.Tests
{
    public class CompteDepot_DAL_Tests
    {
        //Ici on va effectuer un test sur Notre Get All 
        [Fact]
        public void PersonneDepot_DAL_TesterLeGetAll()
        {
            var DepotCompte = new CompteDepot_DAL();
            var UnEtreHumain = DepotCompte.GetAll();

            Assert.NotNull(UnEtreHumain);
        }
        //Ici on va effectuer un test sur Notre Get By ID  qui attrape le compte et ses infos grâce à son ID
        [Fact]
        public void PersonneDepot_DAL_TesterLeGetByID()
        {
            var DepotCompte = new CompteDepot_DAL();
            var UnEtreHumain = DepotCompte.GetByID(1);

            Assert.NotNull(UnEtreHumain);
            Assert.Equal(1, UnEtreHumain.ID);
            Assert.NotEmpty(UnEtreHumain.Nom);
            Assert.NotEmpty(UnEtreHumain.Prenom);
        }
        //Cette fois ci on récupère aussi grâce à l'ID mais pas qu'un seul compte, on les récupère TOUS
        [Fact]
        public void PersonneDepot_DAL_TesterLeGetAllByID()
        {
            var DepotCompte = new CompteDepot_DAL();
            var ListeEtreHumain = DepotCompte.GetAllByID(1);

            Assert.NotNull(ListeEtreHumain);

            foreach (var UnEtreHumain in ListeEtreHumain)
            {
                Assert.Equal(1, UnEtreHumain.id_Soiree);
            }
        }
        //Ici on va tester en 3 étapes l'insère de donnée dans la BDD, la modification et sa suppression
        [Fact]
        public void PersonneDepot_DAL_TesterInsertUpdateDelete()
        {
            //Insère dans la BDD
            var DepotCompte = new CompteDepot_DAL();
            var UnEtreHumain = new Compte_DAL("Alain", "Térieur");
            DepotCompte.Insert(UnEtreHumain);
            //Insère n°2 dans la BDD
            var UnSecondEtreHumain = DepotCompte.GetByID(UnEtreHumain.ID);


            Assert.NotNull(UnSecondEtreHumain);
            Assert.Equal("CLENCHE", UnSecondEtreHumain.Nom);
            Assert.Equal("JEAN", UnSecondEtreHumain.Prenom);
            //Modification dans la BDD
            UnEtreHumain.Nom = "Provist";
            DepotCompte.Update(UnEtreHumain);
            UnSecondEtreHumain = DepotCompte.GetByID(UnEtreHumain.ID);

            Assert.NotNull(UnSecondEtreHumain);
            Assert.Equal("Némard", UnSecondEtreHumain.Nom);
            Assert.Equal("Jean", UnSecondEtreHumain.Prenom);
            //Suppression dans la BDD
            DepotCompte.Delete(UnEtreHumain);

            try
            {
                UnSecondEtreHumain = DepotCompte.GetByID(UnEtreHumain.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
