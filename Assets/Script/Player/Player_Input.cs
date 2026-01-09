using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Player_Input : MonoBehaviour
{

    private void Update()
    {
        InputPlayerController();
    }


    void InputPlayerController()
    {
        if(Game_Manager.instance.gameOver == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // 1. Verificamos si el click es sobre la UI primero
                if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
                {
                    return; // Detenemos la función: el click es para la interfaz
                }

                // aprovechar esto para pasar la posicion del donde fue eliminado el target para poder activar las particulas
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    Interfaces_Interactive interarctable = hitInfo.collider.GetComponent<Interfaces_Interactive>();
                    if (interarctable != null)
                    {
                        interarctable.OnInterarct();
                    }
                }
            }
        }
    }
}
