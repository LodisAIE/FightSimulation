using System;
using System.Collections.Generic;
using System.Text;

namespace FightSimulation
{
    struct Monster
    {
        public string name;
        public float health;
        public float attack;
        public float defense;
    }

    class Game
    {
        bool gameOver = false;
        Monster currentMonster1;
        Monster currentMonster2;

        //Monsters
        Monster wompus;
        Monster thwompus;
        Monster backupWompus;
        Monster unclePhil;

        int currentMonsterIndex = 0;
        int currentScene = 0;

        public void Run()
        {

            int[] arr = { 1,2,3,4,5 };
            PrintSmallestAndLargest(arr);
            Start();

            while (!gameOver)
            {
                Update();
            }

            End();
        }

        void PrintArray(int[] numArray, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(numArray[i]);
            }
        }

        void Start()
        {
            //Initialize Monsters
            wompus.name = "Wompus";
            wompus.attack = 15.0f;
            wompus.defense = 5.0f;
            wompus.health = 20.0f;


            thwompus.name = "Thwompus";
            thwompus.attack = 15.0f;
            thwompus.defense = 10.0f;
            thwompus.health = 15.0f;


            backupWompus.name = "Backup Wompus";
            backupWompus.attack = 25.6f;
            backupWompus.defense = 5.0f;
            backupWompus.health = 3.0f;


            unclePhil.name = "Uncle Phil";
            unclePhil.attack = 100000000000;
            unclePhil.defense = 0;
            unclePhil.health = 1.0f;

            ResetCurrentMonsters();
        }

        /// <summary>
        /// Called every game loop
        /// </summary>
        void Update()
        {
            UpdateCurrentScene();
            Console.Clear();
        }

        void End()
        {
            Console.WriteLine("Guhbah fren");
        }

