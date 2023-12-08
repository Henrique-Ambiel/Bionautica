using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggersInimigosPacMan : MonoBehaviour
{
    // 
    public ControladorInimigosPacman cont;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="destinoAleatorio") { cont.rodarProxDestino = true; Debug.Log("CHEGOU"); }


    }


}
