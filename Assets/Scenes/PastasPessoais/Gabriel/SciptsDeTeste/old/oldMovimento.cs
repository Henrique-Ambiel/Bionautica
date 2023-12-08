using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    public GameObject objetivo;
    // Variaveis Controles   
    public float controleHorizontal;
    public float controleVertical;
    //Variaveis Velocidade
    public float aceleracao = 0.0f;
    private float rotacao = 0.0f;
    public float modRotacao = 0.0f;
    //public float aceleracaoMax = 20.0f;

    private void Start()
    {
        
    }



    void Update()
    {
        GetControles();
        GetMovimento();
    }
    private void GetControles()
    {
        controleHorizontal = Input.GetAxis("Horizontal"); //Direção
        controleVertical = Input.GetAxis("Vertical"); //Aceleração
        //Vector3 direcao = new Vector3(controleHorizontal, 0f, controleVertical).normalized;
        if (controleHorizontal > 0.0f ) { rotacao = 1 * modRotacao; }
        if (controleHorizontal < 0.0f ) { rotacao = -1 * modRotacao; }
        if (controleHorizontal == 0.0f) { rotacao = 0.0f; }
    }
    private void GetMovimento()
    {
        transform.Translate (Vector3.forward * Time.deltaTime * aceleracao * controleVertical);
        //transform.Translate (Vector3.right *  Time.deltaTime * aceleracao * controleHorizontal);
        transform.Rotate (0.0f, rotacao, 0.0f);
    }
}
