using System.IO;
using SFML.Graphics;
using SFML.System;

//Cette classe est déjà complétée
namespace Labo4_Jeu
{
    public class Carte : Transformable, Drawable
    {
        private uint[,] tuiles;
        private uint nbLignes;
        private uint nbColonnes;
        private Texture tileset;
        private VertexArray sommets;

        private Texture Tileset
        {
            get { return tileset; }
            set { tileset = value; }
        }

        private VertexArray Sommets
        {
            get { return sommets; }
            set { sommets = value; }
        }

        private uint[,] Tuiles
        {
            get { return tuiles; }
            set { tuiles = value; }
        }

        public uint NbLignes
        {
            get { return nbLignes; }
            private set { nbLignes = value; }
        }

        public uint NbColonnes
        {
            get { return nbColonnes; }
            private set { nbColonnes = value; }
        }

        public uint this[int i, int j]
        {
            get { return Tuiles[i, j]; }
            set { Tuiles[i, j] = value; }
        }

        public Carte(string fichierTileset, string fichierDonnées, Vector2u dimensionTuiles, uint nbLignes,
            uint nbColonnes)
        {
            NbLignes = nbLignes;
            NbColonnes = nbColonnes;
            Tuiles = new uint[NbLignes, NbColonnes];
            Tileset = new Texture(fichierTileset);
            Sommets = new VertexArray();
            Load(fichierTileset, fichierDonnées, dimensionTuiles, nbLignes, nbColonnes);
        }

        void Load(string fichierTileset, string fichierDonnées, Vector2u dimensionTuile, uint nbLignes,
           uint nbColonnes)
        {
            Sommets.PrimitiveType = PrimitiveType.Quads;
            Sommets.Resize(nbLignes * nbColonnes * 4);

            using (var sr = new StreamReader(fichierDonnées))
            {
                for (uint i = 0; i < nbLignes; ++i)
                {
                    var donnéesLigne = sr.ReadLine().Split(',');
                    for (uint j = 0; j < nbColonnes; ++j)
                    {
                        var tuileActuelle = uint.Parse(donnéesLigne[j]);
                        Tuiles[i, j] = tuileActuelle;

                        uint tu = tuileActuelle % (Tileset.Size.X / dimensionTuile.X);
                        uint tv = tuileActuelle % (Tileset.Size.Y / dimensionTuile.Y);

                        Sommets[(i + j * nbLignes) * 4] = new Vertex(new Vector2f(j * dimensionTuile.X, i * dimensionTuile.Y),
                            new Vector2f(tu * dimensionTuile.X, tv * dimensionTuile.Y));
                        Sommets[((i + j * nbLignes) * 4) + 1] = new Vertex(new Vector2f((j + 1) * dimensionTuile.X, i * dimensionTuile.Y),
                            new Vector2f((tu + 1) * dimensionTuile.X, tv * dimensionTuile.Y));
                        Sommets[((i + j * nbLignes) * 4) + 2] = new Vertex(new Vector2f((j + 1) * dimensionTuile.X, (i + 1) * dimensionTuile.Y),
                            new Vector2f((tu + 1) * dimensionTuile.X, (tv + 1) * dimensionTuile.Y));
                        Sommets[((i + j * nbLignes) * 4) + 3] = new Vertex(new Vector2f(j * dimensionTuile.X, (i + 1) * dimensionTuile.Y),
                            new Vector2f(tu * dimensionTuile.X, (tv + 1) * dimensionTuile.Y));
                    }
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            states.Texture = Tileset;
            target.Draw(Sommets, states);
        }
    }
}