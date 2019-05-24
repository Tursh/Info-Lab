using System;

namespace pfi2019
{
    public static class TestsGraphe
    {
        
        public static Graphe Test1()
        {
            Noeud a = new Noeud("A", new Vector2<float>(100,100), 2);
            Noeud c = new Noeud("C", new Vector2<float>(300,100), 3);
            Noeud b = new Noeud("B", new Vector2<float>(200, 150), 3);
            Noeud d = new Noeud("D", new Vector2<float>(200, 450), 2);
            Noeud e = new Noeud("E", new Vector2<float>(500, 250), 2);
            Noeud f = new Noeud("F", new Vector2<float>(500, 450), 2);
            
            a.AjouterNoeudAdjacent(b);
            c.AjouterNoeudAdjacent(b);
            c.AjouterNoeudAdjacent(d);
            d.AjouterNoeudAdjacent(b);
            e.AjouterNoeudAdjacent(f);
            
            Graphe g1 = new Graphe();
            g1.AjouterNoeud(a);
            g1.AjouterNoeud(b);
            g1.AjouterNoeud(c);
            g1.AjouterNoeud(d);
            g1.AjouterNoeud(e);
            g1.AjouterNoeud(f);

            return g1;
        }
        
        public static Graphe Test2()
        {
            return Test1().Clone();
        }

        public static void Test3()
        {
            Graphe g1 = Test1();
            Console.WriteLine($"Nombre de chemins unique : {g1.NbChemins}");
        }
        public static Graphe Test4()
        {
            Graphe g1 = new Graphe();
            foreach (Noeud n in Program.CréerNoeudsDeFichier("../../noeuds"))
                g1.AjouterNoeud(n);
            return g1;
        }
        
        public static Graphe Test5()
        {
            Noeud a = new Noeud("A", new Vector2<float>(100,100), 2);
            Noeud c = new Noeud("C", new Vector2<float>(300,100), 3);
            Noeud b = new Noeud("B", new Vector2<float>(200, 150), 3);
            Noeud d = new Noeud("D", new Vector2<float>(200, 450), 2);
            Noeud e = new Noeud("E", new Vector2<float>(500, 250), 2);
            Noeud f = new Noeud("F", new Vector2<float>(500, 450), 2);
            Noeud g = new Noeud("G", new Vector2<float>(270, 610), 2);
            
            a.AjouterNoeudAdjacent(b);
            c.AjouterNoeudAdjacent(b);
            c.AjouterNoeudAdjacent(d);
            d.AjouterNoeudAdjacent(e);
            d.AjouterNoeudAdjacent(b);
            e.AjouterNoeudAdjacent(f);
            
            Graphe g1 = new Graphe();
            g1.AjouterNoeud(a);
            g1.AjouterNoeud(b);
            g1.AjouterNoeud(c);
            g1.AjouterNoeud(d);
            g1.AjouterNoeud(e);
            g1.AjouterNoeud(f);
            g1.AjouterNoeud(g);
            
            Console.WriteLine(g1.ACheminEntre(a, f));
            Console.WriteLine(g1.ACheminEntre(a, g));

            return g1;
        }
        
    }
}