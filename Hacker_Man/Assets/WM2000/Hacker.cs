using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    int level = 0;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();

    }

    void ShowMainMenu()
    {
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
            print("You choose 1");
            StartGame(1);
        }
        else if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "2")
        {
            print("You choose 2");
            StartGame(2);
        }
        else if (input == "3")
        {
            print("You choose 3");
            StartGame(3);
        }
        else
        {
            InvalidInput();
            
        }
    }

    void StartGame(int level)
    {
        Terminal.WriteLine("You choose level " + level);
    }

    void InvalidInput()
    {
        print("ERROR Choose 1, 2 or 3");
        Terminal.WriteLine("ERROR Choose 1, 2 or 3");        
    }

}