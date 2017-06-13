using System;
using System.Collections.Generic;

namespace Game
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("One day you are at your desk working on some code.");
            Console.WriteLine("You decide to take a break to get a quick snack.");
            Console.WriteLine("As you walk into the kitchen the light go out !");
            Console.WriteLine("Then you hear a hissing sound coming from the refrigerator.");


            //create hero here
            Hero hero = new Hero();


            Console.WriteLine("You are so shocked you can't even remember your own name...");
            Console.WriteLine("What is my name again  ??? ... Remember and type your name... if you want to live.");
            hero.heroName = Console.ReadLine();

            Console.WriteLine("Think quick what are you going to do {0}???", hero.heroName);
            Console.WriteLine("You are very afraid and tired from computing all night");

            hero.lives = 3;

            Console.WriteLine("You remember that you only have {0} lives in you.", hero.lives);


            Console.WriteLine("A wild Patrick Appears");
            alienDraw1();

            Console.WriteLine("you look around and see 3 things you can use as a weapon");
            Console.WriteLine("which weapon do you want to pick?");

            
            //Weapons weapon = new Weapons();
            string[,] weapons1 = new string[3, 2] { { "Torch (it)", "1000" }, { "Freeze (make harder)", "100" }, { "Candle (burn with prayers)", "500" } };
            string[,] weapons2 = new string[3, 2] { { "Spoon (her)", "1000" }, { "Whip Cream (on it)", "100" }, { "Fork (it)", "500" } };
            string[,] weapons3 = new string[3, 2] { { "Toothpick (poker face)", "1000" }, { "Vodka (martini)", "100" }, { "Mouth (smash)", "500" } };
            string[,] weapons4 = new string[3, 2] { { "Banana (hes slips)", "1000" }, { "Tha Look (makes him rowdy", "100" }, { "Banana (hes slips)" ,"500" } };

            //
            // string message1 = "You have melted your friend and you left behind a puddle.";

            //  , {"you made her love you so good that she die from broke heart"},{"you kill him"},{""}};
            // //



            Alien alien1 = new Alien();
            alien1.healthPoints = 1000;
            alien1.alienName = "Patrick";
            alien1.strenght = new string[1] { "Freeze (make harder)" };
            alien1.weakness = new string[2] { "Torch (it)", "Candle (burn with prayers)" };
            alien1.message =  "You have melted your friend and you left behind a puddle.";


            Alien alien2 = new Alien();
            alien2.healthPoints = 1000;
            alien2.alienName = "Anna";
            alien2.strenght = new string[1] { "Whip Cream (on it)" };
            alien2.weakness = new string[2] { "Spoon (her)", "Fork (it)" };
            alien2.message = "You made her love you so good that she died from broke heart";

            Alien alien3 = new Alien();
            alien3.healthPoints = 1000;
            alien3.alienName = "Gaga";
            alien3.strenght = new string[1] { "Vodka (martini)" };
            alien3.weakness = new string[2] { "Toothpick (poker face)", "Mouth (smash)" };
            alien3.message = "You rowdy hurt her and now shes 86'd";
            // new alien in the game
            Alien alien4 = new Alien();
            alien4.healthPoints = 1000;
            alien4.alienName = "Da Baws";
            alien4.strenght = new string[1] { "Tha Look (makes him rowdy)" };
            alien4.weakness = new string[2] { "Banana (hes slips)", "slap (feels disrespected)" };
            alien4.message = "You are now safe... good job me.";



            var stages = new List<Tuple<Alien, Hero, string[,],string,string>>();
            stages.Add(Tuple.Create(alien1, hero, weapons1,alienDraw1(),alien1.message));
            stages.Add(Tuple.Create(alien2, hero, weapons2,alienDraw2(),alien2.message));
            stages.Add(Tuple.Create(alien3, hero, weapons3,alienDraw3(),alien3.message));
            stages.Add(Tuple.Create(alien4, hero, weapons4,alienDraw4(),alien4.message));

            foreach (var stage in stages)
            {
             //Moved to method stageCompleted
                stageCompleted(stage);
            }
        }

        public static bool stageCompleted(Tuple<Alien, Hero, string[,],string,string> stage)
        {

            //Define your variables
            var alien1 = stage.Item1;
            var hero = stage.Item2;
            var weapons1 = stage.Item3;
            var enemyDraw = stage.Item4;
            var message = stage.Item5;

            while (alien1.healthPoints > 0 && hero.lives > 0)
            {
                Console.WriteLine(enemyDraw);
                Console.WriteLine("Choice A = {0} , or , Choice B {1} , or , Choice C {2}", weapons1[0, 0], weapons1[1, 0], weapons1[2, 0]);
                string selection = Console.ReadLine();
                int points = 0;
                switch (selection)
                {
                    case "a":
                        points = Convert.ToInt32(weapons1[0, 1]);
                        alien1.healthPoints = alien1.healthPoints - points;
                        Console.WriteLine("Great job! You have hit the enemy with {0} points!", points);
                        Console.WriteLine("Remaining Enemy healthPoints {0}", alien1.healthPoints);
                        //Inline Condition
                        hero.lives = alien1.healthPoints > 0 ? hero.lives - 1 : hero.lives + 1;
                        Console.WriteLine("Hero Remaining lives: {0}", hero.lives);
                        break;
                    case "b":
                        points = Convert.ToInt32(weapons1[1, 1]);
                        alien1.healthPoints = alien1.healthPoints + points;
                        Console.WriteLine("Great job! You have hit the enemy with {0} points!", points);
                        Console.WriteLine("Remaining Enemy healthPoints {0}", alien1.healthPoints);
                        //Inline Condition
                        hero.lives = alien1.healthPoints > 0 ? hero.lives - 1 : hero.lives;
                        Console.WriteLine("Hero Remaining lives: {0}", hero.lives);
                        break;
                    case "c":
                        points = Convert.ToInt32(weapons1[1, 1]);
                        alien1.healthPoints = alien1.healthPoints - points;
                        Console.WriteLine("Great job! You have hit the enemy with {0} points!", points);
                        Console.WriteLine("Remaining Enemy healthPoints {0}", alien1.healthPoints);
                        //Inline Condition
                        hero.lives = alien1.healthPoints > 0 ? hero.lives - 1 : hero.lives + 1;
                        Console.WriteLine("Hero Remaining lives: {0}", hero.lives);
                        break;
                }
            }

            if (alien1.healthPoints <= 0)
            {
                Console.WriteLine("-++----===+===----==+==----===+===----++-");
                
                Console.WriteLine("You managed to defeat -[ {0} ]- with {1} lives remaining.", alien1.alienName , hero.lives);
                Console.WriteLine("{0}",alien1.message);
                return true;
            }
            else if (hero.lives <= 0)
            {
                Console.WriteLine("You have expended your stay on this earth... goodbye.");
                return false;
            }
            return false;
        }
        public static string alienDraw1()
        {
            return @"
   _...___
 .'_ (.) _'.
/  (.) (.)  \
|  ,_____.  |      __
\     '-'   /_-_-_/ /
 '_+PATRIK+.'-_-_-\_\
 __//   \\__
(___)   (___)";
            
        }

        public static string alienDraw2()
        {
            return @"
    /\.-.../`\     /#\
   /_\ /_   \ \--.  \ \
 / /.\ /.\   \ \--. / /
/  \_/ \_/    \ \ \/ /
:(_)_______(_): | \ X
 \  \/ \/  ; ./ |  \--\
  ##__GAGA____##|...\--\     
  (,,,)(,,,)   (,,,)(,,,)";
            
        }

        public static string alienDraw3()
        {
            return @"	
		
      __.           __.
  __ {_/        __ {_/ 
  \_}\\ ___     \_}\\ ___.
  / \    / \    /  \   / |
 /  o____o  \   /  O____O \
/ #       #  \ / #       # \
| -_-_-_-_-_ | -_-_-_-_-_ |=^|^\
\    -===-==ANNA==-====- .'=.|./
 '.         .''.           .'
   '-.....-'   '-........-'
";
            
        }
        public static string alienDraw4()
        {
            return @"	
		
    _   _   _   _
   / \_/ \_/ \ / | /  ___
   +++  ++    \   /  )<i,]=---
   |  | |  ( o ) ( o )   ]
   | / /    \ /   \ / =  ] ---o
   |/ /      ) . __. .___.,=-
   \ / <>     (  __  )    .\\\
    .....vv    \/ \/      /
    :';:''' '' '' '' '' ''..
    ===w==w==\/\/\/\/\/\/.:
    (_._._._)(_._/._]])
";
            
        }
    }

    public class Hero
    {
        public string heroName
        {
            get;
            set;
        }

        public int lives
        {
            get;
            set;
        }

        public string currentWeapon
        {
            get;
            set;
        }
    }

    public class Alien
    {
        public string alienName
        {
            get;
            set;
        }

        public string[] weakness
        {
            get;
            set;
        }

        public string[] strenght
        {
            get;
            set;
        }

        public int healthPoints
        {
            get;
            set;
        }

        public string message
        {
            get;
            set;
        }
    }

}
