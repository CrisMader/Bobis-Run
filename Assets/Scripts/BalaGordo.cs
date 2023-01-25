using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaGordo : MonoBehaviour
{
    PlayerController player;
    Vector3 pos;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pos, 2 * Time.deltaTime);
    }
}
