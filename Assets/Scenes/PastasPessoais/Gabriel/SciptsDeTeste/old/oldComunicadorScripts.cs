using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comunicadorScripts : MonoBehaviour
{
    //Esse script se comunica entre todos os outros e controla os GameObjects
    

    //Variaveis Leitor de triggers barco
    public leitorDeTriggersBarco leitorDeTriggersBarco;
    public int jogadorNaArea;

    //variaveis do script de movimento
    public movimentoMundo movimentoMundo;

    //objetos do minigame01
    public GameObject minigame01;
    public GameObject cameraTerceiraPessoa;
    public navMeshTeste aiInimigos;
    public leitorDeTriggerMinigame01 triggerMinigame01;
    public controladorMinigame01 controladorMinigame01;
    public Text pontosToString;
    

    //controles Gerais do jogo
    public bool botaoEsc;
    public bool botaoZ;

    //variaveis deste script
    public bool jogadorEmMinigame;

    //caixas de texto
    public GameObject textoMundo;
    public GameObject textoMinigame;
    




    void Update()
    {
        GetControlesGerais();
        ControladorDeObjetos();
        ControladorTextoMinigame01();
    }

    void GetControlesGerais()
    {
        botaoEsc = Input.GetKey(KeyCode.Escape);
        botaoZ = Input.GetKey(KeyCode.Z);
    }

    void ControladorDeObjetos()
    {
        if (leitorDeTriggersBarco.jogadorNaArea == 1 && movimentoMundo.jogadorPodeControlarOBarco == true && botaoZ == true && jogadorEmMinigame == false)
        {
            aiInimigos.destinoAleatorio = 2;
            minigame01.gameObject.SetActive(true); 
            cameraTerceiraPessoa.gameObject.SetActive(false);
            textoMundo.gameObject.SetActive(false);
            textoMinigame.gameObject.SetActive(true);
            triggerMinigame01.jogadorPego = false;
            jogadorEmMinigame = true;
            leitorDeTriggersBarco.ultimaAreaRodada = leitorDeTriggersBarco.areaRodada;

        }
        if (jogadorEmMinigame == true && botaoEsc == true)
        {
            controladorMinigame01.ResetMinigame01();
            minigame01.gameObject.SetActive(false);
            cameraTerceiraPessoa.gameObject.SetActive(true);
            textoMundo.gameObject.SetActive(true);
            textoMinigame.gameObject.SetActive(false);
            jogadorEmMinigame = false;
            leitorDeTriggersBarco.jogadorNaArea = 0;
            leitorDeTriggersBarco.areaRodada = Random.Range(1, 6);
            leitorDeTriggersBarco.trava = false;

        }
        if (jogadorEmMinigame == true && triggerMinigame01.jogadorPego == true || jogadorEmMinigame == true && triggerMinigame01.pontos == 78)
        {
            controladorMinigame01.ResetMinigame01();
            minigame01.gameObject.SetActive(false);
            cameraTerceiraPessoa.gameObject.SetActive(true);
            textoMundo.gameObject.SetActive(true);
            textoMinigame.gameObject.SetActive(false);
            jogadorEmMinigame = false;
            leitorDeTriggersBarco.jogadorNaArea = 0;
            leitorDeTriggersBarco.areaRodada = Random.Range(1, 6);
            leitorDeTriggersBarco.trava = false;
        }

    }

    void ControladorTextoMinigame01()
    {
        if (triggerMinigame01.pontos < 10) { pontosToString.text = "0" + triggerMinigame01.pontos.ToString();}
        if (triggerMinigame01.pontos >= 10) { pontosToString.text =  triggerMinigame01.pontos.ToString();}



    }

 

 
   
}
