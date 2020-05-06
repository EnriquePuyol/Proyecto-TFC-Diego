using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    static bool modoDificil = false;

    static string str_facil = "Modo clásico";
    static string str_dificil = "Modo desafío";

    public static string ToggleDifficulty()
    {
        if (modoDificil)
        {
            modoDificil = false;
            return str_facil;
        }
        else
        {
            modoDificil = true;
            return str_dificil;
        }            
    }

    public static bool IsGameDifficult()
    {
        return modoDificil;
    }
}
