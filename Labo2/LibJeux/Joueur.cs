using System;

namespace LibJeux
{
    public class Joueur
    {
        private const int PVInitial = 10;
        
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
            PV = PVInitial;
            PVMax = PVInitial;
            InventairePrincipal = new Inventaire(capaciteDeLinventaire);
            Position = positionInitial;
            Vitesse = new Vecteur3();
            Accélération = new Vecteur3();
            Masse = masseInitial;
        }

        public void DéposerItem(Item item)
        {
            InventairePrincipal.AjouterItem(item);
        }

        public string GénérerChaine()
        {
            string stringBuffer = string.Empty;
            stringBuffer += $"PV: {PV}/{PVMax}\n";
            stringBuffer += $"position: {Position.GénérerChaine()}\n";
            stringBuffer += $"Inventaire : {InventairePrincipal.GénérerChaine()}";
            return stringBuffer;
        }

        public void AppliquerForceContinue(Vecteur3 nouvelleForce)
        {
            Accélération = nouvelleForce / Masse;
        }

        public void AjouterForceContinue(Vecteur3 nouvelleForce)
        {
            Accélération += nouvelleForce / Masse;
        }

        public void MettreÀJour(float deltaTemps)
        {
            Position = Vitesse * deltaTemps + Accélération / 2 * (deltaTemps * deltaTemps);
            Vitesse += Accélération * deltaTemps;
        }
        
    }
}
