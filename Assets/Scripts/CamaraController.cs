using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3 (player.transform.position.x, player.transform.position.y + 5, player.transform.position.z -10), 0.5f);
    }



}
