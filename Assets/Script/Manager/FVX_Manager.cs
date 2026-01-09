using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este scripte se alimenta de dos señales y una lista de gameobjets, 
/// Señal 1° = la envia el Spawn_Target: cuando pasa por el Get_Target emitira una señal de los gameObjetc que esta retornando con sus nombres
/// Lista 1° = esos nombre se almacenarar en un array, lista o diccionario y segun sus nombre se le asignara un valor(particula) que ya fueron previamente cargadas en Particles mediante el inspector las mismas deben de estar desactivadas
/// Paso 1° = Una vez asignados se seran colocandos en un metodo el cual recibira la posicion en donde deben de se colocado esa particula, activada y dada de play
/// Señal 2° = este metodo quedara publico y el player podra acceder a el pasadole por click tanto el nombre del item para identificarlo la particula que se debe posicionar como la posicion donde se hizo el click para poder activar dicha particula
/// Informacion Importante = Este script es una especie de GameObjectPool para efectos visuales, la idea es la siguiente:
///     Los Spawn tanto buenos como malos, son fijos y ellos tiene los datos de los item que estan en escena tanto activos como inactivos, necesitamos los datos de ambos para saber la cantidad exacta de targetes que tenemos para poder tener la misma cantidad de particulas y las correspondiente a cada target
///         Identificaremos los target y particulas por nombres hasta nuevo aviso o mejora
///     El player es el que tiene la ultima posicion en activo del Target, por ende cuando se haga click y sea efectivo desactivandolo, esa ultima posicion del target sera usada y pasada mediante parametro para indicar la nueva posicion de la particula antes de ser activada, reporducida y posteriormente desactivada pero su reciclaje
/// Informacion Extra = podemos obviar al player y pasar la ultima posicion conocida directamente desdel el targuet incluso asignado un id o identificador de tipo de targuet para que se mas preciso emparejarlo con su particula
///     Para realizar esto debemos de crear una funcion que se ejecute en "OnInterarct" del script Target_Controller dado que este sera el ultimo frame antes de su desactivacion
///     
/// Post Data: Tenemos que verificar o detener de inmediato la repoduccion de la particulas o crear duplicados de las mismas 
///     2 particulas por cada 1 elemento, de esta forma nos asegurameos de que si luego de ser desactivada sale la misma de forma atuomatica esta particula se pueda reproducir nuevamente sin cortar la reproduccion de la anterior
/// </summary>

public class FVX_Manager : MonoBehaviour
{
    public static FVX_Manager instance { get; private set; }

    public List<GameObject> Particles = new List<GameObject>();
    // public event Action<GameObject> OnGameTarget;


    void InitialiceFVX_Manager()
    {
        if(instance != null && instance != this)
        {
            Destroy(instance);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Awake()
    {
        InitialiceFVX_Manager();
    }





}
