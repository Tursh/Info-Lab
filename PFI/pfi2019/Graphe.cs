using System;
using System.Collections.Generic;
using System.Linq;
using SFML.Graphics;
using SFML.System;

namespace pfi2019
{
    public class Graphe : IClonable<Graphe>, Drawable //Complétez cette ligne
    {
        public List<Noeud> Noeuds { private set; get; } = new List<Noeud>();

        public int NbChemins
        {
            get => Noeuds.Sum(noeud => noeud.NbAdjacents) / 2;
        }

        public Graphe()
        {
        }

        public Graphe(Graphe grapheToCopy)
        {
            Noeuds = new List<Noeud>(grapheToCopy.Noeuds);
        }

        public void AjouterNoeud(Noeud noeudÀAjouter) => Noeuds.Add(noeudÀAjouter);

        public bool ACheminEntre(Noeud a, Noeud b)
        {
            List<Noeud> noeuds = new List<Noeud>();
            return ACheminEntre(a, b, noeuds);
        }

        bool ACheminEntre(Noeud a, Noeud b, List<Noeud> visités)
        {
            visités.Add(a);
            foreach (var noeud in a.Adjacents)
            {
                if (noeud != null && !visités.Contains(noeud) && (noeud.Equals(b) || ACheminEntre(noeud, b, visités)))
                    return true;
            }

            return false;
        }
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            DéssinerChemins(target, Noeuds);
            foreach (var n in Noeuds)
                n.Draw(target, RenderStates.Default);
        }

        void DéssinerChemins(RenderTarget target, List<Noeud> noeuds)
        {
            foreach (Noeud n in noeuds)
            {
                foreach (Noeud a in n.CopierAdjacents())
                {
                    if (Noeuds.Contains(a))
                    {
                        Vertex[] chemin = new Vertex[2];
                        chemin[0] = new Vertex(new Vector2f(n.Position.X + 50, n.Position.Y + 50), Color.Black);
                        chemin[1] = new Vertex(new Vector2f(a.Position.X + 50, a.Position.Y + 50), Color.Black);

                        target.Draw(chemin, 0, 2, PrimitiveType.Lines);
                    }
                }
            }
        }

        public Graphe Clone()
        {
            return new Graphe(this);
        }
    }
}