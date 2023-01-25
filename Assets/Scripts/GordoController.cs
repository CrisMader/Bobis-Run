using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GordoController : MonoBehaviour
{
    public float timerDisparo;
    public GameObject bala;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerDisparo += Time.deltaTime;

        //cooldown disparo
        if(timerDisparo > 2)
        {
            Disparar();
        }
    }

    public void Disparar()
    {
        timerDisparo = 0; // disparar otra vez

        Instantiate(bala, transform.position, Quaternion.identity);
    }
}
