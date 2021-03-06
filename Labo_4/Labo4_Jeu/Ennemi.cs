using System;
using SFML.Graphics;
using SFML.System;

//À COMPLÉTER
namespace Labo4_Jeu
{
    public class Ennemi : Entité //complétez cette ligne
    {
        //complétez la classe
        private Vector2i directionPatrouille;
        
        public Ennemi(Texture texture, Vector2i positionInitial)
            : base(texture, positionInitial)
        {
            PV = 10;
            Déf = 2;
            //Get la direction de facon logique et efficace
            int rand = GestionnaireRessources.RNG.Next(8);
            directionPatrouille.X = (rand % 3) - 1;
            directionPatrouille.Y = (rand / 3) - 1;
        }

        private int count = 0;
        
        public override void MettreÀJour()
        {
            ++count;
            //S'il ne peut pas se deplacer
            if (count >= 60 && !Déplacer(directionPatrouille))
            {
                //Inverse la position
                directionPatrouille *= -1;
            }

            if (count >= 60)
                count -= 60;
        }

        public void Attaquer(Entité cible)
        {
            cible.SubirDégats(Atq);
        }
    }
}