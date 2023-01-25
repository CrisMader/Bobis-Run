using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    public Vector3 dir;

    public float timerDir;


    public PlayerController player;
    void Start()
    {
        dir = Vector3.right;
    }

    
    void Update()
    {
        timerDir += Time.deltaTime;
        transform.Translate(dir * 2 * Time.deltaTime);
        if (timerDir >= 0f && timerDir <= 3f)
        {
            dir = Vector3.right;
        }
        if (timerDir >= 3f && timerDir <= 6f)
        {
            dir = Vector3.left;
        }

        if (timerDir > 6.1f)
        {
            timerDir = 0f;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            player.TakeDmg(1);
        }
    }
}
