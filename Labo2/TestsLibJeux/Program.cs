using System;
using LibJeux;

namespace TestsLibJeux
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Test Vecteur3
            Vecteur3 v = new Vecteur3(1, 2, 3);
            Console.Out.WriteLine(v.GénérerChaine());
            //Test Item
            Item i = new Item("Pomme en or    ", "Une pomme qui est en or");
            Console.Out.WriteLine(i.GénérerChaine());
            //Test Inventaire
            Inventaire inv = new Inventaire(3);
            inv.AjouterItem(i);
            Item i2 = new Item("Pomme en or 2   ", "Une pomme qui est en or");
            inv.InsérerItemDébut(i2);
            Console.Out.WriteLine(inv.GénérerChaine());
            
            Console.Out.WriteLine(inv.ChercherItem(1).GénérerChaine());
            //Test Joueur
            Joueur j = new Joueur(new Vecteur3(), 10, 1);
            j.AppliquerForceContinue(new Vecteur3(1, 0, 0));
            j.MettreÀJour(1);
            Console.Out.WriteLine(j.GénérerChaine());
            j.AjouterForceContinue(new Vecteur3(-2, 1, 0));
            j.MettreÀJour(1);
            Console.Out.WriteLine(j.GénérerChaine());
            j.MettreÀJour(1);
            Console.Out.WriteLine(j.GénérerChaine());
            
        }
    }
}