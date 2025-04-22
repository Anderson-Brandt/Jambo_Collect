using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject GameOverPanel;

    public GameObject RecordJamboPanel;
    public Text jamboText;
    public Text recordJamboText;
    public int jamboScore;
    public int recordJambo;


    public GameObject FirstBomb;
    public GameObject SecondBomb;
    public int bombLife = 2;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        instance = this;

        if(PlayerPrefs.GetInt("Jambo", recordJambo) >= 0)
        {
            recordJambo = PlayerPrefs.GetInt("Jambo", recordJambo);
            recordJamboText.text = recordJambo.ToString();   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateJamboScore()
    {
        jamboScore++;
        jamboText.text = jamboScore.ToString();

        if(jamboScore >= PlayerPrefs.GetInt("Jambo", recordJambo))
        {
            recordJambo = jamboScore;
            recordJamboText.text = recordJambo.ToString();
            PlayerPrefs.SetInt("Jambo", recordJambo);
        }
        

    }

    public void ShowGameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        RecordJamboPanel.SetActive(true);
    }

    public void RestartGame()
    {
        GameOverPanel.SetActive(false);
        RecordJamboPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void BombHit()
    {
        bombLife--;

        if(bombLife == 1)
        {
            FirstBomb.SetActive(true);
        }

        if(bombLife <= 0)
        {
            SecondBomb.SetActive(true);
            ShowGameOver();
        }
    }
}
