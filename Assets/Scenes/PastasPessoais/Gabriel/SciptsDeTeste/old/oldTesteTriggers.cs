using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testeTriggers : MonoBehaviour
{
    public bool trigger;

    public void TesteEventos()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        trigger = true;
        if (other.gameObject.name == "areaObjetivo01")
        { Debug.Log("jogador entrou na esfera 01"); }
        if (other.gameObject.name == "areaObjetivo02")
        { Debug.Log("jogador entrou na esfera 02"); }
    }
    private void OnTriggerExit(Collider other)
    {
        trigger = false;
        if (other.gameObject.name == "areaObjetivo01")
        { Debug.Log("jogador saiu da esfera 01"); }
        if (other.gameObject.name == "areaObjetivo02")
        { Debug.Log("jogador saiu da esfera 02"); }
    }
}
