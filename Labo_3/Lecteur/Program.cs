using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Lecteur
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Entrez l'adresse IP du serveur qui stream.");
            var client = new Client(IPAddress.Parse(Console.ReadLine() ?? throw new NullReferenceException()));
            client.ConnecterAuServeur();
            while(true)
                client.LireImage();
        }
    }
}