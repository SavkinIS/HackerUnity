using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Hacker : MonoBehaviour
{
    public int Level= 0;
    string UserName = "Hacker";
    public string inputPass = "";
    string curentPass = "";
    string hint = "";
    List<string> ArrPassswords_1 = new List<string> { "лайк", "дуров", "стена", "репост" };
    bool inGame = false;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnUserInput(string input)
    {
        

        if(input.ToLowerInvariant()!= "menu")
        {
            if (!inGame)
            {
                Int32.TryParse(input, out Level);
                if (Level >= 1 && Level <= 3) StartGame();
                else if(input == "") ShowMainMenu();
                else Terminal.WriteLine("Не верный выбор! \nВведи menu для выхода в меню \nили коректное значение!");
            }
            else if (inGame)
            {
                inputPass = input;
                StartGame();
            }
            else
            {
                ShowMainMenu();
                Terminal.WriteLine(input);
                Terminal.WriteLine("Не верный выбор! \nВведи menu для выхода в меню \nили коректное значение!");
            }
        }
        else
        {            
            Level = 0;
            ShowMainMenu();
        }        
    }

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine($"Привет {UserName}!");
        Terminal.WriteLine("Доброо пожаловать в симулятор хакера!\n " +
            "\nКого сегодня будем взламывать?\n" +
            "\nВведи 1 для взлома Вконтакте" +
            "\nВведи 2 для взлома ФНС" +
            "\nВведи 3 для взлома ФСБ" +
            "\nВведи menu для выхода в меню" +
             "\n\nВведите Ваш выбор");
    }

    void StartGame()
    {
        if (!inGame)
        {
            var rnd = new Random();            
            curentPass = ArrPassswords_1[rnd.Next(0,4)];
            hint = curentPass.Anagram();
            Terminal.ClearScreen();
            Terminal.WriteLine("Вы выбрали уровень " + Level);
            Terminal.WriteLine("Подсказка " + hint);
            Terminal.WriteLine("Введите правильный ответ");
            
            inGame = true;
        }
        else if (inGame)
        {
            if (inputPass == curentPass)
            {                
                Terminal.ClearScreen();
                Terminal.WriteLine(@"
__      __  _   _   _
\ \    / / | | | |/  |
 \ \/\/ /  | | |  /| |
  \_/\_/   |_| |_| |_|
   
WIN WIN WIN");
                inGame = false;
            }
            else Terminal.WriteLine("Попробуй еще! Подсказка " + hint);
        }      
        
       
    }
}
