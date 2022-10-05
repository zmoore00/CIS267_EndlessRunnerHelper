using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attached to player object.
public static class PlayerScore
{
    private static int playerScore;


    public static int getPlayerScore()
    {
        return playerScore;
    }

    public static void setPlayerScore(int val)
    {
        playerScore += val;
        displayPlayerScore();
    }

    public static void displayPlayerScore()
    {
        Debug.Log("PlayerScore: " + playerScore);
    }

    public static void resetScore()
    {
        playerScore = 0;
    }
}
