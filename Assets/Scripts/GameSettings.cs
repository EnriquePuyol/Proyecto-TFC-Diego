using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSettings
{
    static bool modoDificil = false;

    public static int missionsNeeded = 0;

    public static void SetGameDifficulty(bool dif)
    {
        modoDificil = dif;

        if (dif == true)
            missionsNeeded = 1;
        else
            missionsNeeded = 5;
    }

    public static bool IsGameDifficult()
    {
        return modoDificil;
    }
}
