using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class triggersObjetivos : MonoBehaviour
{

    public controladorObjetivos controlador;

    public bool jogadorNaArea;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "jogadorBarco") { controlador.jogadorNaArea = true; }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "jogadorBarco") { Debug.Log("Saiu"); controlador.jogadorNaArea = false; }

    }



}