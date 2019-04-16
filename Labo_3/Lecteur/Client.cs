using System;
using System.Collections.Specialized;
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

        private int i = 0;
        public void LireImage()
        {
            //COMPLÉTER
            string[] size = Lecteur.ReadLine().Split(':');
            string pixelsList = Lecteur.ReadLine();
            
            int width = int.Parse(size[0]);
            int height = int.Parse(size[1]);
            
            Bitmap bitmap = new Bitmap(width, height);
            string[] pixels = pixelsList.Split('/');
            for (int i = 0; i < width * height; ++i)
            {
                string[] RGB = pixels[i].Split(',');
                Color color = Color.FromArgb(255, byte.Parse(RGB[0]), byte.Parse(RGB[1]), byte.Parse(RGB[2]));
                bitmap.SetPixel(i % width, i / width, color);
            }

            bitmap.Save($"image{i}.bmp");
            ++i;
        }
    }
}