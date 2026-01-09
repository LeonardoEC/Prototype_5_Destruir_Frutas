using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Controller : MonoBehaviour
{
    TextMeshProUGUI _textMeshPro;
    const string STARTMSJ = "Puntos";

    void LoadUIControllers()
    {
        if (_textMeshPro == null)
        {
            _textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    void SuscriptionBySignas()
    {
        Game_Manager.instance.onScore += UpdateScoreDisplay;
    }

    void UnSuscriptionBySignas()
    {
        Game_Manager.instance.onScore -= UpdateScoreDisplay;
    }

    private void OnEnable()
    {
        LoadUIControllers();
        SuscriptionBySignas();
    }

    private void OnDisable()
    {
        UnSuscriptionBySignas();
    }

    private void Start()
    {
        StartScore();
    }

    void UpdateScoreDisplay(int newScore)
    {
        _textMeshPro.text = $"{STARTMSJ}: {newScore}";
    }

    void StartScore()
    {
        _textMeshPro.text = $"{STARTMSJ}: {Game_Manager.instance.score}";
    }
}
