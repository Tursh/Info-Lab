using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting;

namespace Labo3_2019
{
    public class Serveur
    {
        IPAddress iP;
        NetworkStream fluxRéseau;
        StreamWriter écrivain;
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

        private StreamWriter Écrivain
        {
            get { return écrivain; }
            set { écrivain = value; }
        }

        public void OuvrirConnection()
        {
            var serveurTcp = new TcpListener(IP, 11000);
            serveurTcp.Start();
            Console.WriteLine($"Le serveur est démarré chez {IP.ToString()} !\nEn attente d'un client.");
            
            FluxRéseau = new NetworkStream(serveurTcp.AcceptSocket());
            Console.WriteLine("Un client a été trouvé!");
            
            //Un StreamWriter a un constructeur qui prend un NetworkStream en paramètre
            //Écrivain = COMPLÉTEZ ICI
            Écrivain = new StreamWriter(FluxRéseau);
        }

        public Serveur(IPAddress ip)
        {
            IP = ip;
        }
        
        public void EnvoyerDonnées(string données)
        {
            if (FluxRéseau == null)
                throw new ServerException("Le serveur n'est pas démarré.");

            //COMPLÉTEZ
            Écrivain.Write(données);
            Écrivain.Flush();
        }
    }
}