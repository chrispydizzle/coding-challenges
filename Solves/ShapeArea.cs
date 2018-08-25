namespace Pdrome2
{
    public class ShapeArea
    {
        public int shapeArea(int n)
        {
            return (n * n) + ((n - 1) * (n - 1));
            //          if (n == 1) return 1;

            // in case of n == 2, we just venture two away from the center each time.
//            if (n == 2) return this.shapeArea(1 + );
        }
    }
}