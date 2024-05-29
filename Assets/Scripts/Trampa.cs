using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Trampa : MonoBehaviour
{
    private Animator animator;
    public GameManager gameManager;
    public bool atrapado;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (atrapado == true)
        {
            animator.SetBool("Atrapado", true);
        }
    }
}
