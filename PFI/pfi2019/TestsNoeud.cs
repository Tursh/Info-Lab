using System;

namespace pfi2019
{
    public static class TestsNoeud
    {
        //La distance entre deux noeuds non adjacents
        public static void Test1()
        {
            Console.WriteLine("TEST 1");
            
            Noeud n1 = new Noeud("A", new Vector2<float>(100,200), 1);
            Noeud n2 = new Noeud("B", new Vector2<float>(150, 400), 1);
            Console.WriteLine($"La distance entre A et B est {n1.CalculerDistance(n2)}");
        }
        
        //La distance entre deux noeuds adjacents
        public static void Test2()
        {
            Console.WriteLine("TEST 2");
            
            Noeud n1 = new Noeud("A", new Vector2<float>(100,200), 1);
            Noeud n2 = new Noeud("B", new Vector2<float>(150, 400), 1);
            n1.AjouterNoeudAdjacent(n2);
            Console.WriteLine($"La distance entre A et B est {n1.CalculerDistance(n2)}");
        }
        
        //Essayer d'ajouter un noeud adjacent à un noeud saturé
        public static void Test3()
        {
            Console.WriteLine("TEST 3");
            
            Noeud n1 = new Noeud("A", new Vector2<float>(100,200), 1);
            Noeud n2 = new Noeud("B", new Vector2<float>(150, 400), 1);
            Noeud n3 = new Noeud("C", new Vector2<float>(550, 400), 1);
            n1.AjouterNoeudAdjacent(n2);
            n2.AjouterNoeudAdjacent(n3);
            Console.WriteLine($"La distance entre B et C est {n2.CalculerDistance(n3)}");
        }
        
        //Essayer d'ajouter un noeud adjacent à un noeud non saturé
        public static void Test4()
        {
            Console.WriteLine("TEST 4");
            
            Noeud n1 = new Noeud("A", new Vector2<float>(100,200), 1);
            Noeud n2 = new Noeud("B", new Vector2<float>(150, 400), 2);
            Noeud n3 = new Noeud("C", new Vector2<float>(550, 400), 1);
            n1.AjouterNoeudAdjacent(n2);
            n2.AjouterNoeudAdjacent(n3);
            Console.WriteLine($"La distance entre B et C est {n2.CalculerDistance(n3)}");
        }
        
        //Afficher le résultat de ToString() pour plusieurs noeuds
        public static void Test5()
        {
            Console.WriteLine("TEST 5");
            
            Noeud n1 = new Noeud("A", new Vector2<float>(100,200), 1);
            Noeud n2 = new Noeud("B", new Vector2<float>(150, 400), 2);
            Noeud n3 = new Noeud("C", new Vector2<float>(550, 400), 1);
            Noeud n4 = new Noeud("D", new Vector2<float>(250, 50), 0);
            
            n1.AjouterNoeudAdjacent(n2);
            n2.AjouterNoeudAdjacent(n3);
            
            foreach (Noeud n in new Noeud[]{n1, n2, n3, n4})
                Console.WriteLine(n);
        }
        
        //Afficher le résultat de ToString() pour plusieurs noeuds
        public static void Test6()
        {
            Console.WriteLine("TEST 6");
            
            Noeud n1 = new Noeud("A", new Vector2<float>(100,200),5);
            Noeud n2 = new Noeud("B", new Vector2<float>(150, 400), 2);
            Noeud n3 = new Noeud("C", new Vector2<float>(550, 400), 5);
            Noeud n4 = new Noeud("D", new Vector2<float>(300, 500), 1);
            n1.AjouterNoeudAdjacent(n2);
            n1.AjouterNoeudAdjacent(n3);
            n2.AjouterNoeudAdjacent(n3);

            Noeud[] copies = n2.CopierAdjacents();
            copies[0].AjouterNoeudAdjacent(n4);
            foreach (Noeud n in copies)
                Console.WriteLine(n.ToString());
            
            Console.WriteLine(n1.ToString());
        }
    }
}