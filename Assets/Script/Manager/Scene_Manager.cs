using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Scene_Manager : MonoBehaviour
{
    public static Scene_Manager _instance { get; private set; }

    // crear una lista con scenario y clasificarlos en jugables y no jugables para gestionar la UI y el comportamiento del player

    public event Action<String> OnSceneChanged;

    void InitializedSceneManager()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnUnitySceneLoaded;
        SceneManager.sceneLoaded += StartScene;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnUnitySceneLoaded;
        SceneManager.sceneLoaded -= StartScene;
    }

    private void Awake()
    {
        InitializedSceneManager();
    }


    void OnUnitySceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name == "Prototype 5")
        {
            if(!SceneManager.GetSceneByName("UI").isLoaded)
            {
                SceneManager.LoadScene("UI", LoadSceneMode.Additive);
            }
        }
    }


    void StartScene(Scene scene, LoadSceneMode mode)
    {
        OnSceneChanged?.Invoke(scene.name);
        if (scene.name == "ManagersScene")
        {
            SceneManager.LoadScene("Prototype 5");
        }
    }


    // que se debe pasar tambien por codigo la posicion de spwan donde aparecera el player
    public void LoadScene(string scene)
    {
        if(SceneManager.GetActiveScene().name == scene)
        {
            SceneManager.LoadScene(scene);

        }
    }
}
