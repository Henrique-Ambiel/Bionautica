using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshTeste : MonoBehaviour
{
    //Inimigo Seguidor
    public NavMeshAgent inimigoSeguidor;
    public Transform jogador;

    //Inimigo Aleatorio
    public NavMeshAgent inimigoAleatorio;
    public int destinoAleatorio;
    public GameObject destino1;
    public GameObject destino2;
    public GameObject destino3;
    public GameObject destino4;
    public GameObject destino5;
    public int ultimoDestino;

    public controladorMinigame01 controlador;

    //public Transform rotacaoInimigoAleatorio;
    //public Transform rotacaoInimigoSeguidor;
    //public Transform corpoInimigoAleatorio;
    //public Transform corpoInimigoSeguidor;
   

 
    void FixedUpdate()
    {
        if (controlador.mgComeçou == true)
        {
            GetInimigoSeguidor();
            GetInimigoAleatorio();
        }

        //rotacaoInimigoSeguidor.transform.rotation = corpoInimigoSeguidor.transform.rotation;
        //rotacaoInimigoAleatorio.transform.rotation = corpoInimigoAleatorio.transform.rotation;

    }

    void GetInimigoSeguidor()
    {
        inimigoSeguidor.SetDestination(jogador.transform.position);
    }
    void GetInimigoAleatorio()
    {


        if (inimigoAleatorio.transform.position.x == destino1.transform.position.x && inimigoAleatorio.transform.position.z == destino1.transform.position.z && ultimoDestino != 1)
        {
            destino1.gameObject.SetActive(false); destino2.gameObject.SetActive(true); destino3.gameObject.SetActive(true); destino4.gameObject.SetActive(true); destino5.gameObject.SetActive(true);
            destinoAleatorio = Random.Range(1, 6);
            ultimoDestino = 1;
        }

        if (inimigoAleatorio.transform.position.x == destino2.transform.position.x && inimigoAleatorio.transform.position.z == destino2.transform.position.z & ultimoDestino != 2)
        { 
            destino2.gameObject.SetActive(false); destino1.gameObject.SetActive(true); destino3.gameObject.SetActive(true); destino4.gameObject.SetActive(true); destino5.gameObject.SetActive(true);
            destinoAleatorio = Random.Range(1, 6);
            ultimoDestino = 2;
        }

        if (inimigoAleatorio.transform.position.x == destino3.transform.position.x && inimigoAleatorio.transform.position.z == destino3.transform.position.z & ultimoDestino != 3)
        {
            destino3.gameObject.SetActive(false); destino1.gameObject.SetActive(true); destino2.gameObject.SetActive(true); destino4.gameObject.SetActive(true); destino5.gameObject.SetActive(true);
            destinoAleatorio = Random.Range(1, 6);
            ultimoDestino = 3;
        }

        if (inimigoAleatorio.transform.position.x == destino4.transform.position.x && inimigoAleatorio.transform.position.z == destino4.transform.position.z & ultimoDestino != 4)
        {
            destino4.gameObject.SetActive(false); destino1.gameObject.SetActive(true); destino3.gameObject.SetActive(true); destino2.gameObject.SetActive(true); destino5.gameObject.SetActive(true);
            destinoAleatorio = Random.Range(1, 6);
            ultimoDestino = 4;
        }

        if (inimigoAleatorio.transform.position.x == destino5.transform.position.x && inimigoAleatorio.transform.position.z == destino5.transform.position.z & ultimoDestino != 5)
        {
            destino5.gameObject.SetActive(false); destino1.gameObject.SetActive(true); destino3.gameObject.SetActive(true); destino4.gameObject.SetActive(true); destino2.gameObject.SetActive(true);
            destinoAleatorio = Random.Range(1, 6);
            ultimoDestino = 5;
        }


        if (destinoAleatorio == 1 && ultimoDestino != 1)
        { inimigoAleatorio.SetDestination(destino1.transform.position); Debug.Log("Indo ao destino1"); }

        if (destinoAleatorio == 2 && ultimoDestino != 2)
        { inimigoAleatorio.SetDestination(destino2.transform.position); Debug.Log("Indo ao destino2"); }
     
       if (destinoAleatorio == 3 && ultimoDestino != 3)
        { inimigoAleatorio.SetDestination(destino3.transform.position); Debug.Log("Indo ao destino3"); }

        if (destinoAleatorio == 4 && ultimoDestino != 4)
        { inimigoAleatorio.SetDestination(destino4.transform.position); Debug.Log("Indo ao destino4"); }
     
       if (destinoAleatorio == 5 && ultimoDestino != 5) 
        { inimigoAleatorio.SetDestination(destino5.transform.position); Debug.Log("Indo ao destino5"); }


        if (destinoAleatorio == 1 && ultimoDestino == 1) { destinoAleatorio = Random.Range(1, 6); Debug.Log("Dando Reroll"); }
        if (destinoAleatorio == 2 && ultimoDestino == 2) { destinoAleatorio = Random.Range(1, 6); Debug.Log("Dando Reroll"); }
        if (destinoAleatorio == 3 && ultimoDestino == 3) { destinoAleatorio = Random.Range(1, 6); Debug.Log("Dando Reroll"); }
        if (destinoAleatorio == 4 && ultimoDestino == 4) { destinoAleatorio = Random.Range(1, 6); Debug.Log("Dando Reroll"); }
        if (destinoAleatorio == 5 && ultimoDestino == 5) { destinoAleatorio = Random.Range(1, 6); Debug.Log("Dando Reroll"); }


    }


}