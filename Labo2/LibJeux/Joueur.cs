using System;

namespace LibJeux
{
    public class Joueur
    {
        private const int PV_INITIAL = 10;
        
        private int pV, pVMax;
        private Inventaire inventairePrincipal;
        private Vecteur3 position, vitesse, accélération;
        private float masse;

        public int PV
        {
            get => pV;
            set => pV = value;
        }

        public int PVMax
        {
            get => pVMax;
            set => pVMax = value;
        }

        public Inventaire InventairePrincipal
        {
            get => inventairePrincipal;
            set
            {
                if (value != null)
                    inventairePrincipal = value;
            }
        }

        public Vecteur3 Position
        {
            get => position;
            set => position = value;
        }

        public Vecteur3 Vitesse
        {
            get => vitesse;
            set => vitesse = value;
        }

        public Vecteur3 Accélération
        {
            get => accélération;
            set => accélération = value;
        }

        public float Masse
        {
            get => masse;
            set => masse = value;
        }

        public float AngleVitesseXY => (float) Math.Atan2(Vitesse.Y, Vitesse.X);

        public Joueur(Vecteur3 positionInitial, int capaciteDeLinventaire, int masseInitial)
        {
            pV = PV_INITIAL;
            pVMax = PV_INITIAL;
            inventairePrincipal = new Inventaire(capaciteDeLinventaire);
            position = positionInitial;
            vitesse = new Vecteur3();
            accélération = new Vecteur3();
            masse = masseInitial;
        }

        public void DéposerItem(Item item)
        {
            inventairePrincipal.AjouterItem(item);
        }

        public string GénérerChaine()
        {
            string stringBuffer = string.Empty;
            stringBuffer += $"PV: {pV}/{pVMax}\n";
            stringBuffer += $"position: {position.GénérerChaine()}\n";
            stringBuffer += $"Inventaire : {inventairePrincipal.GénérerChaine()}";
            return stringBuffer;
        }

        public void AppliquerForceContinue(Vecteur3 nouvelleForce)
        {
            accélération = nouvelleForce / masse;
        }

        public void AjouterForceContinue(Vecteur3 nouvelleForce)
        {
            accélération += nouvelleForce / masse;
        }

        public void MettreÀJour(float deltaTemps)
        {
            position = vitesse * deltaTemps + accélération / 2 * (deltaTemps * deltaTemps);
            vitesse += accélération * deltaTemps;
        }
        
    }
}