        void DisplayUnclePhil()
        {
            Console.Write("\n" +
"                               .ck0KKXXXXNNNNNNNNXNNNXXXXXXXNNNNNNNNNNNNNNNXkc.                                         " +
"                             .ckO0KKKXXXXXNNNNNNNXXXXXXKKKKKKKXXXXNNNNNNNNNNNX0o,                                       " +
"                           .ckOO00KKKKXKKKKKKXXXXXKKKKK0000000KXXXXXXXNNNNNNNNNXKd'                                     " +
"                         .;xO0000KKK0KK000K00KKKK00000OOOOkkOOO0KKK00KXXXXNNNNXXXKk;                                    " +
"                        .lxO000000000000000000000OOOOkkOOOkkkkkOO000OO0KKKXXXXXXXK0k:.                                  " +
"                       'coxkOOOOOOOOOOOkkkOOOOOOOOOOkkkkkkkkkkkkkOOOOOOO00KKKKKKXXK0Ol.                                 " +
"                      '::coxkkkkkkkxxxxxxkkkkkkkkkkkxxxxxxkkkkkkkkkOOOOOOO000000KKK00Oo.                                " +
"                     ';;:cldxkkkxxxxxxxxxxxkkxxxxxxxxxxxxxxkkkkkkkkkkkkOOOOOOOO000000OOo.                               " +
"                    .,;;;cldxxxxxxxkkxxxxxxxxxxxxddxxxxxxkkxxkkkkkkkkkkkkkkkkkkOOOOOOOOOo.                              " +
"                    ';;;:clodddddxxxxkkxxddxxxxxddddxxxxxkkkkkkkkkkkkkkkkkkkkkkkOOOOOOOkko.                             " +
"                   .,,;;;:clodddddxxxxxxxdddddddddddxxxxxkkkkkkkkkkkkkkkkkxxkkkkkOkkkkOOOkl.                            " +
"                   .,,;;:::clooooddddxxxdddddddddddddxxxxxxxxxkkkkkkkkkkkkkkkkkkOOOkkOOOOkk:                            " +
"                   .,;;;;::cllloooooddddddddddddddddxxxxxxxxxxkkkkkkkxkkxxkkkkkkOOOOOOOOkkOd'                           " +
"                   .,;;;;;;:clllllooodddddddddddxddxxxxxxxxkkkkkkkkkxxxxxxxkkkkkkOO00000OOOk:                           " +
"                   .,,;;;;;;:cccllllooddddddddddxxxxxxxkkkkkkkkkkkkxxxxxxxxkkkkkOOOO000000OOl.                          " +
"                   .,,,,;;;;;::ccllllodddddddxxxxxxxxdxxxxxkkkkkkkxxxxxxxxxxxxxxxddoodddxkOOd.                          " +
"                   .,,,,,;,;;;::cllloooddddxxxxxdooooollllllllloddddddddddddddollc:::ccllodxx'                          " +
"                   .,,,,,,,;;::cllooooooodddddoollccllccc::;;::cccllllodddoollcc::::cccccllod:                          " +
"                   .,,,,,,,;;:cllooooooooollllccccclllllcc:;;;:::::cclooddolccc::::;;;;;;;:coo.                         " +
"                   .,,,,,;;;;:lolllllooollc:::::::;;::;;;;;,;;;::::cclooddollccclddlccc:;,;cod,                         " +
"                 .;coc;,;;;;;:llllllllllc::::;;;,;:odoccc::;;;::::cclloddddoollodxoc:::cccclox:                         " +
"                 ;ccllc:;;;;;:cllcccllllc::;;;;;;:cllc:::ccc:cclllllooddxddddoollllllooodxxxkOo.                        " +
"                .;;;;;:cc:;;;ccccccllllllllllllcllllllllllllloollloooodxxxxdddddolllllclodkO0Ok:                        " +
"                ';;;::ccc::;;:ccccclllooooddddoolllllllllooodddooooooddxxxxxdddxxddoooodkO000OOk,                       " +
"                .:::cllc::::::::cclloddddddddxxxxxxxxxxxxxxxxxxdddddddxxkO00kxxxxxxxxxkkO00KK0OOd.                      " +
"                .;:cllc:;;:c:::cccloodddddxxxkkkkkkkkkkkkkkkkxdddxxxxxkkkO0KKkxdddxxkkkkkkOO000Ok;                      " +
"                .;::ccc:;;cc:::cccllooddddxxxxxkkkkkOkkkkxddoooddxxxxxkkkOO00OO00kddxxxxkkkkOOOkk:                      " +
"                 ,::cc::::cc:::::cccloooodxxxxxxkkkOkkxxddolllodxxxxxxxxxkOOkkO0K0kdodddxxkkkxxxx:                      " +
"                 .;:ccc:::cc;;;;:::cclllloooddddxxxxxxddollcccclllllllloooddxddooooolllooddddddddc.                     " +
"                  '::ccc::::;;;;;;::ccclcllloooddddddddollccc::;;;;;,;;:cccllc:;::clcccccllooodddc.                     " +
"                  .;::ccc::;;:;;;;;:::cccccllloooooooolllllcccc::::::;;;;;;:::;;::cccc::::cllloloc.                     " +
"                   '::cccc::::;;;;;;::::::ccclllollllccccllcc::::::;;;;;;;::;;,;;;;;;:;;;;;::cccl:.                     " +
"                    ':ccc::::::;;;;;;;::::::cccllcc::;;;;;;;;;;,,;,;;,,;cccc:;,,,,,,,,,,,,,;;:::c:.                     " +
"                     ,llc:::::::::::;;;;;;::::ccc:;;,,,,,,,,,,;;;;;::::lodooolc:::;;,,,,,,,,;;;;::.                     " +
"                     .c:;;;;;::::::;;;;;;;;:::::;,,,,,''',,,,,,;;;;;;;:::ccccc:::;;;,,,,,,,,;;;;:;.                     " +
"                      ..,;;;;;:::::;;::;;;;;;;::;,,,,,,,,,,,,,,;::colodxddkOkkkxl;;;;;;,,,,,;;;:c:.                     " +
"                        .:;;;;;;;;;;;::;;;;;;;;::,,,,,,;;;;;;::cllodooxkxxkkxxddlccccc:;,,,,,;;:l;                      " +
"                        .;;;;;;,,,,,;;::;;;;;;;;;;,,,,,;::::::ccclllooddxdxdddoolllllc:;,,,,,;;c:.                      " +
"                        .;;;;;;,,,;;,;::;;;;,,,,,,,,,,,;::::::clllllooddxxxxddoooolllc;;;,,,,;:c,                       " +
"                        .:;;;;;;;;;;;;;;;;;;,,,,,,,,,,,;:ccc::ccccccllllllllllllllllc:;,,,,,;:cl'                       " +
"                      ..';;;;;;;;;;;;;;;;;;;;,,,,,,,,,,,;:::ccccc:::::;;;;;;;;;:cclc:;;,,,,;:col.                       " +
"                    .'';lo;;;;;;;;;;;;;;;;;;;;;,,,,,,,,,,;::ccccccccc:::::::;;:cclcc:;;;,,;:codc.                       " +
"                   .,,',dOo:;;;::::;;;;;;,;;,,;,,,,,;;,;,,;;::clllloolllllllccllllc::::;;;::lod;                        " +
"                  .,,,',oOOkoc::::::;;,,,,,,,,,,,,,;;;;;;,,;;;::ccllccloooooolllllcccc:::::clo:.                        " +
"                .',,,,,;dkkOOkdlc::::;;;;;;,,,;;,,,;;,,;;;;;;:::::cc::cllclolccccccllllc::col,                          " +
"               .',,,,,,,lxkkkkkkxlcc::;:;;;:;;;;;;;;;;;;::;::::::::::::::::cc::::cclooollool'                           " +
"              .',,,,,,,,:dOOOkxxkkxdl::::::cc:::::::::;;::;;:::;;;;;;;;;;,;;;;;;:clloddddoc;,.                          " +
"             .,,,,,,,,,,;:oO00Okxxxxxol:::ccc::::::c::;;;;;;;;;;;;;,,,,,,,,,,,;:cclllldxdc;,,;,.                        " +
"            .,,,,,,,,,,,,,;cxKK0Okkxxxdoolccc:ccccc:::::;;;;;;;;;,,,,,,,,,,,,;;:ccclooxOx;,,,,,;,'.........             " +
"        ...';;,,,,;;,,,,,,,,:d0XXK0Okxddxdolcc:::cccc:::;;;;;;;,,,;,,,,,',,,,;;;:clok0KN0c,,,,,,;:cclllllclcc:;;,'..... " +
"    ..',::;;;;;;;;;;;,,,,,,,,;ckKXKKKK0Okxxddolc::ccccc:::;;;;;,,,,,,,,,,,,,,,,:ldxOKXNNNOlc;,,,,,;:cllooooooooooollllcc" +
".,;::::cc:;;,;;;;;;;;,,,,,,,,,,;oOXXKXXXK0OOkkkxdolccc::c::::::;;;;;,,,,,,,;;;coxO0XNNNNNXkdo:,,,,,;:cloooooooooooooolll" +
"ccclllcc:;;,,,;;;;;,,,,,,,,,,,,,,:dOXXXXXXXKK0OOkxxddolcc::::::::::;;,,;;;:codk0KKXNNNNNNNKkkdc;,,,;:cclloooddooollooooo" +
"lllollc:;;;,,,,,;,,,,,,,,,,,,,,,,,;cxKXXXNNNNNXKK0OkkOOkxdoc:;;;;;;,,,,,;;;:lOKKKXNNNNNNNNXK0Oxl:,,,;;:ccllooooooolloooo" +
"lllcc::;;;,,,,,,,,,,,,,,,,,,,,,,,,,,;oOXXNNNNNNNNXXKK00000kl;;,,,,'''''''',,,ck0XNNNNNNNNNNNXKOdl:;;,,;::ccllooooollllll" +
"ccc::;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,;cxKXNNNNNNNNNNNXXKKKkoclodc;,''',,,,,;:;ckXNNNNNNNNNNNNXKKKOxc;,;;::cccllooollllll" +
"cc:;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,:d0XNNNNNNNNNNNNNNK000OO0koc:,,,,,,;lO0xdOXNNNNNNNNNNNNNNNN0o;;;;:::cccllollllloo" +
":::;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;cxKXNNNNNNNNNNNNK0XXXXXK00Od:,,,,,;oKXOdxKNNNNNNNNNNNNNNNXx:;;;;;:::cclllllllll" +
"::;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;lkKXXNNNNNNNNNK0KKKKXXKKKOo;,,,,,,cxOxllkXNNNNNNNNNNNNNNKo;;;;;;:::cccllllccc" +
":;;;;,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;ck0KKNNNNNNNNXKXXXXXKK00ko:;,,,,,,cxkl:cxKNNNNNNNNNNNNNXd:;;;;;:::::clllllll\n");
        }

