// ETML
// Author : Kyllian Gregoire
// Date : 29.08.2025



using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETML_Secret_Code_Kyllian_gregoire
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int[] guess = new int[4];
            int[] secretCode;
            int levelChoose;
            byte userTry;
            bool playAgain;
            bool find;
            string input;
            string answer;
            userTry = 0;
            find = true;

            playAgain = true;
            while (playAgain) // While the user want to play again
            {
                Console.Title = "Secret Code ─ Règles";
                // First ASCII Code draw
                Console.WriteLine("╔════════════ Kyllian Gregoire ═════════════╗");
                Console.WriteLine("║                                           ║");
                Console.WriteLine("║    Bienvnenue dans le jeu : Secret Code   ║");
                Console.WriteLine("║                                           ║");
                Console.WriteLine("╚═══════════════════════════════════════════╝");

                // ╔═════════════════════════════════════════ Rules ════════════════════════════════════════════╗

                // Rules Section
                Console.WriteLine(); // Separator
                Console.WriteLine("Un Code secret a été composé aléatoirement et est composé de 4 chiffre.");
                Console.WriteLine("À toi de le découvrire en 10 essais maximum !");
                Console.WriteLine(); // Separator 
                Console.WriteLine("À chaque essai, tu reçois un indice selon le niveau choisis.");

                Console.WriteLine(""); // Separator 
                Console.WriteLine("Pour les niveaux 1 et 3 avec un indices visibles : \n");

                // Hint Section
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("■");
                Console.ResetColor();
                Console.Write(" : chiffre bien placé \n");

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("■");
                Console.ResetColor();
                Console.Write(" : chiffre correct mais mal placé\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
                Console.ResetColor();
                Console.Write(" : chiffre incorrecte \n");

                // Level 1 and 3 Exemple

                Console.WriteLine("\nExemple :");
                Console.WriteLine("Code Secret : 1234 ( Code Caché )");
                Console.WriteLine("Votre Essai : 1430");
                Console.WriteLine("Indice :");

                // Colored Cubes

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("■");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("■");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("■");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("■");
                Console.ResetColor();
                Console.Write(" ( 2 bien placés | 1 mal placé | 1 incorrecte )\n");

                // Level 2 and 4 Exemple

                Console.WriteLine(); // Separator
                Console.WriteLine("Pour les niveaux 2 et 4 avec indices discrets :\n");

                Console.WriteLine("Exemple :");
                Console.WriteLine("Code Secret : 5413 ( Code Caché )");
                Console.WriteLine("Votre Essai : 4130");

                Console.WriteLine("Indice :");

                // Colored Text

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("→ 0 bien placé(s) | 3 mal placé(s | 1 incorrecte)\n");
                Console.ResetColor();

                // "Enter To Play" Text

                Console.WriteLine("Appuyez sur 'ENTRÉ' pour jouer");
                
                
                Console.ReadLine();


                // ╚═════════════════════════════════════ End Of Rules ═════════════════════════════════════════╝

                // ╔═════════════════════════════════════════ Selection Of The level ════════════════════════════════════════════╗

                
                Console.Clear();



                {

                    Console.Title = "Secret Code ─ Choix du niveau";
                    // "Choose Your Level" Text
                    Console.WriteLine("=== SECRET CODE ===");
                    Console.WriteLine(); // Separator

                    Console.WriteLine("Choisi un niveau");
                    Console.WriteLine("1. Débutant\t\t( 1 à 6, sans doublons, indices, visibles )");
                    Console.WriteLine("2. Intermédiaire\t( 1 à 6, sans doublons, indices discrets )");
                    Console.WriteLine("3. Avancé\t\t( 1 à 8, avec doublonsm indices visibles )");
                    Console.WriteLine("4. Expert\t\t( 1 à 9, avec doublons, indices discrets )");
                    Console.WriteLine(); // Separator

                    Console.WriteLine("Votre choix ( De 1 à 4 )");

                    input = Console.ReadLine();
                    while (!int.TryParse(input, out levelChoose) || levelChoose < 1 || levelChoose > 4)
                    {
                        Console.WriteLine("Entrée invalide. Tapez un nombre en 1 et 4.");
                        Console.WriteLine("Votre choix ( De 1 à 4 sans Texte )"); // We reask the choice of the user
                        input = Console.ReadLine(); // We reread the selection
                    }

                }

                // ╚══════════════════════════════════════ End Of Selection Of The level ════════════════════════════════════════╝


                // ╔═════════════════════════════════════════ Level Choosen By The User ════════════════════════════════════════════╗
                
                

                Random random = new Random();
                secretCode = new int[4];
                Console.WriteLine("Vous avez choisi le niveau {0}\n", levelChoose);

                LoosingTime();


                Console.WriteLine("=== Secret Code ─ Niveau {0} ===\n", levelChoose);
                switch (levelChoose) // It will be dispatch the user to the right level
                {

                    case 1: // Level 1
                        SecretCodeOne(secretCode);

                        Console.Title = "Secret Code ─ Level 1 " + secretCode[0] + secretCode[1] + secretCode[2] + secretCode[3]; // We change the title of the console to show the level
                        
                        find = UserTryOne(find, guess, secretCode, levelChoose);
                        
                        break;
                    case 2: // Level 2
                        SecretCodeOne(secretCode);
                        
                        Console.Title = "Secret Code ─ Level 2" + secretCode[0] + secretCode[1] + secretCode[2] + secretCode[3];
                       
                        find = UserTryTwo(find, guess, secretCode, levelChoose);
                        
                        break;
                    case 3: // Level 3
                        SecretCodeTwo(secretCode);

                        Console.Title = "Secret Code ─ Level 3" + secretCode[0] + secretCode[1] + secretCode[2] + secretCode[3];
                       
                        find = UserTryOne(find, guess, secretCode, levelChoose);
                        
                        break;
                    case 4: // Level 4
                        SecretCodeTwo(secretCode);
                        
                        Console.Title = "Secret Code ─ Level 4 : " + secretCode[0] + secretCode[1] + secretCode[2] + secretCode[3];
                       
                        find = UserTryTwo(find, guess, secretCode, levelChoose);
                        
                        break;
                }
                if (!find) // If the user didn't find the secret code then
                {
                    Console.WriteLine("\nX Dommage ! Vous avez épuisé tous vos essais.\n");
                    Console.WriteLine("Le code secret était : " + secretCode[0] + secretCode[1] + secretCode[2] + secretCode[3]);
                    Console.WriteLine("\nVoulez-vous rejouer ? (o/n)");
                    answer = Console.ReadLine();
                    do
                    {
                        if (playAgain = answer.Trim().ToLower() == "o" || answer.Trim().ToLower() == "oui" || answer == "1")
                        {
                            Console.Clear();
                            Console.WriteLine("Vous allez être redirigé au menu des règles.\n");
                            Thread.Sleep(2000);
                        }// do automaticaly the return to the rules screen
                        else if (playAgain = answer.Trim().ToLower() == "n" || answer.Trim().ToLower() == "non" || answer == "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Merci d'avoir joué ! À bientôt.");
                            Thread.Sleep(2000); // Wait for 2 seconds before closing
                            playAgain = false;
                        }
                    } while (answer.Trim().ToLower() != "o" && answer.Trim().ToLower() != "n");
                }
                else
                {
                    do
                    {
                        Console.WriteLine("\nVoulez-vous rejouer ? (o/n)");
                        answer = Console.ReadLine();

                        if (playAgain = answer.Trim().ToLower() == "o")
                        {
                            Console.Clear();
                            Console.WriteLine("Vous allez être redirigé au menu des règles.\n");
                            Thread.Sleep(2000);
                        }// do automaticaly the return to the rules screen
                        else if (playAgain = answer.Trim().ToLower() == "n")
                        {
                            Console.Clear();
                            Console.WriteLine("Merci d'avoir joué ! À bientôt.");
                            Thread.Sleep(2000); // Wait for 2 seconds before closing
                            playAgain = false;

                        }
                    } while (answer.Trim().ToLower() != "o" && answer.Trim().ToLower() != "n");
                }
                

                // ╚══════════════════════════════════════ End Of Level Choosen By The User ════════════════════════════════════════╝
            }
        }
        static bool UserTryOne(bool find, int[] guess, int[] secretCode, int levelChoose )
        {
            byte userTry = 0;
            ShowLevelAndOtherText(levelChoose, userTry, find, secretCode, guess);
            return find;
        }
        static bool UserTryTwo(bool find, int[] guess, int[] secretCode, int levelChoose)
        {
            byte userTry = 0;
            ShowLevelAndOtherText(levelChoose, userTry, find, secretCode, guess);
            return find;
        }
        
        static bool LevelPlay(int levelChoose, int[] secretCode, string tryInput, int[] guess,bool find)
        {
            for (byte j = 0; j < 1; j++)
            {
                while (!Convert.ToBoolean(int.TryParse(tryInput, out guess[j])))
                {
                    Console.WriteLine("Entrée invalide. Tapez un nombre en 1 et 6 sans lettre.");
                    tryInput = Console.ReadLine(); // We reread the selection
                }
            }
            guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
            if (levelChoose == 1 || levelChoose == 2)
            {
                for (byte i = 0; i < 4; i++) // We generate the secret code with no duplicates
                {
                    int index = Array.IndexOf(guess, guess[i], i + 1);
                    if (index != -1)
                    {
                        Console.Write("Merci de ne pas mettre de doublons ! Merci de resaisir un nombre : ");
                        tryInput = Console.ReadLine();
                        guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
                    }

                }
            }
            while (tryInput.Length != 4)
            {
                Console.WriteLine("Merci d'entré un code à 4 chiffre");
                tryInput = Console.ReadLine();
                guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
            }
            if (tryInput.Length == 4)
            {
                for (byte i = 0; i < 1; i++) // We generate the secret code with no duplicates
                {
                    guess.ToArray();
                    int index = Array.IndexOf(guess, guess[i], i + 1);
                    if (index != -1)
                    {
                        Console.WriteLine("Merci de ne pas mettre de doublons ! Merci de resaisir un nombre : ");
                        tryInput = Console.ReadLine();
                        guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
                        break;
                    }
                    for (byte x = 0; x < 1; x++)
                    {
                        if (levelChoose == 1 || levelChoose == 2)
                        {

                            while (guess[x] < 1 || guess[x] > 6)
                            {
                                Console.Write("Vous ne pouvez pas mettre un nombre au dessus de 6 ou inférieur a 1! Veuillez ressaisir un nombre : ");
                                tryInput = Console.ReadLine();
                                guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
                            }
                        }
                        else if (levelChoose == 3)
                        {
                            while (guess[x] < 1 || guess[x] > 8)
                            {
                                Console.Write("Vous ne pouvez pas mettre un nombre au dessus de 8 ou inférieur a 1! Veuillez ressaisir un nombre : ");
                                tryInput = Console.ReadLine();
                                guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
                            }
                        }
                        else if (levelChoose == 4)
                        {
                            while (guess[x] < 1 || guess[x] > 9)
                            {
                                Console.Write("Vous ne pouvez pas mettre un nombre au dessus de 8 ou inférieur a 1! Veuillez ressaisir un nombre : ");
                                tryInput = Console.ReadLine();
                                guess = tryInput.Select(c => int.Parse(c.ToString())).ToArray();
                            }
                        }

                        ShowCubes(guess, secretCode);
                        if (guess.SequenceEqual(secretCode))
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nBravo ! Vous avez trouvé le chiffre secret");
                            Console.ResetColor();
                            find = true;

                        }
                    }
                }
            }
            return find;
        }
 
        static bool ShowLevelAndOtherText(int levelChoose, byte userTry, bool find, int[] secretCode, int[] guess)
        {
            const byte MAXTRY = 10;
            string tryInput;
            byte setCursorPosPrimary = 1;
            byte SetCursorPosSecondary = 3;
            byte wrongPlaced = 0;
            byte rightPlaced = 0;
            userTry = 0;
            find = false;
            Console.WriteLine(" ");
            Console.WriteLine("Essai: ");
            while (userTry < MAXTRY && !find) // While the user still have tries and didn't find the code
            {
                for (int i = 0; i < 4; i++) // Ajustez le nombre selon vos besoins
                {
                    Console.WriteLine(new string(' ', Console.WindowWidth - 1));
                }
                Console.Write("Essai {0}/{1} - Entrez un code à 4 chiffres : ", ++userTry, MAXTRY);
                tryInput = Console.ReadLine();
                Console.SetCursorPosition(0, setCursorPosPrimary+= 2);
                Console.SetCursorPosition(0, SetCursorPosSecondary+= 2);
                Console.WriteLine(" " + userTry + " : " + tryInput);
                if (levelChoose == 1 || levelChoose == 3)
                    find = LevelPlay(levelChoose, secretCode, tryInput, guess, find);
                if (levelChoose == 2 || levelChoose == 4)
                    find = LevelPlay(levelChoose, secretCode, tryInput, guess, find);

            }
            return find;
        }

        static void SecretCodeOne(int[] secretCode)
        {
            Random random = new Random();
            int newDigit;

            for (byte i = 0; i < 4; i++) // We generate the secret code with no duplicates
            {
                do
                {
                    newDigit = random.Next(1, 6);
                }
                while (Array.IndexOf(secretCode, newDigit, 0, i) >= 0);
                secretCode[i] = newDigit;
            }
        }
        static void SecretCodeTwo(int[] secretCode)
        {
            Random random = new Random();
            int newDigit;

            for (byte i = 0; i < 4; i++) // We generate the secret code with no duplicates
            {
                newDigit = random.Next(1, 6);
                secretCode[i] = newDigit;
            }
        }

        static void ShowText(int rightPlaced, int wrongPlaced)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("bien placé " + rightPlaced + " mal placé " + wrongPlaced + " "); // We show the number of well placed and misplaced digits
            Console.ResetColor();
        }
        static void ShowCubes(int[] guess, int[] secretCode)
        {

            int[] codeStatus = new int[4]; // 0 = incorrect, 1 = correct but misplaced, 2 = correct and well placed
            int[] resultStatus = new int[4]; // To store the status of each digit in the guess
            // First pass: check for correct and well placed digits
            if (guess.Length == 4)
            {
                for (byte i = 0; i < 4; i++)
                {
                    if (guess[i] == secretCode[i])
                    {
                        resultStatus[i] = 2; // Correct and well placed
                        codeStatus[i] = 2; // Mark this digit in the secret code as used
                    }
                }
                // Second pass: check for correct but misplaced digits

                for (byte i = 0; i < 4; i++)
                {
                    if (resultStatus[i] != 2) // Only check digits that are not already marked as correct and well placed
                    {
                        for (byte j = 0; j < 4; j++)
                        {
                            if (guess[i] == secretCode[j] && codeStatus[j] != 2) // Check if the digit exists in the secret code and is not already used
                            {
                                resultStatus[i] = 1; // Correct but misplaced
                                codeStatus[j] = 1; // Mark this digit in the secret code as used
                                break;
                            }
                        }
                    }
                }

                // Display the results with colored cubes

                for (byte i = 0; i < 4; i++)
                {
                    if (resultStatus[i] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; // Well placed
                    }
                    else if (resultStatus[i] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow; // Misplaced
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red; // Incorrect
                    }
                    Console.Write("■");
                    Console.ResetColor();
                }
            }
            
        }

        static void LoosingTime()
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Set the text color to Cyan
            for (int i = 3; i > 0; i--) // We count down from 3 to 1
            {
                Console.WriteLine("La partie commencera dans " + i + " seconde(s)\n");
                Thread.Sleep(1000); // timer of 1 second
            }
            Console.ResetColor();
            Console.Clear();
        }
    } 

}