using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
    public float puntos;

    public Text puntosText;

    public GameObject player;

    private void Update()
    {
        puntosText.text = "X " + player.GetComponent<PlayerController>().puntos.ToString();
    }
}
