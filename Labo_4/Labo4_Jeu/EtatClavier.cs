using System;

//Cette classe est déjà complété
namespace Labo4_Jeu
{
    [Flags]
    public enum TouchesPressées
    {
        Aucune = 0x00,
        Haut = 0x01,
        Droite = 0x02,
        Bas = 0x04,
        Gauche = 0x08
    }
}