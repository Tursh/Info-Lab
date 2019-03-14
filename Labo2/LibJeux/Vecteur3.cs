using System;

namespace LibJeux
{
    public class Vecteur3
    {
        private float x, y, z;

        public Vecteur3()
        {
            x = 0;
            y = 0;
            z = 0;
        }
        
        public Vecteur3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public float X => x;
        public float Y => y;
        public float Z => z;

        public String GénérerChaine()
        {
            return $"({X},{Y},{Z})";
        }
        
        public static Vecteur3 operator + (Vecteur3 vecteur_1, Vecteur3 vecteur_2)
        {
            return new Vecteur3(vecteur_1.X + vecteur_2.X, vecteur_1.Y + vecteur_2.Y, vecteur_1.Z + vecteur_2.Z);
        }

        public static Vecteur3 operator *(Vecteur3 vecteur, float multiplier)
        {
            return new Vecteur3(vecteur.X * multiplier, vecteur.Y * multiplier, vecteur.Z * multiplier);
        }
        
        public static Vecteur3 operator / (Vecteur3 vecteur, float denominator)
        {
            return vecteur * (1 / denominator);
        }
        
        
    }
}
