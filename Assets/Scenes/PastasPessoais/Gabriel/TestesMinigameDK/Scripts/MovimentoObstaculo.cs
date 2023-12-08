using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoObstaculo : MonoBehaviour
{
    private movDKForce conMG2;
    public float speed;
    private int direcao;


    void Update()
    {
        conMG2 = GameObject.Find("ObjetoJogador").GetComponent<movDKForce>();

        if (direcao == 0)
        {
            transform.Translate(new Vector3(0, 0, -1).normalized * Time.deltaTime * speed);
        }
        if (direcao == 1) 
        {
            transform.Translate(new Vector3(0, 0, 1).normalized * Time.deltaTime * speed);
        }

        if (conMG2.gameOver == true) { Destroy(this.gameObject); }
    }




    private void OnTriggerEnter(Collider other)
    {
       

        if (other.gameObject.name == "ObjectDespawner") {Destroy(gameObject); }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("ArenaFloorPlane3")) { direcao = 0; }
        if (collision.gameObject.name.StartsWith("ArenaFloorPlane2")) { direcao = 1; }
        if (collision.gameObject.name.StartsWith("ArenaFloorPlane1")) { direcao = 0; }




    }





}
