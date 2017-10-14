namespace TextGame2
{
    class Player
    {



        public int location { get; set; } = 57;
        public bool hasKeys { get; set; } = false;





        public void moveUp()
        {
            location -= 9;
        }

        public void moveDown()
        {
            location += 9;
        }

        public void moveLeft()
        {
            location -= 1;
        }
        public void moveRight()
        {
            location += 1;
        }


    }
}