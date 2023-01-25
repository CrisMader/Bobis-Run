using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float h;
    public float z;

    public float hp;
    public float speed;

    public float puntos;

    public bool isInvencible;
    public bool isAttacking;
    public bool isTakeDmg;
    public bool gotoSelectLVL;
    public bool gotoLVL1;
    public bool gotoLVL2;
    public bool gotoLVL3;

    public bool finishLvlOne;
    public bool finishLvlTwo;
    public bool finishLvlBoss;
    public bool finishGame;

    public bool youCanJump;

    public GameObject maya;
    //public GameObject canvasPausa;

    public Rigidbody rb;
    public SphereCollider sphere;

    public Animator transicion;

    public Animator myAnim;

    public Animator finalEnhorabuena;

    public GameManager manager;
    void Start()
    {
        sphere = transform.GetComponent<SphereCollider>();
        youCanJump = true;
        rb = transform.GetComponent<Rigidbody>();

        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();

        sphere.enabled = false;
        isAttacking = false;

        speed = 7f;
        hp = 3f;

        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        Debug.DrawRay(transform.position, Vector3.down * 2, Color.white);
        /*if (Input.GetKeyDown(KeyCode.Space) && manager.isStarting == false && youCanJump == true)
        {
            StartCoroutine(JumpPorMisCojones());
        }*/
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPausa.SetActive(true);
            Time.timeScale = 0f;
        }

        if (canvasPausa.activeSelf == true && Input.GetKeyDown(KeyCode.Escape))
        {
            canvasPausa.SetActive(false);
            Time.timeScale = 1f;
        }*/
        
        if (!isTakeDmg && manager.isStarting == false)
        {
            Movement();
        }

        if (!isTakeDmg && !isAttacking && Input.GetKeyDown(KeyCode.Space) && youCanJump == true && manager.isStarting == false)
        {
            print("puta");
            myAnim.Play("Jump");
            rb.AddForce(Vector3.up * 7, ForceMode.Impulse);
            youCanJump = false;
        }

        RotarPJ();

        Animaciones();

        

        if (hp == 0f && !isInvencible && manager.isStarting == false)
        {
            Muerte();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && manager.isStarting == false)
        {
            Attack();
        }

        if (hp == 0f)
        {
            StartCoroutine(Muerteyeso());
        }


    }
    
    public void Animaciones()
    {
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            myAnim.Play("Run");
        }
        


        if (Input.GetKeyDown(KeyCode.D))
        {
            myAnim.Play("Run");
        }
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            myAnim.Play("Run");
        }
        

        if (Input.GetKeyDown(KeyCode.S))
        {
            myAnim.Play("Run");
        }
       
        if(!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            myAnim.Play("Idle");
        }

        //myAnim.SetFloat("SpeedX", h);

    }

   /* public void Jump()
    {
        RaycastHit hit;
        print("puta2");
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f))
        {
          
        }
    }*/

    public void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }

    public void RotarPJ()
    {
        Quaternion target = Quaternion.Euler(h, 0, z);
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles = new Vector3(0, 90, 0);

            if (Input.GetKey(KeyCode.W))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, 45, 0);
                return;
            }

            if (Input.GetKey(KeyCode.S))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, 135, 0);
                return;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.eulerAngles = new Vector3(0, -90, 0);
                speed = 0f;
                return;
            }

            speed = 7f;
            
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles = new Vector3(0, -90, 0);

            if (Input.GetKey(KeyCode.W))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, -45, 0);
                return;
            }
            if (Input.GetKey(KeyCode.S))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, -135, 0);
                return;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.eulerAngles = new Vector3(0, 45, 0);
                speed = 0f;
                return;
            }
            speed = 7f;
            
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

            if (Input.GetKey(KeyCode.A))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, -45, 0);
                return;
            }

            if (Input.GetKey(KeyCode.D))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, 45, 0);
                return;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                speed = 0f;
                return;
            }
            speed = 7f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles = new Vector3(0, 180, 0);

            if (Input.GetKey(KeyCode.D))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, 135, 0);
                return;
            }

            if (Input.GetKey(KeyCode.A))
            {
                speed = 3.5f;
                transform.eulerAngles = new Vector3(0, -135, 0);
                return;
            }

            if (Input.GetKey(KeyCode.W))
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                speed = 0f;
                return;
            }
            speed = 7f;
            
        }
    }

    public void TakeDmg(int dmg)
    {
        if (!isInvencible && !isAttacking)
        {
            myAnim.Play("TkDmg");
            hp -= dmg;
            rb.AddForce(new Vector3 (-1, 1, 0) * 6, ForceMode.Impulse);
            StartCoroutine(IsInvencible());
            StartCoroutine(stopWalk());
        }
    }
    public void Attack()
    {
       
        StartCoroutine(Ataque());
    }

    public IEnumerator Ataque()
    {
        myAnim.Play("Punch");
        isAttacking = true;
        sphere.enabled = true;

        yield return new WaitForSeconds(0.75f);

        isAttacking = false;
        sphere.enabled = false;

    }
    public IEnumerator IsInvencible()
    {
        isInvencible = true;
        yield return new WaitForSeconds(2f);
        isInvencible = false;
    }

    public IEnumerator stopWalk()
    {
        isTakeDmg = true;
        yield return new WaitForSeconds(0.75f);
        isTakeDmg = false;
    }
    public void Muerte()
    {
        gameObject.SetActive(false);
    }

    public IEnumerator Muerteyeso()
    {
        transicion.Play("Transicion 1");

        yield return new WaitForSeconds(1.25f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnTriggerEnter(Collider item)
    {
        if (item.tag == "Muerte")
        {
            hp = 0f;
        }

        if (item.tag == "Corona")
        {
            finishLvlBoss = true;
        }
        if (item.tag == "Enemy")
        {
            if (item.transform.GetComponent<EnemyController>())
            {
                item.transform.GetComponent<EnemyController>().TakeDmg();
            }
        }

        if (item.tag == "Portal 1")
        {
            gotoLVL1 = true;
        }

        if (item.tag == "Portal 2")
        {
            gotoLVL2 = true;
        }

        if (item.tag == "Portal 3")
        {
            gotoLVL3 = true;
        }

        if (item.tag == "Finish Lvl")
        {
            gotoSelectLVL = true;
        }

        if (item.tag == "Out")
        {
            finishGame = true;
        }
    }
    public IEnumerator CambioEscenaSelector()
    {
        transicion.Play("Transicion 1");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(1);
        gotoSelectLVL = false;
    }

    public IEnumerator CambioEscenaLvl1()
    {
        transicion.Play("Transicion 1");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(2);
        gotoLVL1 = false;
    }

    public IEnumerator CambioEscenaLvl3()
    {
        transicion.Play("Transicion 1");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(3);
        gotoLVL3 = false;
    }

    public IEnumerator CambioEscenaFinal()
    {
        transicion.Play("Transicion 1");
        yield return new WaitForSeconds(1.25f);
        SceneManager.LoadScene(4);
        finishLvlBoss = false;
    }
    public IEnumerator CambioEscenaOut()
    {
        transicion.Play("Transicion 1");
        yield return new WaitForSeconds(1.25f);
        finalEnhorabuena.Play("enhorabuena");
        finishGame = false;

        yield return new WaitForSeconds(2f);

        finalEnhorabuena.Play("enhorabuena out");

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }


    public void CambioEscenaLvl1Void()
    {
        StartCoroutine(CambioEscenaLvl1());
    }

    public void CambioEscenaSelectorVoid()
    {
        StartCoroutine(CambioEscenaSelector());
    }

    public void CambioEscenaLvl3Void()
    {
        StartCoroutine(CambioEscenaLvl3());
    }

    public void CambioEscenaLvlFinalVoid()
    {
        StartCoroutine(CambioEscenaFinal());
    }

    public void CambioEscenaOutVoid()
    {
        StartCoroutine(CambioEscenaOut());
    }


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bola")
        {
            hp = 0f;
        }

        if(collision.collider.tag == "Suelo")
        {
            youCanJump = true;
        }
    }
}
