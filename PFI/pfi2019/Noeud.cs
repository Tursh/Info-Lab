using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using SFML.System;

namespace pfi2019
{
    public class Noeud : IClonable<Noeud>
    {
        public string Étiquette { private set; get; }
        public Vector2<float> Position { private set; get; }
        public Noeud[] Adjacents { private set; get; }
        public int Capacité { private set; get; }
        public int NbAdjacents { private set; get; }

        public Noeud(string étiquette, Vector2<float> position, int capacité)
        {
            Étiquette = étiquette;
            Position = position;
            Adjacents = new Noeud[capacité];
            Capacité = capacité;
        }

        public Noeud(Noeud noeudToCopy)
        {
            Étiquette = noeudToCopy.Étiquette;
            Position = noeudToCopy.Position;
            Adjacents = new Noeud[noeudToCopy.Capacité];
            Capacité = noeudToCopy.Capacité;
        }


        public void AjouterNoeudAdjacent(Noeud adjacent)
        {
            if ((NbAdjacents == 0 || Adjacents[NbAdjacents - 1] != adjacent) && !EstSaturé())
            {
                Adjacents[NbAdjacents] = adjacent;
                ++NbAdjacents;
                adjacent.AjouterNoeudAdjacent(this);
            }
        }

        bool EstSaturé()
        {
            return NbAdjacents == Capacité;
        }

        public float CalculerDistance(Noeud autre)
        {
            foreach (var noeud in Adjacents)
            {
                if (noeud == null)
                    break;
                if (noeud.Equals(autre))
                {
                    return (float) Math.Sqrt(Math.Pow(Position.X - noeud.Position.X, 2) +
                                             Math.Pow(Position.Y - noeud.Position.Y, 2));
                }
            }

            return -1.0f;
        }

        public Noeud[] CopierAdjacents()
        {
            Noeud[] copyAdjacents = new Noeud[Capacité];
            for (int i = 0; i < Capacité; ++i)
            {
                if (Adjacents[i] != null)
                    copyAdjacents[i] = Adjacents[i].Clone();
                else
                    break;
            }

            return copyAdjacents;
        }

        public override string ToString()
        {
            StringBuilder adjacents = new StringBuilder();
            foreach (var adjacent in Adjacents)
                if (adjacent != null)
                    adjacents.Append($"{adjacent.Étiquette}, ");
            
            //Enlever la vergule a la fin
            if (adjacents.Length > 2)
                adjacents.Remove(adjacents.Length - 2, 2);

            return $"{Étiquette} @{Position}\n--Adjacents--\n{adjacents}\n";
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            var texte = new Text(Étiquette, GestionnaireRessources.PolicePrincipale, 50);
            texte.FillColor = Color.White;
            texte.Origin = new Vector2f(-33, -19);

            states.Transform = Transform.Identity;
            states.Transform.Translate(Position.X, Position.Y);
            var cercle = new CircleShape(50, 150);
            cercle.FillColor = Color.Black;


            target.Draw(cercle, states);
            target.Draw(texte, states);
        }


        public override bool Equals(object obj)
        {
            return Étiquette == ((Noeud) obj)?.Étiquette;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Noeud Clone()
        {
            return new Noeud(this);
        }
    }
}