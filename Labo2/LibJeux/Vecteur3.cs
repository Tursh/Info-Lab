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
            return $"({x},{y},{z})";
        }
        
        public static Vecteur3 operator + (Vecteur3 vecteur_1, Vecteur3 vecteur_2)
        {
            return new Vecteur3(vecteur_1.x + vecteur_2.x, vecteur_1.y + vecteur_2.y, vecteur_1.z + vecteur_2.z);
        }

        public static Vecteur3 operator *(Vecteur3 vecteur, float multiplier)
        {
            return new Vecteur3(vecteur.x * multiplier, vecteur.y * multiplier, vecteur.z * multiplier);
        }
        
        public static Vecteur3 operator / (Vecteur3 vecteur, float denominator)
        {
            return vecteur * (1 / denominator);
        }
        
        
    }
}
