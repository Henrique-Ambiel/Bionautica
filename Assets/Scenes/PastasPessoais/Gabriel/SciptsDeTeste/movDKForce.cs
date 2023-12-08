using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movDKForce : MonoBehaviour
{
    public controladorObjetivos conObj;

    private bool tecESC;
    private float movHor;
    private float movVer;
    private float tecSPC;
    private float movSpeed;
    public float movSpeedGround;
    public float movSpeedAir;
    public Rigidbody rb;
    private Vector3 move;
    private bool estaNoChao;
    public float jumpHeight=1;
    public float groundDrag;
    public float airDrag;
    public float bounce;
    private bool podeSubir;
    public float climbSpeed;
    public float maxSpeed;
    public GameObject jogadorSpawn;
    public bool gameOver;

    private bool podePular;
    private bool travaClimb;

    void Update()
    {
        if (conObj.inMinigame == true && conObj.minigameRodado == 1)
        {
            movHor = -Input.GetAxisRaw("Horizontal");
            movVer = Input.GetAxisRaw("Vertical");
            tecSPC = Input.GetAxisRaw("Jump");
            tecESC= Input.GetKeyDown(KeyCode.Escape);

        }
        if (conObj.inMinigame == true && tecESC == true|| gameOver==true)
        { RunResetGame(); }


    }

    private void FixedUpdate()
    {
        if (conObj.inMinigame == true && conObj.minigameRodado == 1)
        { RunMovimento(); }
    


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("ArenaFloorPlane")) { estaNoChao = true; movSpeed = movSpeedGround * 100; travaClimb = false; podePular = true; }
        if (collision.gameObject.name.StartsWith("ObjetoVisualObstaculo")) { gameOver = true; }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.StartsWith("ArenaFloorPlane")) { estaNoChao = false; movSpeed = movSpeedAir * 10; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ColliderEscada") { podeSubir = true; 
            rb.drag = groundDrag; }
        if (other.name =="ObjetoVitoria"||other.name=="ObjetoVisualObstaculo") { gameOver = true; }





    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "ColliderEscada") { podeSubir = false;
            }

    }

    private void RunMovimento()
    {
        move = new Vector3(0, movVer, movHor * movSpeed);
        rb.AddForce(new Vector3(0, rb.velocity.y, move.z), ForceMode.Force);
        if (estaNoChao == true && tecSPC != 0 && podePular == true) { rb.AddForce(new Vector3(0, tecSPC, 0).normalized * jumpHeight, ForceMode.Impulse); podePular = false; }

        if (podeSubir == true && movVer != 0)
        {
            if (travaClimb == false)
            {
                rb.velocity = new Vector3(0, 0, 0);
                travaClimb = true;
            }
            podePular = false;
            //rb.AddForce(new Vector3(0,movVer,0).normalized * climbSpeed * Time.deltaTime, ForceMode.Force);
            rb.useGravity = false;
            rb.gameObject.transform.Translate(new Vector3(0, movVer, 0) * climbSpeed * Time.deltaTime);


        }

        if (rb.useGravity == false && movVer == 0)
        { rb.useGravity = true; }


        if (estaNoChao == true) { rb.drag = groundDrag; }
        if (estaNoChao == false) { rb.drag = airDrag; }

        if (rb.velocity.z > maxSpeed) { rb.velocity = new Vector3(0, rb.velocity.y, maxSpeed); }
        if (rb.velocity.z < -maxSpeed) { rb.velocity = new Vector3(0, rb.velocity.y, -maxSpeed); }
    }

    public void RunResetGame()
    {
        rb.gameObject.transform.localPosition = jogadorSpawn.transform.localPosition;
        gameOver = false;
        conObj.inMinigame = false;
        foreach (GameObject obstaculo in GameObject.FindGameObjectsWithTag("ObjetoObstaculo"))
        { 
            if (obstaculo.gameObject.name.StartsWith("ObjetoVisualObstaculo"))
            {
                Destroy(obstaculo.gameObject);
            }
        }
        

        conObj.minigame02.gameObject.SetActive(false);
       


    }





}
