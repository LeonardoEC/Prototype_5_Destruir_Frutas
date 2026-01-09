using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawn_Target : MonoBehaviour
{
    public List<GameObject> targets;
    List<GameObject> _targetPool = new List<GameObject>();
    bool _active = false;
    void SuscriptionBySignal()
    {
        Game_Manager.instance.GameOver += GameOver;
        Game_Manager.instance.onDificuations += setDificult;
    }
    

    void UnSuscritionBySignal()
    {
        Game_Manager.instance.GameOver -= GameOver;
        Game_Manager.instance.onDificuations -= setDificult;
    }

    private void OnEnable()
    {
        SuscriptionBySignal();
    }

    private void OnDisable()
    {
        UnSuscritionBySignal();
    }

    void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, Random.Range(0.5f,1f));
    }

    void setDificult(int setDificult)
    {
        int dificult = setDificult;

        switch (dificult)
        {
            case 0:
                StartPoolTarger(7);
                _active = true;
                break;
            case 1:
                StartPoolTarger(5);
                _active = true;
                break;
            case 2:
                StartPoolTarger(3);
                _active = true;
                break;
        }
    }

    // Mejorar con dobles fantasmas:
    // tener 10 items maximos pero solo activar la mitad, cuando uno es desactivado el siguiente es activado entrando en un bucle aleatorio
    // Explicacion se guardan 10 item, de los 10 solo se activan 5 de esos se desactiva 1 pero ese no se vuelve a activar, le da el paso al 6
    // cuando el 2 se desactiva de le da el paso al 7 y asi sucecibamente de esta forma garantizamos una aleatoriedad mas fluida en el juego
    void StartPoolTarger(int startPool)
    {
        for(int i = 0; i < startPool; i++)
        {
            GameObject target = Instantiate(targets[Random.Range(0, targets.Count)], transform);
            target.SetActive(false);
            _targetPool.Add(target);
        }
    }

    GameObject GetTarget()
    {
        /*
        for (int i = 0; i < _targetPool.Count; i++)
        {
            if (!_targetPool[i].activeInHierarchy)
            {
                // destruir el viejo desactivado
                Destroy(_targetPool[i]);
                _targetPool.RemoveAt(i);

                // instanciar uno nuevo como hijo del spawner
                GameObject newTarget = Instantiate(targets[Random.Range(0, targets.Count)], transform);
                newTarget.SetActive(false);
                _targetPool.Add(newTarget);

                return newTarget; // devolvemos el nuevo objeto
            }
        */
            foreach(GameObject target in _targetPool)
            {
                if(!target.activeInHierarchy)
                {
                    return target;
                }
            }
        return null;
    }

    void SpawnTarget()
    {
        if(_active)
        {
            GameObject target = GetTarget();
            if (target != null)
            {
                target.transform.position = new Vector3(Random.Range(-4f, 4f), 1f);
                target.transform.rotation = Quaternion.identity;
                target.SetActive(true);
            }
        }
    }

    void GameOver()
    {
        CancelInvoke("SpawnTarget");
        _active = false;
    }

    /*
    public void ReplaceTarget()
    {
        for (int i = 0; i < _targetPool.Count; i++)
        {
            if (!_targetPool[i].activeInHierarchy)
            {
                Destroy(_targetPool[i]);
                _targetPool.RemoveAt(i);

                GameObject newTarget = Instantiate(targets[Random.Range(0, targets.Count)], transform);
                newTarget.SetActive(false);
                _targetPool.Add(newTarget);
                break; // reemplazamos solo uno por ciclo
            }
        }
    }
    */


}
