using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Objetivos : MonoBehaviour
{
    public SphereCollider triggerTeste;
    public GameObject objetoJogador;
    public GameObject objetoObjetivo;
    private bool botaoInteracao;
    private bool jogadorNaArea;
    public SphereCollider testeDeTrigger;
    public GameObject camera01;
    public GameObject camera02;
    //private float posicaoObjetivo;
    //private float posicaoJogador;



    void Start()
    {
        objetoObjetivo.SetActive(true);
        //objetoObjetivo.
        camera01.SetActive(true);
        camera02.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        GetControles();
   
    }
    void GetControles()
    {
        botaoInteracao = Input.GetKey(KeyCode.Z);
        if (botaoInteracao == true && jogadorNaArea== true)
        { 
            objetoObjetivo.SetActive(false);
            camera01.SetActive(false);
            camera02.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        jogadorNaArea = true;
        Debug.Log("Esfera1");
        if (other.gameObject.name == "teste") { Debug.Log("esfera1"); }
        if (other.gameObject.name == "teste2") { Debug.Log("esfera2"); }
    }
    //private void OnTriggerExit(Collider other)
    //{
       // jogadorNaArea = false;
        //Debug.Log("esfera2");
    //}
}
