using System;
using SFML.Graphics;
using SFML.System;

//À COMPLÉTER
namespace Labo4_Jeu
{
    public class Joueur : Entité//complétez cette ligne
    {
        private Vector2i positionPrécédente;

        private Vector2i PositionPrécédente
        {
            get { return positionPrécédente;}
            set { positionPrécédente = value; }
        }
        private readonly Vector2i[] DeltasDéplacement = new Vector2i[]
        {
            new Vector2i(0,-1), 
            new Vector2i(1, 0), 
            new Vector2i(0, 1), 
            new Vector2i(-1, 0), 
        };

        private TouchesPressées touches;

        public TouchesPressées Touches
        {
            get { return touches; }
            set { touches = value; }
        }

        public Joueur(Vector2i positionInitiale)
            :base(GestionnaireRessources.Textures[0], positionInitiale)
            //complétez cette ligne
        {
            PositionPrécédente = Position;
            //complétez le reste du constructeur
            PV = 15;
            Atq = 5;
            Déf = 3;
        }

        public override void SubirDégats(int dégatsInitiaux)
        {
            Position = positionPrécédente;
            //complétez le reste de la méthode
            base.SubirDégats(dégatsInitiaux);
        }

        public override void MettreÀJour()
        {
            if (Touches != 0)
            {
                for (int i = 0; i < 4; ++i)
                {
                    if (Touches.HasFlag((TouchesPressées) (0x01 << i)))
                    {
                        PositionPrécédente = Position;
                        Déplacer(DeltasDéplacement[i]);
                        Touches = Touches & (TouchesPressées)~(0x01 << i);
                    }
                }
            }
        }
    }
}