using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Controller : MonoBehaviour, Interfaces_Interactive
{
    Rigidbody _targetRigidBody;

    public float minimpulseForce;
    public float maximpulseForce;
    public int point;

    float _randomInpulseForce;


    void LoadComponentesTarget()
    {
        if(_targetRigidBody == null)
        {
            _targetRigidBody = GetComponent<Rigidbody>();
        }
    }

    void SuscritptionBySignal()
    {
        Game_Manager.instance.GameOver += GameOver;
    }

    void UnSuscriptionBySignal()
    {
        Game_Manager.instance.GameOver -= GameOver;
    }

    private void OnEnable()
    {
        LoadComponentesTarget();
        SuscritptionBySignal();
        MovementTarget();
    }

    private void OnDisable()
    {
        UnSuscriptionBySignal();
    }

    private void Start()
    {
        LimitTranformY();
    }

    void MovementTarget()
    {
        _targetRigidBody.velocity = Vector3.zero;
        _targetRigidBody.angularVelocity = Vector3.zero;

        _randomInpulseForce = Random.Range(minimpulseForce, maximpulseForce);
        _targetRigidBody.AddForce(Vector3.up * _randomInpulseForce, ForceMode.Impulse);
        _targetRigidBody.AddTorque(RandomTorque(), ForceMode.Impulse);
    }    

    Vector3 RandomTorque()
    {
        float _randomTorqueForce = 10f;
        return new Vector3(
            Random.Range(-_randomTorqueForce, _randomTorqueForce),
            Random.Range(-_randomTorqueForce, _randomTorqueForce),
            Random.Range(-_randomTorqueForce, _randomTorqueForce)
            );
    }

    void LimitTranformY()
    {
        if(transform.position.y < -12)
        {
            gameObject.SetActive(false);
        }
    }    

    public void OnInterarct()
    {
        //_targetParticleSystem.Play();
        Game_Manager.instance.AddPoints(point);
        gameObject.SetActive(false);
    }

    void GameOver()
    {
        gameObject.SetActive(false);
    }
    // de momento se queda sin particulas no tengo el nivel necesario para resolver esta parte del problema de una forma correcta, escalable y optima


}
