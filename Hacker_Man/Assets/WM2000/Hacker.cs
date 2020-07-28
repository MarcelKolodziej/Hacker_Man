using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration 
    const string menu = "Type 'menu' to restart";

    string[] password_easy = { "Print", "Dogel", "Foxyg3n", "MK" };
    string[] password_medium = { "Potato", "Tomatoes", "Cucumber", "Watermelon" };
    string[] password_hard = { "Minecraft", "Fortnite", "LeagueOfLegends", "Diablo" };

   
    // Variables
    int level;
    string password;

    // Screens
    enum Screen { MainMenu, Password, Win, Error };
    Screen currentScreen;

    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What do you want to hack today?");
        Terminal.WriteLine("_______________________________");
        Terminal.WriteLine("1. Your crush facebook account? [easy]");
        Terminal.WriteLine("2. Public library? [medium]");
        Terminal.WriteLine("3. MCIS global servers? [hard]");
        Terminal.WriteLine("Type 1,2 or 3 from your keyboard");
    }

    // only handle the main menu
    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

  
    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
        }

        if (input == "1")
        {
            password = password_easy[1];
            AskForPassword();
        }
        else if (input == "2")
        {
            password = password_medium[1];
            AskForPassword();
        }
        else if (input == "3")
        {
            password = password_hard[1];
            AskForPassword();
        }
        else if (input == "menu")
        {
            ShowMainMenu();
            currentScreen = Screen.MainMenu;
        }
        else
        {
            InvalidInput();
            currentScreen = Screen.Error;
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();

        Terminal.WriteLine("Your password is hint:" + password.Anagram());
        Terminal.WriteLine(menu);
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = password_easy[Random.Range(0, password_easy.Length)];
                break;
            case 2:
                password = password_medium[Random.Range(0, password_medium.Length)];
                break;
            case 3:
                password = password_hard[Random.Range(0, password_hard.Length)];
                 break;
            default:
                Debug.Log("I dont know you!");
                break;
        }
    }
   void InvalidInput()
    {
        level = 0;
        Terminal.WriteLine("ERROR Choose 1, 2 or 3");
        currentScreen = Screen.MainMenu;
    }

        void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        } 
        else 
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen() {
            currentScreen = Screen.Win;
            Terminal.ClearScreen();
            ShowLevelReward();
        }

    void ShowLevelReward() {
        switch (level)
        {
            case 1:
                Terminal.WriteLine(@"
                You won a Book!
                    ______ ______
                  _/      Y      \_
                 // ~~ ~~ | ~~ ~  \\
                // ~ ~ ~~ | ~~~ ~~ \\      
               //________.|.________\\     
               `----------`-'----------'
                ");
                Terminal.WriteLine(menu);
                break;
            case 2:
                Terminal.WriteLine(@"
            You won GG!
                ");
                Terminal.WriteLine(menu);
                break;
            case 3:
                Terminal.WriteLine(@"You are the best, here is your coupon!
                ");
                break;
            default:
                Debug.LogError("Invalid level reached!");
                break;
        }
    }
}