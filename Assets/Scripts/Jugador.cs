using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto;
    private Animator animator;
    public new Rigidbody2D rigidbody2D;
    private int bandera = 0 ;
    public GameManager gameManager;
    public Trampa trampa;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && bandera == 1)
        {
            animator.SetBool("IsOnFloor", false);
            rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
            bandera = 0;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            animator.SetBool("IsOnFloor", true);
            bandera = 1;
        }
        if (collision.gameObject.tag == "Obstaculo")
        {
            gameManager.gameOver= true;
            trampa.atrapado = true;
        }
    }
}

