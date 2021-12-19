using System;
using Xunit;
using Tricount.DAL;


namespace Tricount.DAL.Tests
{
    public class PotCommunCompteDepot_DAL_Tests
    {
        //Ici on va effectuer un test sur Notre Get All
        [Fact]
        public void PrixDepot_DAL_TesterGetAll()
        {
            var DepotComptePotCommun = new PotCommunCompteDepot_DAL();
            var MontantTest = DepotComptePotCommun.GetAll();

            Assert.NotNull(MontantTest);
        }
        //Ici on va effectuer un test sur Notre Get By ID  qui attrape le compte et ses infos grâce à son ID
        [Fact]
        public void PrixDepot_DAL_TesterGetByID()
        {
            var DepotComptePotCommun = new PotCommunCompteDepot_DAL();
            var MontantTest = DepotComptePotCommun.GetByID(1);

            Assert.NotNull(MontantTest);
            Assert.Equal(1, MontantTest.ID);


        }
        //Cette fois ci on récupère aussi grâce à l'ID mais pas qu'un seul compte, on les récupère TOUS
        [Fact]
        public void PrixDepot_DAL_TesterGetAllByID()
        {
            var DepotComptePotCommun = new PotCommunCompteDepot_DAL();
            var ListeMontant = DepotComptePotCommun.GetAllByID(1);

            Assert.NotNull(ListeMontant);

            foreach (var MontantTest in ListeMontant)
            {
                Assert.Equal(1, MontantTest.id_PotCommun);
            }
        }
        //Ici on va tester en 3 étapes l'insère de donnée dans la BDD, la modification et sa suppression
        [Fact]
        public void PrixDepot_DAL_TesterInsertUpdateDelete()
        {
            //Insère dans la BDD
            var DepotComptePotCommun = new PotCommunCompteDepot_DAL();
            var MontantTest = new PotCommunCompte_DAL(montant: 14, 1, 1);
            DepotComptePotCommun.Insert(MontantTest);
            //Insère n°2 dans la BDD
            var SecondMontant = DepotComptePotCommun.GetByID(MontantTest.ID);

            Assert.NotNull(SecondMontant);
            Assert.Equal(14, SecondMontant.Montant);
            Assert.Equal(1, SecondMontant.id_Compte);
            Assert.Equal(1, SecondMontant.id_PotCommun);

            //Modification dans la BDD
            MontantTest.Montant = 17;
            DepotComptePotCommun.Update(MontantTest);
            SecondMontant = DepotComptePotCommun.GetByID(MontantTest.ID);

            Assert.NotNull(SecondMontant);
            Assert.Equal(17, MontantTest.Montant);
            //Suppression dans la BDD
            DepotComptePotCommun.Delete(MontantTest);

            try
            {
                SecondMontant = DepotComptePotCommun.GetByID(MontantTest.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


        }

    }
}
