using System;
using SFML.Graphics;
using SFML.System;

//À COMPLÉTER
namespace Labo4_Jeu
{
    public class Guerrier : Ennemi//complétez cette ligne
    {
        //complétez la classe
        private int arm;

        public int Arm
        {
            get => arm;
            set => arm = value;
        }

        public Guerrier(Vector2i positionInitial) 
            : base(GestionnaireRessources.Textures[1], positionInitial)
        {
            Atq = 6;
            Arm = 2;
        }
        
        public override void SubirDégats(int dégatsInitiaux)
        {
            dégatsInitiaux -= Arm;
            if (dégatsInitiaux > 0)
                base.SubirDégats(dégatsInitiaux);
        }
        
        public override string ToString()
        {
            return $"{base.ToString()}\nARM:{Arm}";
        }
        
    }
}