using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance {  get; private set; }
    public event Action<bool> starGame;
    public event Action GameOver;
    public event Action Reset;
    public event Action<int> onDificuations;
    public event Action<int> onScore;
    public event Action<bool> onGameOver;

    public int score { get; private set; }
    public bool gameOver { get; private set; }
    public int dificuations { get; private set; } = 0;
    void InitialiceGameManager()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Awake()
    {
        InitialiceGameManager();
    }

    private void Start()
    {
        StarSignal();
    }

    void StarSignal()
    {
        score = 0;
        gameOver = false;

        onScore?.Invoke(score);
        onGameOver?.Invoke(gameOver);
    }

    public void AddPoints(int point)
    {
        if (gameOver) return;

        if(score >= -20)
        {
            score += point;
            onScore?.Invoke(score);
        }
    }

    public void IsGameOver()
    {
        gameOver = true;
        onGameOver?.Invoke(gameOver);
        GameOver?.Invoke();
    }

    public void ResetGame()
    {
        Scene_Manager._instance.LoadScene("Prototype 5");
        Reset.Invoke();
        score = 0;
        gameOver = false;

    }

    public void SetDificult(int dificult)
    {
        dificuations = dificult;
        onDificuations?.Invoke(dificult);
        starGame?.Invoke(true);
    }
}
