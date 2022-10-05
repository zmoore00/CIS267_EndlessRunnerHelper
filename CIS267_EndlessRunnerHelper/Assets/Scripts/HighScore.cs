using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TMP_Text highscore;
    // Start is called before the first frame update
    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void setHighScore()
    {
        int curScore = PlayerScore.getPlayerScore();

        if (curScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", curScore);
            highscore.text = curScore.ToString();
        }
    }
}
