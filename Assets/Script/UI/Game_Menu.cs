using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game_Menu : MonoBehaviour
{

    public void SetDificultGame(int dificult)
    {
        Game_Manager.instance.SetDificult(dificult);
    }
}
