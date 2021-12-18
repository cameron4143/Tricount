using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Consoles
{
    public class ConsoleTricount
    {
        //int TousLesParticipantsRentrer;
        //public PotCommun_DAL entrer_infos() 
        //{
        //    Console.WriteLine("Entrez le lieu de la soiree : ");
        //    string Lieu = Console.ReadLine();
            
        //    Console.WriteLine("Maintenant Donner un Titre à la Soiree");
        //    string TitreSoiree = Console.ReadLine();
        //    int ParticipantsRentrer = 0;
        //    string pseudo;
        //    string Prenom;
        //    string Nom;
        //    double Argent;
        //    var Comptes = new List<Compte_DAL>();
        //    Console.WriteLine("Entrez le nombre de participants : ");
        //    TousLesParticipantsRentrer = int.Parse(Console.ReadLine());
        //    while (TousLesParticipantsRentrer != ParticipantsRentrer)
        //    {
        //        Console.WriteLine("Entrez le pseudo : ");
        //        pseudo = Console.ReadLine();
        //        Console.WriteLine("Entrez le prenom : ");
        //        Prenom = Console.ReadLine();
        //        Console.WriteLine("Entrez le Nom : ");
        //        Nom = Console.ReadLine();
        //        Console.WriteLine("Entrez l'argent que la personne à avance sinon entrez 0");
        //        Argent = double.Parse(Console.ReadLine());
        //        var compte = new Compte_DAL(Argent, pseudo, Nom, Prenom);
        //        Comptes.Add(compte);
        //        ++ParticipantsRentrer;
        //    }
        //    var NewSoiree = new PotCommunDepot_DAL();
        //    var UneJoliSoiree = new PotCommun_DAL(Lieu, DateSoiree);
        //    NewSoiree.Insert(UneJoliSoiree);

        //    return UneJoliSoiree;
        //}


        public static void Main(string[] args)
        {
            Console.WriteLine("bienvenue dans tricount");
            Console.WriteLine("1 : creé une soirée /n" +
                              "2 : Rentrer un Montant");
            Console.WriteLine("Veuillez choisir un nombre : ");
            string Choix = Console.ReadLine();

            switch (Choix)
            {
                case "1":
                    Console.WriteLine("Ou se passera la soirée ??");
                    string Lieu = Console.ReadLine();
                    Console.WriteLine("Maintenant la Date : (au format jj/mm/aaaa)");
                    string DateSoiree = Console.ReadLine();
                    var cultureInfo = new CultureInfo("fr-FR");
                    var dateSoiree = DateTime.Parse(DateSoiree, cultureInfo);
                    PotCommunDepot_DAL SoireeDepot = new PotCommunDepot_DAL();
                    PotCommun_DAL Soiree = new PotCommun_DAL(dateSoiree, Lieu);
                    SoireeDepot.Insert(Soiree);

                    break;
                case "2":
                    break;
                default:

                    Console.WriteLine("Vous n'avez choisis le bon nombre");
                    break;
            }
        }
    }
}
