namespace Pdrome2
{
    /// <summary>
    /// this implementation does the rotations in place, which was more challenging than I expected.
    /// </summary>
    internal class RotateMatrix
    {
        // TODO: Better, maybe with some recursion? 
        public void Rotate(int[,] matrix) {
            int startPosition = 0;
            int length = matrix.GetLength(0);
            int maxDepth = length / 2;
            while(startPosition < maxDepth)
            {
                int lengthToGo = matrix.GetLength(0) - 1 - startPosition * 2;
                for(int i = 0; i < lengthToGo; i++)
                {
                    int rotate = length - startPosition - 1; // distance we are moving our target
                
                    int minYMaxX = matrix[startPosition + i, rotate]; // top right item
                    matrix[startPosition + i, rotate] = matrix[startPosition, startPosition + i]; // move our far left top to the far right top

                    int maxYMaxX = matrix[rotate, rotate - i]; // store our bottom right item
                    matrix[rotate, rotate - i] = minYMaxX;  // move the top right item to the bottom right

                    int maxYMinX = matrix[rotate - i, startPosition]; // store the bottom left item
                    matrix[rotate - i, startPosition] = maxYMaxX; // move the bottom right item to bottom left

                    matrix[startPosition, startPosition + i] = maxYMinX; // move bottom left item to top left
                }
            
                startPosition++;
            }
            // [[15,13,2,5],
            // [14,8,6,1],
            // [12,4,3,9],
            // [16,7,10,11]]
            // outer loop that knows how many inner rotations we'll need to make
            // store current position (0,0) (0,4)
            // how far is my current position from the left and  top? (0,0) (0,4)
            // one axis moves and the other stays the same, so for 0,0, our new position is (0,4) (4,4) ()
            // store current position 0,0 push
            // store the value we are replacing in a temp variable and move our (0,0) to the target position
            // 
            // 
        }
    }
}