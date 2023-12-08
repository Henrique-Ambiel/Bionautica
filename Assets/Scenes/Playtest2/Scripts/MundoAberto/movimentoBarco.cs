using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoBarco : MonoBehaviour
{

    //comunicador
    public controladorObjetivos controladorObjetivos;


    //Controles
    private float movimentoHorizontal;
    private float movimentoVertical;
    private bool teclaZ;
    private bool teclaESC;


    // objetos e variaveis para o movimento
    public Rigidbody corpo;
    public int aceleracao;
    public Transform direcao;
    Vector3 direcaoMovimento;
    
    private float rotacao;
    public float modRotacao;
    public float dragMod;
    private float drag;


    RaycastHit hitInfo;
    Vector3 bufferHeight = Vector3.zero;

    private void BoatHeight()
    {
        if (Physics.Raycast(this.transform.position + (Vector3.up * 100), Vector3.down, out hitInfo, 1000f, 1 << 4))
        {
            if (hitInfo.transform.gameObject.name == "MarCalmo")
            {
                bufferHeight = this.transform.position;
                bufferHeight.y = hitInfo.point.y;
                this.transform.position = bufferHeight;
            }
        }
    }

    void Update()
    {
        BoatHeight();
        GetControles();
    }
    private void FixedUpdate()
    {
        if (controladorObjetivos.inMinigame == false)
        {
            GetMovimento();
        }
    }

    private void GetControles()
    {
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        movimentoVertical = Input.GetAxisRaw("Vertical");
        //teclaZ = Input.GetKeyDown(KeyCode.Z);
        //teclaESC = Input.GetKeyDown(KeyCode.Escape);

    }
    private void GetMovimento()
    {

        //if (movimentoVertical > 0) { drag = 0; }
        //drag += dragMod * Time.deltaTime;
        direcaoMovimento = direcao.forward * movimentoVertical;
        corpo.AddForce(direcaoMovimento * aceleracao , ForceMode.Acceleration);
        //corpo.drag = drag;
        
        

        transform.Rotate(0.0f, rotacao, 0.0f);
        if (movimentoHorizontal > 0.0f) { rotacao = 1 * modRotacao; }
        if (movimentoHorizontal < 0.0f) { rotacao = -1 * modRotacao; }
        if (movimentoHorizontal == 0.0f) { rotacao = 0.0f; }

    }

}
