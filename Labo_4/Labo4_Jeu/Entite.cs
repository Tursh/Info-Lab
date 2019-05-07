using System;
using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

//À COMPLÉTER
namespace Labo4_Jeu
{
    public abstract class Entité : Drawable //complétez cette ligne
    {
        //complétez la classe
        //ne touchez pas à la méthode Draw
        private Vector2i position;
        private Sprite spriteÀDessiner;
        private int pV;
        private int déf;
        private int atq;
        private List<uint> tuileBloquées;

        public Vector2i Position
        {
            get => position;
            set => position = value;
        }

        private Sprite SpriteÀDessiner
        {
            get => spriteÀDessiner;
            set => spriteÀDessiner = value;
        }

        public int PV
        {
            get => pV;
            set => pV = value;
        }

        protected int Déf
        {
            get => déf;
            set => déf = value;
        }

        protected int Atq
        {
            get => atq;
            set => atq = value;
        }

        protected List<uint> TuileBloquées
        {
            get => tuileBloquées;
            set => tuileBloquées = value;
        }

        public Entité(Texture texture, Vector2i position)
        {
            Position = position;
            SpriteÀDessiner = new Sprite(texture);
        }

        void AjouterTuilesBloquée(uint typeDeTuile)
        {
            TuileBloquées.Add(typeDeTuile);
        }

        public bool Déplacer(Vector2i deltaDePosition)
        {
            Vector2i nouvellePosition = deltaDePosition + Position;
            //Check s'il se trouvera toujour dans la carte
            bool PeutSeDeplacer =
                (0 < nouvellePosition.X && nouvellePosition.X < Program.ScèneActuelle.CarteActuelle.NbLignes
                                        && 0 < nouvellePosition.Y && nouvellePosition.Y <
                                        Program.ScèneActuelle.CarteActuelle.NbColonnes);
            //Check s'il sera sur une tuile interdite
            if (PeutSeDeplacer)
            {
                uint futurTuile = Program.ScèneActuelle.CarteActuelle[nouvellePosition.X, nouvellePosition.Y];
                foreach (var tuileAChecker in TuileBloquées)
                    PeutSeDeplacer &= tuileAChecker != futurTuile;
            }

            if (PeutSeDeplacer) Position = nouvellePosition;

            return PeutSeDeplacer;
        }

        public abstract void MettreÀJour();

        public virtual void SubirDégats(int Degats)
        {
            Degats -= Déf;
            if (Degats < 1)
                Degats = 1;
            PV -= Degats;
        }

        public override string ToString()
        {
            return $"PV:{PV}\nATK:{Atq}\nDEF:{Déf}";
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform = Transform.Identity;
            states.Transform.Translate(Position.X * 64, Position.Y * 64);
            target.Draw(SpriteÀDessiner, states);
        }
    }
}