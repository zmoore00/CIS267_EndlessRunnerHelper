using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreGUI : MonoBehaviour
{
    //using Unity editor to make this connection
    public TMP_Text score;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setScoreGUI(int x)
    {
        score.text = x.ToString();
    }
}
