using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolitaScript : MonoBehaviour
{
    //public Vector3 dir;

    public Vector3[] puntos;
    public int ubi;

    public float velocidadMiBola;

    public GameManager manager;
    void Start()
    {
        ubi = 0;
        //dir = Vector3.forward;
        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (manager.isStarting == false)
        {
            //transform.Translate(dir * 5 * Time.deltaTime);

            transform.position = Vector3.MoveTowards(transform.position, puntos[ubi], 0.02f);
        }*/


        /*if (manager.isStarting == false)
        {
            Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(puntos[ubi].x, puntos[ubi].y, puntos[ubi].z), 2f);
            if (transform.position == puntos[ubi])
            {
                ubi++;
            }
        }*/
        if (manager.isStarting == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntos[ubi], velocidadMiBola);
            if (transform.position == puntos[ubi])
            {
                ubi++;
            }

            

        }
        


    }

    /*public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Esquina 1")
        {
            dir = Vector3.right;
        }
    }*/
}
