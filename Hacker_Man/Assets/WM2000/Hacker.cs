using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level;

    enum Screen { MainMenu, Password, Win, Error };
    Screen currentScreen = Screen.MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    { // TODO handle differently depending on screen
        Terminal.ClearScreen();
        Debug.Log("     Hello World!");
        Terminal.WriteLine("What the hack?!");
        Terminal.WriteLine("_____________________________________");
        Terminal.WriteLine("What do you want to hack today?");
        Terminal.WriteLine("Your crush facebook account? [easy]");
        Terminal.WriteLine("Public library? [medium]");
        Terminal.WriteLine("MCIS global servers? [hard]");
        Terminal.WriteLine("_____________________________________");

        Terminal.WriteLine("Press 1,2 or 3 from your keyboard");
    }
    void OnUserInput(string input)
    {
        print(input);

        if (input == "1")
        {
            level = 1;
            print("You choose 1");
            StartGame(1);
            currentScreen = Screen.Password;
        }
        else if (input == "2")
        {
            level = 2;
            print("You choose 2");
            StartGame(level);
            currentScreen = Screen.Password;
        }
        else if (input == "3")
        {
            level = 3;
            print("You choose 3");
            StartGame(level);
            currentScreen = Screen.Password;
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

    void StartGame(int level)
    {
        Terminal.WriteLine("You choose level " + level);
    }

    void InvalidInput()
    {
        level = 0;
        print("ERROR Choose 1, 2 or 3");
        Terminal.WriteLine("ERROR Choose 1, 2 or 3");
        currentScreen = Screen.MainMenu;
    }

}