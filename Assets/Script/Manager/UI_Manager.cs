using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance { get; private set; }

    // Control general de los canvas relacioado a la escena
    // escuchar la escena para saber cuando desactivar todos los UI(ejemplo Menu principal con sus ventanas, cinematicas, etc)

    // Control particula de los canvas relacionado a los estaods del juego
    // escuchar al game Manager para saber cuando activar o desactivar un hud o un game over

    Game_Menu _gameMenu;
    Score_Controller _scoreController;
    GameOver_Controller _gameOverController;

    bool _isGameOver;
    bool _isGameStarted;

    void LoadComponente()
    {
        if(_gameMenu == null)
        {
            _gameMenu = GetComponentInChildren<Game_Menu>(true);
        }
        if (_scoreController == null)
        {
            _scoreController = GetComponentInChildren<Score_Controller>(true);
        }
        if (_gameOverController == null)
        {
            _gameOverController = GetComponentInChildren<GameOver_Controller>(true);
        }
    }

    void SetGameStarted(bool value)
    {
        _isGameStarted = value;
        HandleUIByState();
    }

    void SetGameOver(bool value)
    {
        _isGameOver = value;
        HandleUIByState();
    }

    void SuscriptionBySignal()
    {
        Game_Manager.instance.starGame += SetGameStarted;
        Game_Manager.instance.onGameOver += SetGameOver;
        Game_Manager.instance.Reset += ResetUI;
    }

    void UnScirptiontBySignal()
    {
        Game_Manager.instance.starGame -= SetGameStarted;
        Game_Manager.instance.onGameOver -= SetGameOver;
        Game_Manager.instance.Reset -= ResetUI;
    }

    private void OnEnable()
    {
        LoadComponente();
        SuscriptionBySignal();
    }

    private void OnDisable()
    {
        UnScirptiontBySignal();
    }


    void HandleUIByState()
    {
        if(!_isGameStarted)
        {
            _gameMenu.gameObject.SetActive(false);
        }

        if (!_isGameOver && _isGameStarted)
        {
            _gameMenu.gameObject.SetActive(false);
            _scoreController.gameObject.SetActive(true);
            _gameOverController.gameObject.SetActive(false);
        }
        else if (_isGameOver)
        {
            _scoreController.gameObject.SetActive(false);
            _gameOverController.gameObject.SetActive(true);
        }
    }

    private void Start()
    {
        StarUI();
    }

    void StarUI()
    {
        _gameMenu.gameObject.SetActive(true);
        _scoreController.gameObject.SetActive(false);
        _gameOverController.gameObject.SetActive(false);
    }

    void ResetUI()
    {
        _scoreController.gameObject.SetActive(false);
        _gameOverController.gameObject.SetActive(false);
        if(!Game_Manager.instance.gameOver)
        {
            _scoreController.gameObject.SetActive(true);
        }    
    }

}
