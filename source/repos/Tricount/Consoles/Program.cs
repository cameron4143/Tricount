using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tricount.DAL;

namespace Consoles
{
    class Program
    {
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
                    Console.WriteLine("Entrez le nombre de participant : ");
                    int NBRParticipants = int.Parse(Console.ReadLine());
                    Console.WriteLine("Maintenant la Date : (au format jj/mm/aaaa)");
                    string DateSoiree = Console.ReadLine();
                    var cultureInfo = new CultureInfo("fr-FR");
                    var dateSoiree = DateTime.Parse(DateSoiree, cultureInfo);
                    PotCommunDepot_DAL SoireeDepot = new PotCommunDepot_DAL();
                    PotCommun_DAL Soiree = new PotCommun_DAL(dateSoiree, Lieu);
                    SoireeDepot.Insert(Soiree);

                    break;


                case "2":
                    for (int i; i < NBRParticipants; i++)
                    {
                        Console.WriteLine("Entrez le Prenom d'un Participant : ");
                        string Prenom = Console.ReadLine();
                        Console.WriteLine("Entrez le Nom d'un Participant : ");
                        string Nom = Console.ReadLine();
                        Console.WriteLine("Entrez le numéro de la soirée crée précedemment : ");
                        int NmrSoiree = int.Parse(Console.ReadLine());
                        CompteDepot_DAL CompteDepot = new CompteDepot_DAL();
                        Compte_DAL Compte = new Compte_DAL(Prenom, Nom);

                    }

                    break;


                default:
                    Console.WriteLine("Vous n'avez pas choisis le bon nombre");
                    break;
            }
        }
    }
}
