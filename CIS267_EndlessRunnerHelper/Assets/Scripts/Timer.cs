using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float time;
    private TMP_Text timeGUI;
    public Button restart;
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        timeGUI = GetComponent<TMP_Text>();
        timeGUI.text = time + "";


        disableButtons();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        timeGUI.text = time + "";

        if(time <= 0)
        {
            timeGUI.text = "0";
            endGame();
        }
    }

    void endGame()
    {
        Time.timeScale = 0;
        enableButtons();
    }

    void enableButtons()
    {
        restart.gameObject.SetActive(true);
        exit.gameObject.SetActive(true);
    }

    void disableButtons()
    {
        restart.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    public void restartGame()
    {
        
        SceneManager.LoadScene("SampleScene");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
