using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game Configuration 
    string[] password_easy = { "Print", "Dogel", "Foxyg3n", "MK" };
    string[] password_medium = { "Potato", "Tomatoes", "Cucumber", "Watermelon" };
    string[] password_hard = { "Coco", "Joko", "Swinia", "Lecisz" };

   
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
            StartGame();
        }
        else if (input == "2")
        {
            password = password_medium[1];
            StartGame();
        }
        else if (input == "3")
        {
            password = password_hard[1];
            StartGame();
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

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level)
        {
            case 1:
                password = password_easy[Random.Range(0, password_easy.Length)];
                break;
            case 2:
                password = password_medium[Random.Range(0, password_medium.Length)];
                break;
            case 3:
                password = password_hard[1];
                break;
            default:
                Debug.Log("I dont know you!");
                break;
                
        }


        Terminal.WriteLine("Enter your password");
    }

    void InvalidInput()
    {
        level = 0;
        print("ERROR Choose 1, 2 or 3");
        Terminal.WriteLine("ERROR Choose 1, 2 or 3");
        currentScreen = Screen.MainMenu;
    }

        void CheckPassword(string input)
    {
        if (input == password)
        {
            Terminal.WriteLine("Well Done!");
        } 
        else 
        {
            Terminal.WriteLine("Wrong Password");
        }
    }


}