namespace CodingChallenges
{
    internal class AreEquallyStrong
    {
        public bool areEquallyStrong(int yourLeft, int yourRight, int friendsLeft, int friendsRight)
        {
            int yourStrong = yourLeft;
            int yourWeak = yourRight;
            int friendStrong = friendsLeft;
            int friendWeak = friendsRight;

            if (yourLeft < yourRight)
            {
                yourWeak = yourLeft;
                yourStrong = yourRight;
            }

            if (friendsLeft < friendsRight)
            {
                friendWeak = friendsLeft;
                friendStrong = friendsRight;
            }

            if (yourWeak == friendWeak && yourStrong == friendStrong) return true;

            return false;
        }
    }
}