using System;
using Tricount.DAL;
using Xunit;

namespace PotCommunDepot_DAL_Tests
{
    public class PotCommunDepot_DAL_Tests
    {
        //Ici on va effectuer un test sur Notre Get All
        [Fact]
        public void SoireeDepot_DAL_TesterGetAll()
        {
            var depotsoiree = new PotCommunDepot_DAL();
            var LaSoiree = depotsoiree.GetAll();

            Assert.NotNull(LaSoiree);
        }
        //Ici on va effectuer un test sur Notre Get By ID  qui attrape le compte et ses infos grâce à son ID
        [Fact]
        public void SoireeDepot_DAL_TesterGetByID()
        {
            var depotsoiree = new PotCommunDepot_DAL();
            var LaSoiree = depotsoiree.GetByID(1);

            Assert.NotNull(LaSoiree);
            Assert.Equal(1, LaSoiree.ID);
            Assert.NotEmpty(LaSoiree.Lieu);

        }
        //Cette fois ci on récupère aussi grâce à l'ID mais pas qu'un seul compte, on les récupère TOUS
        [Fact]
        public void SoireeDepot_DAL_TesterGetAllByID()
        {
            var depotsoiree = new PotCommunDepot_DAL();
            var ListingSoiree = depotsoiree.GetAllByID(1);

            Assert.NotNull(ListingSoiree);

            foreach (var LaSoiree in ListingSoiree)
            {
                Assert.Equal(1, LaSoiree.ID);
            }
        }
        //Ici on va tester en 3 étapes l'insère de donnée dans la BDD, la modification et sa suppression
        [Fact]
        public void SoireeDepot_DAL_TesterLInsertLUpdateEtLeDelete()
        {
            //Insère dans la BDD
            var depotsoiree = new PotCommunDepot_DAL();
            var LaSoiree = new PotCommun_DAL(1, DateTime.Now, "Chez Les ZinZin De L'espace");
            depotsoiree.Insert(LaSoiree);
            //Insère n°2 dans la BDD
            var SecondeSoiree = depotsoiree.GetByID(LaSoiree.ID);

            Assert.NotNull(SecondeSoiree);
            Assert.Equal(DateTime.Now, SecondeSoiree.DateSoiree);
            Assert.Equal("Test", SecondeSoiree.Lieu);
            //Modification dans la BDD
            LaSoiree.Lieu = "Chez Oggy et les cafards";
            depotsoiree.Update(LaSoiree);
            SecondeSoiree = depotsoiree.GetByID(LaSoiree.ID);

            Assert.NotNull(SecondeSoiree);
            Assert.Equal("Chez les RATZ", SecondeSoiree.Lieu);
            //Suppression dans la BDD
            depotsoiree.Delete(LaSoiree);
            try
            {
                SecondeSoiree = depotsoiree.GetByID(LaSoiree.ID);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