        void ResetCurrentMonsters()
        {
            currentMonsterIndex = 0;
            //Set starting fighters
            currentMonster1 = GetMonster(currentMonsterIndex);
            currentMonsterIndex++;
            currentMonster2 = GetMonster(currentMonsterIndex);
        }

        void UpdateCurrentScene()
        {
            switch (currentScene)
            {
                case 0:
                    DisplayStartMenu();
                    break;

                case 1:
                    Battle();
                    UpdateCurrentMonsters();
                    Console.ReadKey();
                    break;

                case 2:
                    DisplayRestartMenu();
                    break;

                default:
                    Console.WriteLine("Invalid scene index");
                    break;
            }
        }

        /// <summary>
        /// Gets an input from the player based on some decision
        /// </summary>
        /// <param name="description">The context for the decision</param>
        /// <param name="option1">The first choice the player has</param>
        /// <param name="option2">The second choice the player has</param>
        /// <param name="pauseInvalid">If true, the player must press a key to continue after inputting
        /// an incorrect value</param>
        /// <returns>A number representing which of the two options was choosen. Returns 0 if an invalid input
        /// was recieved</returns>
        int GetInput(string description, string option1, string option2, bool pauseInvalid = false)
        {
            //Print the context and options
            Console.WriteLine(description);
            Console.WriteLine("1. " + option1);
            Console.WriteLine("2. " + option2);

            //Get player input
            string input = Console.ReadLine();
            int choice = 0;

            //If the player typed 1...
            if (input == "1")
            {
                //set the return variable to be 1
                choice = 1;
            }
            //If the player typed 2...
            else if(input == "2")
            {
                //...set the return variable to be 2
                choice = 2;
            }
            //If the player did not type a 1 or 2...
            else
            {
                //...let them know the input was invalid
                Console.WriteLine("Invalid Input");

                //If we want to pause when an invalid input is recieved...
                if (pauseInvalid)
                {
                    //...make the player press a key to continue
                    Console.ReadKey(true);
                }
            }

            //Return the player choice
            return choice;
        }

