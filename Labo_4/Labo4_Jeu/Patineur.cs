using SFML.Graphics;
using SFML.System;

//À COMPLÉTER
namespace Labo4_Jeu
{
    public class Patineur : Ennemi //complétez cette ligne
    {
        //complétez la classe

        public Patineur(Vector2i positionInitial) 
            : base(GestionnaireRessources.Textures[2], positionInitial)
        {
            Atq = 3;
            TuileBloquées.Add(0);
            TuileBloquées.Add(1);
        }
    }
}