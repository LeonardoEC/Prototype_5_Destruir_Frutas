using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver_Controller : MonoBehaviour
{
    public TextMeshProUGUI TitleGameOver;
    public TextMeshProUGUI finalScore;

    string _titleGameOver = "Game Over";
    string _finalScoreText = "Putuacion final: ";


    private void Start()
    {
        DisplayTitleGameOver();
        DisplayFinalScore();
    }

    void DisplayTitleGameOver()
    {
        TitleGameOver.text = _titleGameOver;
    }

    void DisplayFinalScore()
    {
        finalScore.text = _finalScoreText + "\n" + Game_Manager.instance.score;
    }

    public void ResetGame()
    {
        Debug.Log("Le erraste a la funcion wey");
        Game_Manager.instance.ResetGame();
    }
}
