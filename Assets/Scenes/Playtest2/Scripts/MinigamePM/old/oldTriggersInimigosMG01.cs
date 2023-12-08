using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class triggersInimigosMG01 : MonoBehaviour
{
    public navMeshTeste aiInimigos;
   

    private void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.name == "destinoAleatorio") { aiInimigos.destinoAleatorio = Random.Range(1, 6); }
        //if (other.gameObject.name == "destinoAleatorioTeste") { Debug.Log("Entrou no teste"); }
    }



}
