using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Lecteur
{
    public class Client
    {
        private IPAddress iP;
        private NetworkStream fluxRéseau;
        private StreamReader lecteur;
        public IPAddress IP
        {
            get { return iP; }
            private set { iP = value; }
        }

        NetworkStream FluxRéseau
        {
            get { return fluxRéseau; }
            set { fluxRéseau = value; }
        }

        private StreamReader Lecteur
        {
            get { return lecteur; }
            set { lecteur = value; }
        }

        public void ConnecterAuServeur()
        {
            try
            {
                FluxRéseau = new TcpClient(IP.ToString(), 11000).GetStream();
                Console.WriteLine("Connecté au serveur !");
                
               //Un StreamReader a un constructeur qui prend un NetworkStream en paramètre
               //Lecteur = COMPLÉTEZ ICI
               Lecteur = new StreamReader(FluxRéseau);
            }
            catch (InvalidOperationException)
            {
               Console.WriteLine("Aucun flux n'existe sur le serveur donné."); 
               Environment.Exit(1);
            }
        }

        public Client(IPAddress ip)
        {
            IP = ip;
        }
        
        public void LireImage()
        {
            //COMPLÉTEZ
        }
    }
}