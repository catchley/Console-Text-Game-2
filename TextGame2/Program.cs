using System;
using System.Linq;
namespace TextGame2
{
    class Program
    {

        static void Main(string[] args)
        {

            Item altarOneOn = new Item();
            Item altarTwoOn = new Item();
            Item altarThreeOn = new Item();
            Player player = new Player();

            Item stick = new Item
            {
                location = 49,
                name = "stick"
            };


            Item bottle = new Item
            {
                location = 24,
                name = "bottle"
            };




            Console.WriteLine("Text Game.  Your objective is to find and get into the party.");
            Console.WriteLine("Press enter to begin.");

            Console.ReadLine();




            while (player.location != 41)
            {
                Console.WriteLine();
                Console.WriteLine();
                playerTurn(player, stick, bottle, altarOneOn, altarTwoOn, altarThreeOn);
               
                CheckForItems(player, stick, bottle);

                int[] signLocations = { 5, 43, 48, 62 };
                int[] pillarLocations = { 10, 18, 80 };

                if (pillarLocations.Contains(player.location))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("*You see an altar.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (signLocations.Contains(player.location))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("*You see a sign.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (player.location == 81)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("*You see a pile of ice.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if (player.location == 22)
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("*You see a fan blowing.");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                if ((player.location == 1) || (player.location == 51))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("You see a pool of water.");
                    Console.WriteLine();
                    Console.WriteLine();
                }


                if ((player.location == 17) || (player.location == 30))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("You see a camp fire.");
                    Console.WriteLine();
                    Console.WriteLine();
                }

            }


            if ((altarOneOn.isTurnedOn == true) && (altarTwoOn.isTurnedOn == true) && (altarThreeOn.isTurnedOn == true))
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You have entered the party.");
                Console.WriteLine("You Win");
                Console.WriteLine("CODE WORD: VEGETABLES.");
                Console.WriteLine("GAME OVER");
                Console.WriteLine();
                Console.WriteLine();
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You lose.");
                Console.WriteLine("GAME OVER");
                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("Press enter to exit.");

            }
            Console.ReadLine();






        }


        //Methods




        private static void playerTurn(Player player, Item stick, Item bottle, Item altone, Item alttwo, Item altthree)
        {

            int[] ableToMoveUp = new int[] { 10, 11, 14, 17, 18, 23, 31, 32, 33, 39, 40, 43, 48, 49, 52, 57, 58, 60, 61, 72, 81 };

            int[] ableToMoveDown = new int[] { 1, 2, 5, 8, 9, 14, 22, 23, 24, 30, 31, 34, 39, 40, 43, 48, 49, 51, 52, 63, 72 };

            int[] ableToMoveLeft = new int[] { 2, 3, 4, 5, 6, 7, 8, 9, 11, 18, 23, 24, 31, 32, 33, 34, 40, 49, 52, 58, 59, 60, 61, 62, 63, 81 };

            int[] ableToMoveRight = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 10, 17, 22, 23, 30, 31, 32, 33, 39, 48, 51, 57, 58, 59, 60, 61, 62, 80 };

            Console.WriteLine("Press l, r, u, d, or s then enter to move left, right, up, down, or perform search/action.");
            string entry = Console.ReadLine();
            if (entry == "l")
            {
                if (ableToMoveLeft.Contains(player.location))
                {
                    player.moveLeft();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("///Sorry, that direction in blocked.///");
                }

            }
            else if (entry == "r")
            {
                if (player.location == 40)
                {
                    if (player.hasKeys == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("  ##  There is a sign that says PARTY HERE, but the door is locked.");
                    }
                    else
                    {
                        player.moveRight();
                    }

                }
                else if (ableToMoveRight.Contains(player.location))
                {
                    player.moveRight();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("///Sorry, that direction in blocked.///");
                }
            }
            else if (entry == "u")
            {
                if (ableToMoveUp.Contains(player.location))
                {
                    player.moveUp();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("///Sorry, that direction in blocked.///");
                }
            }
            else if (entry == "d")
            {
                if (ableToMoveDown.Contains(player.location))
                {
                    player.moveDown();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("///Sorry, that direction in blocked.///");
                }
            }
            else if (entry == "s")
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Searching");