        void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }

        void PrintSmallestAndLargest(int[] arr)
        {
            int largest = arr[0];
            int smallest = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                {
                    largest = arr[i];
                }

                if (arr[i] < smallest)
                {
                    smallest = arr[i];
                }
            }

            Console.WriteLine("Largest: " + largest);
            Console.WriteLine("Smallest: " + smallest);
        }














        
        void PrintSmallestAndLargestFinished(int[] arr)
        {
            int largest = arr[0];
            int smallest = arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > largest)
                    largest = arr[i];
                else if (arr[i] < smallest)
                    smallest = arr[i];
            }

            Console.WriteLine("Largest: " + largest);
            Console.WriteLine("Smallest: " + smallest);
        }

        /// <summary>
        /// Displays the starting menu. Gives the player the option to start or
        /// exit the simulation.
        /// </summary>
        void DisplayStartMenu()
        {
            //Get player choice
            int choice = GetInput("Welcome to Monster Fight Simulator And Uncle Phil", "Start Simulation", "Quit Application");
            DisplayUnclePhil();
            Console.ReadKey(true);
            //If they chose to start the simulation...
            if (choice == 1)
            {
                //...start the battle scene
                currentScene = 1;
            }
            //Otherwise if they chose to exit...
            else if (choice == 2)
            {
                //...end the game
                gameOver = true;
            }
        }

        /// <summary>
        /// Displays the restart menu. Gives the player the option to restart or exit the program
        /// </summary>
        void DisplayRestartMenu()
        {
            //Get the player choice
            int choice = GetInput("Simulation over. Would you like to play again?", "Yes", "No");

            //If the player chose to restart...
            if (choice == 1)
            {
                //...set the current scene to be the start menu
                ResetCurrentMonsters();
                currentScene = 0;
            }
            //If the player chose to exit..
            else if (choice == 2)
            {
                //...end the game
                gameOver = true;
            }
        }

        

        Monster GetMonster(int monsterIndex)
        {
            Monster monster;
            monster.name = "None";
            monster.attack = 1;
            monster.defense = 1;
            monster.health = 1;

            if (monsterIndex == 0)
            {
                monster = unclePhil;
            }
            else if (monsterIndex == 1)
            {
                monster = backupWompus;
            }
            else if (monsterIndex == 2)
            {
                monster = wompus;
            }
            else if (monsterIndex == 3)
            {
                monster = thwompus;
            }

            return monster;
        }

        /// <summary>
        /// Simulates one turn in the current monster fight
        /// </summary>
        void Battle()
        {
            //Print monster1 stats
            PrintStats(currentMonster1);
            //Print monster2 stats
            PrintStats(currentMonster2);

            //Monster 1 attacks monster 2
            float damageTaken = Fight(currentMonster1, ref currentMonster2);
            Console.WriteLine(currentMonster2.name + " has taken " + damageTaken);

            //Monster 2 attacks monster 1
            damageTaken = Fight(currentMonster2, ref currentMonster1);
            Console.WriteLine(currentMonster1.name + " has taken " + damageTaken);
        }

        /// <summary>
        /// Changes one of the current fighters to be the next in the list 
        /// if it has died. Ends the game if all fighters in the list have been used.
        /// </summary>
        void UpdateCurrentMonsters()
        {
            //If monster 1 has died...
            if (currentMonster1.health <= 0)
            {
                //...increment the current monster index and swap out the monster
                currentMonsterIndex++;
                currentMonster1 = GetMonster(currentMonsterIndex);
            }
            //If monster 2 has died...
            if (currentMonster2.health <= 0)
            {
                //...increment the current monster index and swap out the monster
                currentMonsterIndex++;
                currentMonster2 = GetMonster(currentMonsterIndex);
            }
            //If either monster is set to "None" and the last monster has been set...
            if (currentMonster2.name == "None" || currentMonster1.name == "None" && currentMonsterIndex >= 4)
            {
                //...go to the restart menu
                currentScene = 2;
            }
        }

        string StartBattle(ref Monster monster1, ref Monster monster2)
        {
            string matchResult = "No Contest";

            while (monster1.health > 0 && monster2.health > 0)
            {
                //Print monster1 stats
                PrintStats(monster1);
                //Print monster2 stats
                PrintStats(monster2);

                //Monster 1 attacks monster 2
                float damageTaken = Fight(monster1, ref monster2);
                Console.WriteLine(monster2.name + " has taken " + damageTaken);

                //Monster 2 attacks monster 1

                damageTaken = Fight(monster2, ref monster1);
                Console.WriteLine(monster1.name + " has taken " + damageTaken);

                Console.ReadKey(true);
                Console.Clear();
            }

            if (monster1.health <= 0 && monster2.health <= 0)
            {
                matchResult = "Draw";
            }
            else if (monster1.health > 0)
            {
                matchResult = monster1.name;
            }
            else if (monster2.health > 0)
            {
                matchResult = monster2.name;
            }

            return matchResult;
        }

        float Fight(Monster attacker, ref Monster defender)
        {
            float damageTaken = CalculateDamage(attacker, defender);
            defender.health -= damageTaken;
            return damageTaken;
        }

        void PrintStats(Monster monster)
        {
            Console.WriteLine("Name: " + monster.name);
            Console.WriteLine("Health: " + monster.health);
            Console.WriteLine("Attack: " + monster.attack);
            Console.WriteLine("Defense: " + monster.defense);
        }

        float CalculateDamage(float attack, float defense)
        {
            float damage = attack - defense;

            if (damage <= 0)
            {
                damage = 0;
            }

            return damage;
        }

        float CalculateDamage(Monster attacker, Monster defender)
        {
            return attacker.attack - defender.defense;
        }
    }
}
