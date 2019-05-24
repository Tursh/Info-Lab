namespace pfi2019
{
    public struct Vector2<T> : IClonable<Vector2<T>>
    {
        T x;
        T y;

        public T X
        {
            get { return x; }
            private set { x = value; }
        }
        public T Y
        {
            get { return y; }
            private set { y = value; }
        }

        public Vector2(T xInit, T yInit)
        {
            x = xInit;
            y = yInit;
        }

        private Vector2(Vector2<T> vectorÀCopier)
            : this(vectorÀCopier.X, vectorÀCopier.Y)
        {}

        public Vector2<T> Clone()
        {
            return new Vector2<T>(this);
        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}