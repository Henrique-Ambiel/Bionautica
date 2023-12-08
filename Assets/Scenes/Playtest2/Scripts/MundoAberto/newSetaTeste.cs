using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSetaTeste : MonoBehaviour
{
    public controladorObjetivos objetivos;
   
    public float velocidadeSeta;
    public Transform area01;
    public Transform area02;
    public Transform area03;
    public Transform area04;
    public Transform area05;
    public Transform objetivo;



    void Update()
    {

        if (area01.gameObject.activeSelf == true)
        { 
        Vector3 relativePos = area01.position - transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), velocidadeSeta * Time.deltaTime);
        }
        if (area02.gameObject.activeSelf == true)
        {
            Vector3 relativePos = area02.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos) ;
        }
        if (area03.gameObject.activeSelf == true)
        {
            Vector3 relativePos = area03.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
        if (area04.gameObject.activeSelf == true)
        {
            Vector3 relativePos = area04.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
        if (area05.gameObject.activeSelf == true)
        {
            Vector3 relativePos = area05.position - transform.position;
            transform.rotation = Quaternion.LookRotation(relativePos);
        }
    }
}
