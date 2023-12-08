using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class leitorDeTriggerMinigame01 : MonoBehaviour
{
    //Var colisão
    public bool jaColidido;
    public bool emColisao;
    public controladorMinigame01 controlador;
    public bool jogadorPego;
    public int pontos;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "paredeArenaMiniGame01") 
        { emColisao = true; }
        if (other.gameObject.name == "bolinhas")
        { other.gameObject.SetActive(false); pontos += 1; Debug.Log(pontos); }
        if (other.gameObject.name == "Inimigo") { Debug.Log("jogador foi pego"); jogadorPego = true; }

    }
}

