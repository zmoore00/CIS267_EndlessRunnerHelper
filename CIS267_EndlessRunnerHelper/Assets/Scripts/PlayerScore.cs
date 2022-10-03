using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Attached to player object.
public class PlayerScore : MonoBehaviour
{
    private int playerScore;
    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;
    }


    public int getPlayerScore()
    {
        return playerScore;
    }

    public void setPlayerScore(int val)
    {
        playerScore += val;
        displayPlayerScore();
    }

    public void displayPlayerScore()
    {
        Debug.Log("PlayerScore: " + playerScore);
    }
}
