using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leitorDeTriggersBarco : MonoBehaviour
{
    //Comunicação
    public comunicadorScripts comunicador;

    //em qual area/minigame esta o jogador
    public int jogadorNaArea = 0;
    public bool jogadorPodeIniciarMiniGame;

    public int areaRodada;
    public int ultimaAreaRodada;
    public GameObject area1;
    public GameObject area2;
    public GameObject area3;
    public GameObject area4;
    public GameObject area5;
    public bool trava;
    public bool novaArea;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "areaObjetivo01") { jogadorNaArea = 1; jogadorPodeIniciarMiniGame = true; }
        if (other.gameObject.name == "areaObjetivo02") { jogadorNaArea = 2; jogadorPodeIniciarMiniGame = true; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "areaObjetivo01") { jogadorNaArea = 0; jogadorPodeIniciarMiniGame = false; }
        if (other.gameObject.name == "areaObjetivo02") { jogadorNaArea = 0; jogadorPodeIniciarMiniGame = false; }

    }

    private void Start()
    {
        areaRodada = 1;
        trava = true;
        area1.gameObject.SetActive(true);
        ultimaAreaRodada = 0;

    }
    private void Update()
    {
        ControleDeAreas();
    }

    public void ControleDeAreas()
    {
        if (areaRodada == 1 && trava == false)
        {
            if ( areaRodada == ultimaAreaRodada) { novaArea = false; }
            if ( novaArea == false && trava == false ) { areaRodada = Random.Range(1, 6); }
            if (areaRodada != ultimaAreaRodada) { novaArea = true; }
            if (areaRodada == 1 && novaArea == true) { area1.gameObject.SetActive(true); trava = true; };
        }

        if (areaRodada == 2 && trava == false)
        {
            if (areaRodada == ultimaAreaRodada) { novaArea = false; }
            if (novaArea == false && trava == false) { areaRodada = Random.Range(1, 6); }
            if (areaRodada != ultimaAreaRodada) { novaArea = true; }
            if (areaRodada == 2 && novaArea == true) { area2.gameObject.SetActive(true); trava = true; };
        }

        if (areaRodada == 3 && trava == false)
        {
            if (areaRodada == ultimaAreaRodada) { novaArea = false; }
            if (novaArea == false && trava == false) { areaRodada = Random.Range(1, 6); }
            if (areaRodada != ultimaAreaRodada) { novaArea = true; }
            if (areaRodada == 3 && novaArea == true) { area3.gameObject.SetActive(true); trava = true; };
        }

        if (areaRodada == 4 && trava == false)
        {
            if (areaRodada == ultimaAreaRodada) { novaArea = false; }
            if (novaArea == false && trava == false) { areaRodada = Random.Range(1, 6); }
            if (areaRodada != ultimaAreaRodada) { novaArea = true; }
            if (areaRodada == 4 && novaArea == true) { area4.gameObject.SetActive(true); trava = true; };
        }

        if (areaRodada == 5 && trava == false)
        {
            if (areaRodada == ultimaAreaRodada) { novaArea = false; }
            if (novaArea == false && trava == false) { areaRodada = Random.Range(1, 6); }
            if (areaRodada != ultimaAreaRodada) { novaArea = true; }
            if (areaRodada == 5 && novaArea == true) { area5.gameObject.SetActive(true); trava = true; };
        }

        if (areaRodada != 1 && trava == true) { area1.gameObject.SetActive(false); }
        if (areaRodada != 2 && trava == true) { area2.gameObject.SetActive(false); }
        if (areaRodada != 3 && trava == true) { area3.gameObject.SetActive(false); }
        if (areaRodada != 4 && trava == true) { area4.gameObject.SetActive(false); }
        if (areaRodada != 5 && trava == true) { area5.gameObject.SetActive(false); }




    }


}
