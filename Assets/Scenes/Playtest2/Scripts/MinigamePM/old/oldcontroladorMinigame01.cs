using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class controladorMinigame01 : MonoBehaviour
{
    //comunicador
    public controladorObjetivos comunicador;
    //controles
    private bool teclaW;
    private bool teclaA;
    private bool teclaS;
    private bool teclaD;
    //direções
    public bool norte;
    public bool sul;
    public bool leste;
    public bool oeste;
    //Modifiers
    public float aceleracaoPacMan = 0.0f;
    //GameObjects
    public GameObject jogador;
    public GameObject inimigoSeguidor;
    public GameObject inimigoAleatorio;
    public GameObject bolinhas;


    public bool mgComeçou;
    public navMeshTeste inimigoAI;



    //Triggers
    public leitorDeTriggerMinigame01 triggers;
    public bool jaColidido;
    public Transform rotacao;

    void Update()
    {
        if (comunicador.inMinigame == true)
        {
            GetControlesMinigame01();
            GetMovimentoMinigame01();
        }
    }
    private void GetControlesMinigame01()
    {
        teclaW = Input.GetKey(KeyCode.W);
        teclaS = Input.GetKey(KeyCode.S);
        teclaD = Input.GetKey(KeyCode.D);
        teclaA = Input.GetKey(KeyCode.A);
        if (teclaW == true) { norte = true; sul = false; leste = false; oeste = false; triggers.emColisao = false; triggers.emColisao = false; mgComeçou = true; }
        if (teclaW == true) { rotacao.eulerAngles = new Vector3(0, 180, 0); }
        if (teclaS == true) { norte = false; sul = true; leste = false; oeste = false; triggers.emColisao = false; triggers.emColisao = false; mgComeçou = true; }
        if (teclaS == true) { rotacao.eulerAngles = new Vector3(0, 0, 0); }
        if (teclaD == true) { norte = false; sul = false; leste = true; oeste = false; triggers.emColisao = false; triggers.emColisao = false; mgComeçou = true; }
        if (teclaD == true) { rotacao.eulerAngles = new Vector3(0, -90, 0); }
        if (teclaA == true) { norte = false; sul = false; leste = false; oeste = true; triggers.emColisao = false; triggers.emColisao = false; mgComeçou = true; }
        if (teclaA == true) { rotacao.eulerAngles = new Vector3(0, 90, 0); }
        if (triggers.emColisao == true) { norte = false; sul = false; leste = false; oeste = false; }
    }
    private void GetMovimentoMinigame01()
    {
        if (leste == true  )
        { transform.Translate(Vector3.right * Time.deltaTime * aceleracaoPacMan); }
        if (oeste == true  )
        { transform.Translate(Vector3.left * Time.deltaTime * aceleracaoPacMan); }
        if (norte == true  )
        { transform.Translate(Vector3.forward * Time.deltaTime * aceleracaoPacMan); }
        if (sul == true  )
        { transform.Translate(Vector3.back * Time.deltaTime * aceleracaoPacMan); }
    }

    public void ResetMinigame01()
    {        
        gameObject.transform.localPosition = new Vector3(43.7f, 35.84f, 17.14f);
        inimigoAleatorio.transform.localPosition = new Vector3(43.67f, 35.65f, 4.56f);
        inimigoSeguidor.transform.localPosition = new Vector3(56.12f, 35.65f, 17f);
        foreach (Transform child in bolinhas.transform) { child.gameObject.SetActive(true); }
        triggers.pontos = 0;
        norte = false; sul = false; leste = false; oeste = false;
        rotacao.eulerAngles = new Vector3(0, 0, 0);
        mgComeçou = false;
        inimigoAI.destino2.gameObject.SetActive(true);
        inimigoAI.destino1.gameObject.SetActive(false); inimigoAI.destino4.gameObject.SetActive(false);
        inimigoAI.destino3.gameObject.SetActive(false); inimigoAI.destino5.gameObject.SetActive(false);
        inimigoAI.ultimoDestino = 0;


    }
}
