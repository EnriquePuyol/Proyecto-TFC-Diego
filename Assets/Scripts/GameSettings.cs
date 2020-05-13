using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    static bool modoDificil = false;

    public static void SetGameDifficulty(bool dif)
    {
        modoDificil = dif;
    }

    public static bool IsGameDifficult()
    {
        return modoDificil;
    }
}
