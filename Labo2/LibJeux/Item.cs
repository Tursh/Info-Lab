using System;
using System.Linq;

namespace LibJeux
{
    public class Item
    {
        private const string DefaultValue = "default";
        
        private string nom, description;

        public Item(string nom, string description)
        {
            //Enleve les digits invisibles
            string nomWithoutInvisibleDigit = new string(nom.Where(c => !char.IsControl(c)).ToArray());
            string descriptionWithoutInvisibleDigit = new string(description.Where(c => !char.IsControl(c)).ToArray());
            //Verifie si le nom et la description sans les digits invisible est vide ou null
            string nomResult = (string.IsNullOrEmpty(nomWithoutInvisibleDigit) || String.IsNullOrWhiteSpace(nomWithoutInvisibleDigit)) ? DefaultValue : nom;
            string descriptionResult = (string.IsNullOrEmpty(descriptionWithoutInvisibleDigit) || String.IsNullOrWhiteSpace(descriptionWithoutInvisibleDigit)) ? DefaultValue : description;
            
            //Enleve les espaces surperflues entourante
            while (nomResult.ToCharArray()[0] == ' ')
                nomResult = nomResult.Substring(1);
            while(nomResult.ToCharArray()[nomResult.Length - 1] == ' ')
                nomResult = nomResult.Substring(0, nomResult.Length - 1);
            
            while (descriptionResult.ToCharArray()[0] == ' ')
                descriptionResult = descriptionResult.Substring(1);
            while(descriptionResult.ToCharArray()[descriptionResult.Length - 1] == ' ')
                descriptionResult = descriptionResult.Substring(0, descriptionResult.Length - 1);

            this.nom = nomResult;
            this.description = descriptionResult;

        }

        public string GénérerChaine()
        {
            return $"Nom: {nom} | Description: {description}";
        }
       
    }
}
