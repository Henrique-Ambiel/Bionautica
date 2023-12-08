using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoMinigameDK : MonoBehaviour
{
    private float movimentoHorizontal;
    private float movimentoVertical;
    public int velocidadeMovimento;

    public bool podeSubir;



    public Rigidbody rb;
    public GameObject objetoJogador;
    private Vector3 direcaoMovimento;

   
    void Update()
    {
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        movimentoVertical = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (podeSubir == true) { direcaoMovimento = new Vector3(0, movimentoVertical, -movimentoHorizontal); }
        if (podeSubir == false) { direcaoMovimento = new Vector3(0, 0, -movimentoHorizontal); }
        rb.AddForce(direcaoMovimento.normalized * velocidadeMovimento, ForceMode.Acceleration);
       


    }


    private void OnTriggerEnter(Collider other)
    {
       if (other.name=="ColliderEscada") { podeSubir = true; }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ColliderEscada") { podeSubir = false; }
    }
}
