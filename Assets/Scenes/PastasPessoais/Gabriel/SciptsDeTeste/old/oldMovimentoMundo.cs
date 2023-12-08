using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class movimentoMundo : MonoBehaviour
{
    //Comunicação entre scripts
    public comunicadorScripts comunicador;
    private bool jogadorEmMinigame;


    //jogador pode se movimentar
    public bool jogadorPodeControlarOBarco = true;

    //Controles
    public float movimentoHorizontal;
    public float movimentoVertical;

    //Modifiers movimento
    public float aceleracao = 0;
    public float rotacao = 0;
    public float modRotacao = 0;

    public Rigidbody corpo;
    private Vector3 moveDirection;


    // Update is called once per frame
    void Update()
    {
        if (jogadorPodeControlarOBarco == true && jogadorEmMinigame == false)
        {
            Controles();
            Movimento();
            //MovimentoRigidBody();
        }

        GetVarComunicador();
    }


    void Controles()
    {
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        movimentoVertical = Input.GetAxisRaw("Vertical");
    }


    void Movimento () 
    {
        transform.Translate(Vector3.forward * Time.deltaTime * aceleracao * movimentoVertical);
        transform.Rotate(0.0f, rotacao, 0.0f);
        if (movimentoHorizontal > 0.0f) { rotacao = 1 * modRotacao; }
        if (movimentoHorizontal < 0.0f) { rotacao = -1 * modRotacao; }
        if (movimentoHorizontal == 0.0f) { rotacao = 0.0f; }
    }

    //void MovimentoRigidBody()
    //{
       //corpo.velocity = Vector3.forward * Time.deltaTime * aceleracao * movimentoVertical;
       //transform.Rotate(0.0f, rotacao, 0.0f);
       //if (movimentoHorizontal > 0.0f) { rotacao = 1 * modRotacao; }
       //if (movimentoHorizontal < 0.0f) { rotacao = -1 * modRotacao; }
       //if (movimentoHorizontal == 0.0f) { rotacao = 0.0f; }
    //}


    void GetVarComunicador()
    {
        jogadorEmMinigame = comunicador.jogadorEmMinigame;
    }

}
