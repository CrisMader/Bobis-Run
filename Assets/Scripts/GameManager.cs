using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator introLvl;
    public bool isStarting;

    public GameObject canvas;

    public PlayerController player;

    public GameObject canvasPausa;

    public Animator trans;


    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;

    public Animator cuentaAtras1;
    public Animator cuentaAtras2;
    public Animator cuentaAtras3;
    public Animator cuentaAtrasPlay;

    public void Start()
    {
        canvasPausa.SetActive(false);
        if (SceneManager.GetSceneByName("Lvl 1").isLoaded)
        {
            StartCoroutine(intro());
        }

        if (SceneManager.GetSceneByName("Lvl 3").isLoaded)
        {
            StartCoroutine(intro());
        }

        vida1.SetActive(true);
        vida2.SetActive(true);
        vida3.SetActive(true);
        

    }
    public void Update()
    {

        if (player.hp == 2)
        {
            vida1.SetActive(false);
        }
        if (player.hp == 1)
        {
            vida2.SetActive(false);
        }
        if (player.hp == 0)
        {
            vida3.SetActive(false);
        }
        if (SceneManager.GetSceneByName("Lvl Select").isLoaded)
        {
            if (player.gotoLVL1 == true)
            {
                player.CambioEscenaLvl1Void();
            }
            if (player.gotoLVL3 == true)
            {
                player.CambioEscenaLvl3Void();
            }
        }

        if (SceneManager.GetSceneByName("Lvl 1").isLoaded)
        {
            if (player.gotoSelectLVL == true)
            {
                player.CambioEscenaSelectorVoid();
            }
        }

        if (SceneManager.GetSceneByName("Lvl 3").isLoaded)
        {
            if (player.finishLvlBoss == true)
            {
                player.CambioEscenaLvlFinalVoid();
            }
        }

        if (SceneManager.GetSceneByName("Lvl Select Final").isLoaded)
        {
            if (player.finishGame == true)
            {
                player.CambioEscenaOutVoid();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPausa.SetActive(true);
        }
    }

    public IEnumerator intro()
    {
       
            isStarting = true;
            introLvl.Play("Outro 1");

            yield return new WaitForSeconds(1.5f);

        cuentaAtras1.Play("1");

            yield return new WaitForSeconds(1.5f);

        cuentaAtras2.Play("2");

        yield return new WaitForSeconds(1.5f);

        cuentaAtras3.Play("3");

        yield return new WaitForSeconds(1.5f);

        cuentaAtrasPlay.Play("Play");

        yield return new WaitForSeconds(1.5f);

            isStarting = false;
        
        
    }

    public void Empezar()
    {
        StartCoroutine(transicionescena());
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void SelectLevels()
    {
        SceneManager.LoadScene(1);
    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        canvasPausa.SetActive(false);
    }

    public IEnumerator transicionescena()
    {
        trans.Play("Transicion 1");
        canvas.SetActive(false);
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(1);
    }
    
}
