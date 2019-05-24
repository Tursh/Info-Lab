using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace pfi2019
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TesterNoeud();
            TesterGraphe();

            Console.ReadKey();
        }

        static void TesterNoeud()
        {
            TestsNoeud.Test1();
            TestsNoeud.Test2();
            TestsNoeud.Test3();
            TestsNoeud.Test4();
            TestsNoeud.Test5();
            TestsNoeud.Test6();
        }


        static void TesterGraphe()
        {
            CréerScène(TestsGraphe.Test1());
            CréerScène(TestsGraphe.Test2());
            TestsGraphe.Test3();
            CréerScène(TestsGraphe.Test4());
            CréerScène(TestsGraphe.Test5());
        }


        static void CréerScène(Graphe graphe)
        {
            RenderWindow fenêtre = new RenderWindow(new VideoMode(1280, 720),
                "PFI", Styles.Default, new ContextSettings() {AntialiasingLevel = 8});
            fenêtre.Clear(Color.White);
            fenêtre.Draw(graphe);
            fenêtre.Display();
        }

        public static List<Noeud> CréerNoeudsDeFichier(string cheminDuFichier)
        {
            List<Noeud> noeuds = new List<Noeud>();
            List<string[]> adjacents = new List<string[]>();
            using (StreamReader sr = new StreamReader(cheminDuFichier))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parametres = line.Split(';', ':');
                    noeuds.Add(new Noeud(parametres[0],
                        new Vector2<float>(float.Parse(parametres[1]), float.Parse(parametres[2])),
                        int.Parse(parametres[3])));
                    if (parametres.Length > 4)
                        adjacents.Add(parametres[4].Split(','));
                    else
                        adjacents.Add(new string[0]);
                }
            }

            for (int i = 0; i < noeuds.Count; ++i)
            {
                foreach (var name in adjacents[i])
                {
                    var iterator = noeuds.Where(noeud => noeud.Étiquette.Equals(name));
                    noeuds[i].AjouterNoeudAdjacent(iterator.Single());
                }
            }

            return noeuds;
        }
    }
}