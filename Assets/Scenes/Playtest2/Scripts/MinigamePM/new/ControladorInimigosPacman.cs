using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControladorInimigosPacman : MonoBehaviour
{

    public movimentoJogadorPacman movPac;
    
    //
    public NavMeshAgent inimigoSeguidor;
    public NavMeshAgent inimigoAleatorio;

    public Transform jogador;
    public int proximoDestino = 2;
    public int ultimoDestino;
    public bool rodarProxDestino;
    public Transform dest1;
    public Transform dest2;
    public Transform dest3;
    public Transform dest4;
    public Transform dest5;


    void Update()
    {
        if (movPac.gameStart == true)
        {
            RunInimigoSeguidor();
            RunInimigoAleatorio();
            RunControladorDestino();
            if (rodarProxDestino == true) { RunRng(); }
        }
    }

    private void RunInimigoSeguidor()
    {
        inimigoSeguidor.SetDestination(jogador.position);
    }

    private void RunInimigoAleatorio()
    {
        if (proximoDestino == 1) { inimigoAleatorio.SetDestination(dest1.position); }
        if (proximoDestino == 2) { inimigoAleatorio.SetDestination(dest2.position); }
        if (proximoDestino == 3) { inimigoAleatorio.SetDestination(dest3.position); }
        if (proximoDestino == 4) { inimigoAleatorio.SetDestination(dest4.position); }
        if (proximoDestino == 5) { inimigoAleatorio.SetDestination(dest5.position); }

    }

    private void RunControladorDestino()
    {
        if (proximoDestino ==1)
        {
            dest1.gameObject.SetActive(true);
            dest2.gameObject.SetActive(false);
            dest3.gameObject.SetActive(false);
            dest4.gameObject.SetActive(false);
            dest5.gameObject.SetActive(false);
        }
        if (proximoDestino == 2)
        {
            dest1.gameObject.SetActive(false);
            dest2.gameObject.SetActive(true);
            dest3.gameObject.SetActive(false);
            dest4.gameObject.SetActive(false);
            dest5.gameObject.SetActive(false);
        }
        if (proximoDestino == 3)
        {
            dest1.gameObject.SetActive(false);
            dest2.gameObject.SetActive(false);
            dest3.gameObject.SetActive(true);
            dest4.gameObject.SetActive(false);
            dest5.gameObject.SetActive(false);
        }
        if (proximoDestino == 4)
        {
            dest1.gameObject.SetActive(false);
            dest2.gameObject.SetActive(false);
            dest3.gameObject.SetActive(false);
            dest4.gameObject.SetActive(true);
            dest5.gameObject.SetActive(false);
        }
        if (proximoDestino == 5)
        {
            dest1.gameObject.SetActive(false);
            dest2.gameObject.SetActive(false);
            dest3.gameObject.SetActive(false);
            dest4.gameObject.SetActive(false);
            dest5.gameObject.SetActive(true);
        }

        if (inimigoAleatorio.transform.position.x == dest1.position.x && inimigoAleatorio.transform.position.z == dest1.position.z && proximoDestino == 1) { rodarProxDestino = true; }
        if (inimigoAleatorio.transform.position.x == dest2.position.x && inimigoAleatorio.transform.position.z == dest2.position.z && proximoDestino == 2) { rodarProxDestino = true; }
        if (inimigoAleatorio.transform.position.x == dest3.position.x && inimigoAleatorio.transform.position.z == dest3.position.z && proximoDestino == 3) { rodarProxDestino = true; }
        if (inimigoAleatorio.transform.position.x == dest4.position.x && inimigoAleatorio.transform.position.z == dest4.position.z && proximoDestino == 4) { rodarProxDestino = true; }
        if (inimigoAleatorio.transform.position.x == dest5.position.x && inimigoAleatorio.transform.position.z == dest5.position.z && proximoDestino == 5) { rodarProxDestino = true; }







    }
    private void RunRng()
    {
        ultimoDestino = proximoDestino;
        proximoDestino = Random.Range(1, 6);
        if (proximoDestino == ultimoDestino) { Random.Range(1, 6); }
        if ( proximoDestino != ultimoDestino) { rodarProxDestino = false; }

    }



   
}
