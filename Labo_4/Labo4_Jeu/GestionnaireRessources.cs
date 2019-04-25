using SFML.Graphics;
using SFML.System;
using System;

//Cette classe est d�j� compl�t�e
namespace Labo4_Jeu
{
    public static class GestionnaireRessources
    {
        private static Texture[] textures;
        private static Carte[] cartes;
        private static Random rng;

        public static Texture[] Textures
        {
            get { return textures; }
            private set { textures = value; }
        }

        public static Carte[] Cartes
        {
            get { return cartes; }
            private set { cartes = value; }
        }

        public static Random RNG
        {
            get { return rng; }
            private set { rng = value; }
        }
        
        static GestionnaireRessources()
        {
            Textures = new[]
            {
                new Texture("../../joueur.png"),
                new Texture("../../guerrier.png"),
                new Texture("../../patineur.png"),
            };

            Cartes = new[]
            {
                new Carte("../../tileset.png", "../../dataCarte", new Vector2u(64, 64), 10, 10),
            };

            RNG = new Random();
        }
    }
}