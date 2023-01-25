
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Vector3 dir;
    public BoxCollider box;
    public Rigidbody rbEnemy;

    public bool isTakeDmg;

    public bool enemy2;
    public bool scrollLateralIz;
    public bool scrollLateralDe;
    public bool scrollLateralAl;
    public bool scrollLateralDetr;

    //public bool vertical;
    //public bool horizontal;

    public GameManager manager;
    void Start()
    {
        if (enemy2 == true)
        {
            dir = Vector3.right;

        }
        if (enemy2 == false)
        {
            dir = Vector3.left;

        }

        manager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        box = transform.GetComponent<BoxCollider>();
        rbEnemy = transform.GetComponent<Rigidbody>();
        box.enabled = true;
        isTakeDmg = false;
    }


    void Update()
    {
        //Debug.DrawLine(transform.position, Vector3.right * 3f, Color.red);
        //Debug.DrawLine(transform.position, Vector3.left * 3f, Color.red);
        if (!isTakeDmg && manager.isStarting == false)
        {
            transform.Translate(dir * 4 * Time.deltaTime);
        }


        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 1.5f, LayerMask.GetMask("ParedDerecha")))
        {
            dir = Vector3.left;
        }

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out hit, 1.5f, LayerMask.GetMask("ParedIzquierda")))
        {
            dir = Vector3.right;
        }

        
    }

    public void TakeDmg()
    {
        if (scrollLateralDetr == false)
        {
            rbEnemy.AddForce(new Vector3(0, 5, 6) * 2, ForceMode.Impulse);
        }
        if (scrollLateralAl == false)
        {
            rbEnemy.AddForce(new Vector3(0, 5, -6) * 2, ForceMode.Impulse);
        }

        if (scrollLateralIz == true)
        {
            rbEnemy.AddForce(new Vector3(-6, 5, 0) * 2, ForceMode.Impulse);
        }
        if (scrollLateralDe == true)
        {
            rbEnemy.AddForce(new Vector3(6, 5, 0) * 2, ForceMode.Impulse);
        }

        Destroy(gameObject, 1.95f);
        box.enabled = false;
        isTakeDmg = true;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            FindObjectOfType<PlayerController>().GetComponent<PlayerController>().TakeDmg(1);
        }
    }
}
