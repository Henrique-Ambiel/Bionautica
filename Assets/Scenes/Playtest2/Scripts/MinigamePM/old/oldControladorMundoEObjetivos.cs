using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorMundoEObjetivos : MonoBehaviour
{
    //Script para controlar o movimento do barco, ativação dos objetivos e cameras.

    //Declarando Objetos de jogo
    //Cameras
    public GameObject cameraTerceiraPessoa;
    public GameObject cameraTopDown;
    //Areas do objetivo
    public GameObject objetoObjetivo;
    //Objetos Minigame
    public GameObject minigame01;
    public GameObject bolinha01;

    //Minigame01
    public GameObject bonecoPacMan;

    public testeTriggers teste2;



    //Variaveis dos controles
    //Movimento
    public float controleHorizontal;
    public float controleVertical;
    //Interação com objetos
    public bool botaoInteracao;
    public bool jogadorNaArea;
    private int jogadorEstaNaArea = 0;
    //Diversos
    private bool botaoCancelar;
    //controles minigame01
    public bool norte;
    public bool sul;
    public bool oeste;
    public bool leste;
    public int aceleracaoPacMan = 10;
    //public bool colidindoComParede; <- Parar movimento quando colidir com paredes

    //Controles Gerias
    public bool teclaW;
    public bool teclaA;
    public bool teclaS;
    public bool teclaD;


    //Estado de Jogo
    public int estadoDeJogo;
    // estadoDeJogo = 1 -> mundo aberto
    // estadoDeJogo = 2 -> em minigame


    //variaveis da velocidade
    public float aceleracao = 0.0f;
    public float rotacao = 0.0f;
    public float modRotacao = 0.0f;


    //Testes
    public BoxCollider colliderJogador;
    public SphereCollider areaObjetivo01;
    public Collider colliderPacMan;


    void Start()
    {
        estadoDeJogo = 1;
        minigame01.SetActive(false);
        colliderPacMan = bonecoPacMan.gameObject.GetComponent<Collider>();
    }
    void Update()
    {
        if (minigame01.gameObject.activeSelf == true) { Debug.Log("minigame esta ativo"); }
        if (estadoDeJogo == 1)
        { GetControlesMundoAberto(); MovimentoMundoAberto(); }
        if (estadoDeJogo == 2)
        { GetControlesMinigame01(); MovimentoMinigame01(); }

        ControladorObjetivos();
        GetControlesGeral();
        if (teste2.trigger == false) { }
    }

    private void GetControlesGeral()
    {
        botaoCancelar = Input.GetKey(KeyCode.Escape);
    }

    private void GetControlesMundoAberto()
    {
        botaoInteracao = Input.GetKey(KeyCode.Z);
        controleHorizontal = Input.GetAxis("Horizontal");
        controleVertical = Input.GetAxis("Vertical");
    }
    private void MovimentoMundoAberto()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * aceleracao * controleVertical);
        transform.Rotate(0.0f, rotacao, 0.0f);
        if (controleHorizontal > 0.0f) { rotacao = 1 * modRotacao; }
        if (controleHorizontal < 0.0f) { rotacao = -1 * modRotacao; }
        if (controleHorizontal == 0.0f) { rotacao = 0.0f; }
    }
    private void ControladorObjetivos()
    {
        if (botaoInteracao == true && jogadorNaArea == true && estadoDeJogo == 1 && jogadorEstaNaArea == 1)
        {
            estadoDeJogo = 2;
            objetoObjetivo.SetActive(false);
            cameraTerceiraPessoa.SetActive(false);
            cameraTopDown.SetActive(true);
            minigame01.SetActive(true);
            norte = false;
            sul = false;
            leste = true;
            oeste = false;
        }
        if (botaoInteracao == true && jogadorNaArea == true && estadoDeJogo == 1 && jogadorEstaNaArea == 2)
        { Debug.Log("Minigame ainda não implementado"); }
        if (botaoCancelar == true && estadoDeJogo == 2)
        {
            estadoDeJogo = 1;
            objetoObjetivo.SetActive(true);
            cameraTerceiraPessoa.SetActive(true);
            cameraTopDown.SetActive(false);
            minigame01.SetActive(false);
        }

    }

    private void GetControlesMinigame01()
    {
        teclaW = Input.GetKey(KeyCode.W);
        teclaS = Input.GetKey(KeyCode.S);
        teclaD = Input.GetKey(KeyCode.D);
        teclaA = Input.GetKey(KeyCode.A);
        if (teclaW == true) { norte = true; sul = false; leste = false; oeste = false; }
        if (teclaS == true) { norte = false; sul = true; leste = false; oeste = false; }
        if (teclaD == true) { norte = false; sul = false; leste = true; oeste = false; }
        if (teclaA == true) { norte = false; sul = false; leste = false; oeste = true; }
    }
    private void MovimentoMinigame01()
    {
        if (leste == true && estadoDeJogo == 2)
        { bonecoPacMan.transform.Translate(Vector3.right * Time.deltaTime * aceleracaoPacMan); }
        if (oeste == true && estadoDeJogo == 2)
        { bonecoPacMan.transform.Translate(Vector3.left * Time.deltaTime * aceleracaoPacMan); }
        if (norte == true && estadoDeJogo == 2)
        { bonecoPacMan.transform.Translate(Vector3.forward * Time.deltaTime * aceleracaoPacMan); }
        if (sul == true && estadoDeJogo == 2)
        { bonecoPacMan.transform.Translate(Vector3.back * Time.deltaTime * aceleracaoPacMan); }
    }

    //Leitor de Triggers
    private void OnTriggerEnter(Collider other)
    {
        jogadorNaArea = true;
        if (other.gameObject.name.StartsWith("bolinhas")) { Debug.Log("jogador ganhou um ponto"); other.gameObject.SetActive(false); }
        if (other.gameObject.name == "areaObjetivo01") { jogadorEstaNaArea = 1; }
        if (other.gameObject.name == "areaObjetivo02") { jogadorEstaNaArea = 2; }
       

    }
    private void OnTriggerExit(Collider other)
    {
        jogadorNaArea = false;
        jogadorEstaNaArea = 0;
    }

    //private void OnTriggerEnter(Collider colliderPacMan)
    //{

    //}
}
