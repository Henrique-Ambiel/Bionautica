using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioControler : MonoBehaviour
{

    private void Update()
    {
        GameObject[] objetosAudio = GameObject.FindGameObjectsWithTag("audio");
        if (objetosAudio.Length ==1)
        { DontDestroyOnLoad(this.gameObject); }
        if (objetosAudio.Length >1)
        { Destroy(objetosAudio[1]); }


    }
}
