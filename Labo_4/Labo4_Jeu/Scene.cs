using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.System;

//Cette classe est déjà complétée
namespace Labo4_Jeu
{
    public class Scène
    {
        private List<Ennemi> ennemis;
        private Joueur joueurPrincipal;
        private Carte carteActuelle;
        private Text[] hud;

        public Carte CarteActuelle
        {
            get { return carteActuelle; }
            set { carteActuelle = value; }
        }

        public Joueur JoueurPrincipal
        {
            get { return joueurPrincipal; }
            set { joueurPrincipal = value; }
        }

        private List<Ennemi> Ennemis
        {
            get { return ennemis; }
            set { ennemis = value; }
        }

        private Text[] HUD
        {
            get { return hud; }
            set { hud = value; }
        }

        public void MettreÀJour(RenderWindow fenêtre)
        {
            MettreEnnemisÀJour();
            JoueurPrincipal.MettreÀJour();
            
            VérifierCollision();

            MettreHUDÀJour();
            DessinerScène(fenêtre);
        }

        void MettreEnnemisÀJour()
        {
            foreach (var ennemi in Ennemis)
                ennemi.MettreÀJour();
        }

        void MettreHUDÀJour(RenderWindow fenêtre)
        {
            HUD[0].DisplayedString = $"Joueur\n\n{JoueurPrincipal}";
            for (int i = 0; i < Ennemis.Count; i++)
            {
                Ennemi e = Ennemis[i];
                HUD[i + 1].DisplayedString = $"Ennemi\n\n{e}";
            }
        }

        void VérifierCollision()
        {
            foreach (var ennemi in Ennemis)
            {
                if (ennemi.Position == JoueurPrincipal.Position)
                {
                    ennemi.Attaquer(JoueurPrincipal);
                    if (JoueurPrincipal.PV <= 0)
                        Application.Exit();
                }
            }
        }

        void DessinerScène(RenderWindow fenêtre)
        {
            fenêtre.Clear(Color.Black);
            fenêtre.Draw(CarteActuelle);
            
            fenêtre.Draw(JoueurPrincipal);
            
            foreach (var ennemi in Ennemis)
                fenêtre.Draw(ennemi);

            foreach (var e in HUD)
                fenêtre.Draw(e);
            fenêtre.Display();
        }

        public Scène()
        {
            Ennemis = new List<Ennemi>(1);
        }

        public void AjouterEnnemi(Ennemi ennemiÀAjouter)
        {
            Ennemis.Add(ennemiÀAjouter);
        }

        public void CréerHUD()
        {
            HUD = new Text[Ennemis.Count + 1];

            Text textJoueur = new Text();
            textJoueur.FillColor = Color.White;
            textJoueur.CharacterSize = 20;
            textJoueur.Font = new Font("../../04B_30__.TTF");
            textJoueur.Position = new Vector2f(700, 50);

            hud[0] = textJoueur;
            
            for (int i = 1; i < Ennemis.Count + 1; i++)
            {
                Text text = new Text();  
                text.FillColor = Color.White;
                text.CharacterSize = 20;
                text.Font = new Font("../../04B_30__.TTF");
                text.Position = new Vector2f(700, 150 * i + 30);
                hud[i] = text;
            }
        }
    }
}