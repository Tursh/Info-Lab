using System;
using System.IO;
using System.Net;
using System.Threading;

namespace Labo3_2019
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entrez l'adresse IP où démarrer le stream");
            var ip = IPAddress.Parse(Console.ReadLine() ?? throw new NullReferenceException());
            var serveur = new Serveur(ip);
            serveur.OuvrirConnection();
            
            //Tests
            //Testez serveur.EnvoyerDonnées ici
            serveur.EnvoyerDonnées("255,0,0/255,0,0/255,0,0/255,0,0/255,0,0/255,0,0/");
        }
    }
}