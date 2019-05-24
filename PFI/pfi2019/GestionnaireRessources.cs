using SFML.Graphics;

namespace pfi2019
{
    public static class GestionnaireRessources
    {
        private static Font policePrincipale;

        public static Font PolicePrincipale
        {
            get { return policePrincipale; }
            private set { policePrincipale = value; }
        }

        static GestionnaireRessources()
        {
            PolicePrincipale = new Font("../../Roboto-Light.ttf");
        }
    }
}