using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movimentoJogadorPacman : MonoBehaviour
{
    //comunicador objetivos
    public controladorObjetivos conObj;
    public ControladorInimigosPacman conInim;
    

    //controles
    private bool tecW;
    private bool tecA;
    private bool tecS;
    private bool tecD;
    private bool tecESC;
    private bool gameOver;
    public bool gameStart;

    private bool norte;
    private bool sul;
    private bool leste;
    private bool oeste;

    //Objetos
    public Rigidbody rb;
    public GameObject pacManCorpo;


    //
    public float movSpeed;
    public int pontos;
    public Text pontosToString;

    public GameObject bolinhas;
    public GameObject inimigoSeguidor;
    public GameObject inimigoAleatorio;






    void Update()
    {
        if (conObj.inMinigame==true)
        { GetControles(); }
        if (tecESC == true && conObj.inMinigame == true || gameOver==true|| pontos==78)
        { RunGameReset(); conObj.jaRodou = false; }
        RunPontoTracker();
    }

    private void FixedUpdate()
    {
        if (conObj.inMinigame == true)
        { 
            conInim.inimigoAleatorio.isStopped = false;
            conInim.inimigoSeguidor.isStopped = false;
            RunMove(); 
        }
    
    }

    private void GetControles()
    {
        tecW = Input.GetKeyDown(KeyCode.W);
        tecA = Input.GetKeyDown(KeyCode.A);
        tecS = Input.GetKeyDown(KeyCode.S);
        tecD = Input.GetKeyDown(KeyCode.D);
        tecESC = Input.GetKeyDown(KeyCode.Escape);
        
        if (tecW ==true) { norte = true;sul = false; leste =false; oeste = false; gameStart = true; }
        if (tecS== true) { norte = false; sul = true; leste = false; oeste = false; gameStart = true; }
        if (tecA == true) { norte = false; sul = false; leste = true; oeste = false; gameStart = true; }
        if (tecD == true) { norte = false; sul = false; leste = false; oeste = true; gameStart = true; }


    }
    
    private void RunMove()
    {
        if (norte==true) { rb.gameObject.transform.Translate(new Vector3(0,0,1) * movSpeed * Time.deltaTime); pacManCorpo.gameObject.transform.eulerAngles = new Vector3(0,180,0); }
        if (sul == true) { rb.gameObject.transform.Translate(new Vector3(0, 0, -1) * movSpeed * Time.deltaTime); pacManCorpo.gameObject.transform.eulerAngles = new Vector3(0, 0, 0); }
        if (leste == true) { rb.gameObject.transform.Translate(new Vector3(-1, 0, 0) * movSpeed * Time.deltaTime); pacManCorpo.gameObject.transform.eulerAngles = new Vector3(0, 90, 0); }
        if (oeste == true) { rb.gameObject.transform.Translate(new Vector3(1, 0, 0) * movSpeed * Time.deltaTime); pacManCorpo.gameObject.transform.eulerAngles = new Vector3(0, -90, 0); }

  

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="bolinhas") { other.gameObject.SetActive(false); pontos += 1; }
        if (other.name.StartsWith("Inimigo")) { gameOver = true; }
    }

    public void RunGameReset()
    {
        conObj.inMinigame = false;
        gameStart = false;
        gameOver = false;
        conInim.inimigoAleatorio.isStopped = true;
        conInim.inimigoSeguidor.isStopped = true;
        rb.transform.localPosition = new Vector3(43.7f, 35.84f, 17.14f);
        inimigoAleatorio.transform.localPosition = new Vector3(43.67f, 35.65f, 4.56f);
        inimigoSeguidor.transform.localPosition = new Vector3(56.12f, 35.65f, 17f);
        foreach (Transform child in bolinhas.transform) { child.gameObject.SetActive(true); }
        norte = false; sul = false; leste = false; oeste = false;
        conInim.dest1.gameObject.SetActive(false); conInim.dest1.gameObject.SetActive(true); conInim.dest1.gameObject.SetActive(false);
        conInim.dest1.gameObject.SetActive(false); conInim.dest1.gameObject.SetActive(false);
        pontos = 0;
        conObj.minigame01.gameObject.SetActive(false);


    }

    private void RunPontoTracker()
    {
        if (pontos<=9) { pontosToString.text = "0" + pontos.ToString();}
        if (pontos >= 10) { pontosToString.text = pontos.ToString(); }



    }




}
