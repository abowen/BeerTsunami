namespace Assets.Scripts
{
    public class PlayerInputButtonKeys
    {
        private PlayerInputButtonKeys()
        {
        }

        public static PlayerInputButtonKeys CreateForPlayer(int playerNumber)
        {
            var inputButtonKeys = new PlayerInputButtonKeys();

            if (playerNumber == 1)
            {
                inputButtonKeys.DropBBQKey = "DropBBQPlayer1";
            }
            else
            {
                inputButtonKeys.DropBBQKey = "DropBBQPlayer2";
            }

            return inputButtonKeys;
        }

        public string DropBBQKey { get; set; }
    }
}