                if ((bottle.isBeingCarried) && (player.location == stick.location))
                {
                    DropItem(player, bottle);
                    PickUpItem(stick);
                }
                else if ((stick.isBeingCarried) && (stick.isOnFire) && (player.location == bottle.location))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("Whoa!!  It's too dangerous to drop something that's on fire.");
                    Console.WriteLine();
                    Console.WriteLine();
                }

                else if ((stick.isBeingCarried) && (player.location == bottle.location))
                {
                    DropItem(player, stick);
                    PickUpItem(bottle);

                }

                else if ((!stick.isBeingCarried) && (player.location == bottle.location))
                {
                    PickUpItem(bottle);

                }

                else if ((!bottle.isBeingCarried) && (player.location == stick.location))
                {
                    PickUpItem(stick);

                }








                if ((player.location == 14) && (altone.isTurnedOn == true) && (alttwo.isTurnedOn == true) && (altthree.isTurnedOn == true))
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("!!!You found some keys!!!");
                    Console.WriteLine();
                    Console.WriteLine();
                    player.hasKeys = true;

                }
                //Player on a camp fire location
                else if ((player.location == 30) || (player.location == 17))
                {
                    if (stick.isBeingCarried)
                    {
                        if (!stick.isWet)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("!!!Your stick is now on fire!!!");
                            Console.WriteLine();
                            Console.WriteLine();
                            stick.isOnFire = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Your stick is too wet to catch on fire.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                    }
                    else if (bottle.isBeingCarried)
                    {
                        if (bottle.isFull)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("!!!Your water is now warm!!!");
                            Console.WriteLine();
                            Console.WriteLine();
                            bottle.isWarm = true;
                            bottle.isCold = false;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("There is nothing in your bottle to heat up.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                    }
                }

                //Player on a water location

                else if ((player.location == 1) || (player.location == 51))
                {
                    if (stick.isBeingCarried)
                    {
                        if ((!stick.isWet) && (stick.isOnFire))
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("!!!Your stick is no longer on fire and is now wet!!!");
                            Console.WriteLine();
                            Console.WriteLine();
                            stick.isOnFire = false;
                            stick.isWet = true;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Your stick is now wet.");
                            Console.WriteLine();
                            Console.WriteLine();
                            stick.isWet = true;
                        }
                    }
                    if (bottle.isBeingCarried)
                    {

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!Your bottle is now full !!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        bottle.isFull = true;

                    }


                }

                //Player on fan location
                else if (player.location == 22)
                {
                    if (stick.isBeingCarried)
                    {
                        if (!stick.isOnFire)
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("!!!Your stick is now dry!!!");
                            Console.WriteLine();
                            Console.WriteLine();
                            stick.isWet = false;
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("The fan is not powerful enough to put out the fire.");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                    }
                    if ((bottle.isBeingCarried) && (bottle.isFull))
                    {
                        if (bottle.isWarm)

                            Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!Your water is now room temperature!!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        bottle.isWarm = false;

                    }


                }



                //Player on Altar Locations
                else if (player.location == 10)
                {

                    if ((bottle.isBeingCarried) && (bottle.isFull) && (bottle.isWarm))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You pour the hot water onto the altar...and the altar starts to glow!!!");
                        Console.WriteLine("!!!Your bottle is now empty!!!");
                        
                        Console.WriteLine();
                        altone.isTurnedOn = true;
                        bottle.isFull = false;
                        if ((altone.isTurnedOn == true) && (alttwo.isTurnedOn == true) && (altthree.isTurnedOn == true))
                        {
                            Console.WriteLine();
                            Console.WriteLine("**You hear a jingling noise in the distance.");
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You do not put the correct offering onto the alter!!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        player.location = 41;
                    }


                }
                else if (player.location == 18)
                {

                    if ((bottle.isBeingCarried) && (bottle.isFull) && (bottle.isCold))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You pour the cold water onto the altar...and the altar starts to glow!!!");
                        Console.WriteLine("!!!Your bottle is now empty!!!");
                        
                        Console.WriteLine();
                        Console.WriteLine();
                        alttwo.isTurnedOn = true;
                        bottle.isFull = false;
                        if ((altone.isTurnedOn == true) && (alttwo.isTurnedOn == true) && (altthree.isTurnedOn == true))
                        {
                            Console.WriteLine();
                            Console.WriteLine("**You hear a jingling noise in the distance.");
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You do not put the correct offering onto the alter!!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        player.location = 41;
                    }


                }
                else if (player.location == 80)
                {

                    if ((stick.isBeingCarried) && (stick.isOnFire))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You touch the flame to the top of the altar...and the altar starts to glow!!!");
                        Console.WriteLine();
                        
                        Console.WriteLine();
                        altthree.isTurnedOn = true;
                        if ((altone.isTurnedOn == true) && (alttwo.isTurnedOn == true) && (altthree.isTurnedOn == true))
                        {
                            Console.WriteLine();
                            Console.WriteLine("**You hear a jingling noise in the distance.");
                            Console.WriteLine();
                        }

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You do not put the correct offering onto the alter!!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        player.location = 41;
                    }


                }

                //Player on ice location

                else if (player.location == 81)
                {

                    if ((bottle.isBeingCarried) && (bottle.isFull))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!Your water is now cold!!!");
                        Console.WriteLine();
                        Console.WriteLine();
                        bottle.isWarm = false;
                        bottle.isCold = true;

                    }


                }

                //Player on sign locations

                else if (player.location == 43)
                {

                    if ((stick.isBeingCarried) && (stick.isOnFire))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You see a sign, it reads..the keys will fall between the horns!!!");
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("You see a sign, but it is too dark to read.");
                        Console.WriteLine();
                        Console.WriteLine();
                    }


                }

                else if (player.location == 48)
                {

                    if ((stick.isBeingCarried) && (stick.isOnFire))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You see a sign, it reads..provide the correct substance to the altars, or start over!!!");
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("You see a sign, but it is too dark to read.");
                        Console.WriteLine();
                        Console.WriteLine();
                    }


                }

                else if (player.location == 5)
                {

                    if ((stick.isBeingCarried) && (stick.isOnFire))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You see a sign, it reads..East and West are thirsty, South just needs a light!!!");
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("You see a sign, but it is too dark to read.");
                        Console.WriteLine();
                        Console.WriteLine();
                    }


                }

                else if (player.location == 62)
                {

                    if ((stick.isBeingCarried) && (stick.isOnFire))
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("!!!You see a sign, it reads..altar next to heat craves the opposite, altar next to water wishes it was a hot tub!!!");
                        Console.WriteLine();
                        Console.WriteLine();

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("You see a sign, but it is too dark to read.");
                        Console.WriteLine();
                        Console.WriteLine();
                    }


                }




            }

            else
            {
                Console.WriteLine("Invalid entry");
                Console.WriteLine();
                Console.WriteLine();
            }



        }

        private static void PickUpItem(Item item)
        {
            item.isBeingCarried = true;
            item.location = 0;
            Console.WriteLine("Picked up " + item.name);
        }

        private static void DropItem(Player player, Item item)
        {
            item.isBeingCarried = false;
            item.location = player.location;
            Console.WriteLine("Put down " + item.name);
        }




        private static void CheckForItems(Player player, Item stick, Item bottle)
        {
            if (player.location == stick.location)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You see a stick.");
            }
            else if (player.location == bottle.location)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You see a bottle.");
            }
        }


    }


}