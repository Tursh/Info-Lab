using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace LibJeux
{
    public class Inventaire
    {
        private Item[] items;
        private int capacity;
        private int NbItems;

        public Inventaire(int capacity)
        {
            if (capacity < 1)
                capacity = 1;
            items = new Item[capacity];
            this.capacity = capacity;
            NbItems = 0;
        }

        public void AjouterItem(Item item)
        {
            if (NbItems < capacity)
            {
                items[NbItems] = item;
                NbItems++;
            }
        }

        public void InsérerItemDébut(Item item)
        {
            if (NbItems < capacity)
            {
                List<Item> itemList = items.ToList();
                itemList.Insert(0, item);
                items = itemList.ToArray();
                NbItems++;
            }
        }

        public Item ChercherItem(int index)
        {
            if (index < NbItems)
                return items[index];
            else
            {
                Console.Out.WriteLine("Il n'y a pas d'item a l'indice: {0}", index);
                return items[NbItems - 1];
            }
        }

        public string GénérerChaine()
        {
            string stringBuffer = string.Empty;
            for (int i = 0; i < NbItems; i++)
                stringBuffer += $"Item #{i}: " + items[i].GénérerChaine() + '\n';
            return stringBuffer;
        }
        
    }
}
