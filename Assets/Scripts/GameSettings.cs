using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    static bool modoDificil = false;

    public static bool ToggleDifficulty()
    {
        if (modoDificil)
        {
            modoDificil = false;
        }
        else
        {
            modoDificil = true;
        }

        return modoDificil;
    }

    public static bool IsGameDifficult()
    {
        return modoDificil;
    }
}
