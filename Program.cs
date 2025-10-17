/* Hangman Game
    Created by: Owen Douglas
    The program will let you play hangman and choose from 3 array's of words to play with
*/

//create all the lists for each of the 3 categories 
//array's of possible words

using System.Runtime.CompilerServices;

string[] movies = {"inception", "thedarkknight", "sacario", "theprestiege", "thedarkknightrises",
"savingprivateryan", "deadpool", "tenant", "missionimpossible", "thehungergames",};

string[] videogames = {"halo", "silksong", "haloreach", "callofduty", "hollowknight", "diablo",
"fortnite", "darksouls", "eldenring", "forza", "skyrim",};

string[] brands = {"apple", "nike", "ford", "nintendo", "google", "coke", "samsung",
"disney", "microsoft", "greatvalue"};

//create the random variable and play game variable
Random random = new Random();
string playGame = "y";

//Player guess variable
string playerGuess = "";

//Initialize word, choice and letter variables 
string word = "";
List<char> gameWord = new List<char>();
string choice = "";
char guess = '-';

//Intialize theme variables
int movieTheme = 0;
int videogamesTheme = 0;
int brandsTheme = 0;

//guess limit variables
List<char> guessedLetters = new List<char>();
int wrongGuesses = 0;
int guessLimit = 7;
playerGuess = "";

//While loop to let the player continue playing
while (playGame == "y")
{
    //clear the variables before a new game
    gameWord.Clear();
    guessedLetters.Clear();
    wrongGuesses = 0;

    //let player choose category
    Console.WriteLine("Welcome to hang man, please choose a category");
    Console.WriteLine("1) Movies");
    Console.WriteLine("2) Video games");
    Console.WriteLine("3) Brands");

    //choice variable
    choice = Console.ReadLine();

    //if statements to choose each index
    if (choice == "1")
    {
        movieTheme = random.Next(0, 10);
        word = movies[movieTheme];
    }
    else if (choice == "2")
    {
        videogamesTheme = random.Next(0, 11);
        word = videogames[videogamesTheme];
    }
    else if (choice == "3")
    {
        brandsTheme = random.Next(0, 10);
        word = brands[brandsTheme];
    }

    // show the hidden word with underscores for each letter 
    foreach (char i in word)
    {
        gameWord.Add('_');
    }
    while (wrongGuesses < guessLimit && new string(gameWord.ToArray()) != word)
    {
        //show current state of the guessed word
        Console.WriteLine("Current Word: " + new string(gameWord.ToArray()));

        //Loop for losing the game or guessing the word correctly
        Console.WriteLine("Incorrect guesses left: " + (guessLimit - wrongGuesses));


        //Loop to show each guessed letter 
        Console.WriteLine("Correctly guessed letters: ");
        foreach (char x in guessedLetters)
        {
            Console.Write(x + "");
        }
        //Spacing
        Console.WriteLine();

        //Ask for letters and give slight instruction 
        Console.WriteLine("You chose " + choice);
        Console.WriteLine("All words have NO spaces and are LOWERCASE");

        //Take the input
        Console.WriteLine("Enter a letter: ");
        playerGuess = Console.ReadLine();

        //help keep track of what the player has put into string
        guess = playerGuess[0];

        //Check to see if the guess is correct
        if (word.Contains(guess.ToString()))
        {
            //update with correct guess
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] == guess)
                    gameWord[i] = guess;
            }

            Console.WriteLine("Your guess is correct!");

            guessedLetters.Add(guess);
        }
        //If its a incorrect guess
        else
        {
            wrongGuesses++;
            Console.WriteLine("Your guess is wrong!");
        }

        //word checker
        bool wordsMatch = true;
        for (int i = 0; i < word.Length; i++)
        {
            if (gameWord[i] != word[i])
            {
                wordsMatch = false;
                break;
            }
        }
    }
    //Tell the word
    if (new string(gameWord.ToArray()) == word)
    {
        Console.WriteLine("You guessed the word! It was: " + word);
    }
    else
    {
        Console.WriteLine("Game over! The word was: " + word);
    }
//ask to play again
    Console.WriteLine("Play again? y/n");
    playGame = Console.ReadLine();
}
    Console.WriteLine("Thanks for playing!");