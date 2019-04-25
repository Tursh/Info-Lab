using System;
using System.Runtime.CompilerServices;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

//Cette classe est déjà complétée
namespace Labo4_Jeu
{
    internal class Program
    {
        private const float TempsFrame = 1 / 60f;
        static RenderWindow fenêtre = new RenderWindow(new VideoMode(1280,720), "Labo4", 
            Styles.Default, new ContextSettings(){AntialiasingLevel = 8});

        private static Scène scèneActuelle;
        public static Scène ScèneActuelle
        {
            get { return scèneActuelle; }
            private set { scèneActuelle = value; }
        }

        static Program()
        {
            ScèneActuelle = new Scène();
        } 
        public static void Main(string[] args)
        {
            InitialiserScène();
            fenêtre.KeyPressed += (s, e) =>
            {
                int touchesPressées = Convert.ToByte(e.Code == Keyboard.Key.Up) |
                                      Convert.ToByte(e.Code == Keyboard.Key.Right) << 1 |
                                      Convert.ToByte(e.Code == Keyboard.Key.Down) << 2 |
                                      Convert.ToByte(e.Code == Keyboard.Key.Left) << 3;
                ScèneActuelle.JoueurPrincipal.Touches = (TouchesPressées)touchesPressées;
            };
            
            Loop();
        }
        private static void InitialiserScène()
        {
            ScèneActuelle.AjouterEnnemi(new Guerrier(new Vector2i(5, 5)));
            ScèneActuelle.AjouterEnnemi(new Guerrier(new Vector2i(7, 2)));
            ScèneActuelle.AjouterEnnemi(new Patineur(new Vector2i(3, 8)));
            ScèneActuelle.JoueurPrincipal = new Joueur(new Vector2i(3, 4));
            ScèneActuelle.CarteActuelle = GestionnaireRessources.Cartes[0];
            ScèneActuelle.CréerHUD();
        }

        static void Loop()
        {
            var chrono = new Clock();
            var tempsÉcoulé = chrono.Restart();
            var tempsDepuisDernièreMiseÀJour = Time.Zero;
            
            while (fenêtre.IsOpen)
            {
                tempsÉcoulé += chrono.Restart();
                tempsDepuisDernièreMiseÀJour += tempsÉcoulé;
                while (tempsDepuisDernièreMiseÀJour.AsSeconds() > TempsFrame)
                {
                    tempsDepuisDernièreMiseÀJour -= Time.FromSeconds(TempsFrame);
                    fenêtre.DispatchEvents();
                    scèneActuelle.MettreÀJour(fenêtre);
                }
            }
        }
    }
}