using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controladorObjetivos : MonoBehaviour
{
    //controlador minigames
    public movimentoJogadorPacman contPacMan;
    public movDKForce contDK;
    
    
    
    
    //controles 
    private bool teclaZ;
    public bool jogadorNaArea;

    //RNG minigame
    public bool primeiraRun;
    public int minigameRodado;
    public int areaRodada;
    public int ultimoRodado;
    private int proximaArea;
    public bool jaRodou;
    public bool inMinigame;
    private bool outMinigame;
    public int ultimoMinigameRodado;

    //Objeto das areas
    public GameObject area01;
    public GameObject area02;
    public GameObject area03;
    public GameObject area04;
    public GameObject area05;

    //objeto dos Minigames
    public GameObject minigame01;
    public GameObject minigame02;


    public GameObject caixaTxtMundoAberto;
    public GameObject caixaTxtMinigame01;
    public GameObject caixaTxtMinigame02;



    private void Start()
    {
        primeiraRun = false;
        proximaArea = 0;
    }

    private void Update()
    {
        teclaZ = Input.GetKeyDown(KeyCode.Z);
        if (primeiraRun== true) { RunTutorial(); }
        if (primeiraRun == false) { RunGameNormal(); }
        RunMinigameManager();
        RunUIManager();
 

    }
   
    private void RunTutorial()
    {
        if (jogadorNaArea == true && teclaZ==true && inMinigame==false) { proximaArea += 1; }
        if (proximaArea== 0 )
        {
            minigameRodado = 0;
            area01.gameObject.SetActive(true);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(false); 
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(false);
           
        }
        if (proximaArea == 1 && teclaZ == true && inMinigame == false)
        {
            minigameRodado = 1;
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(true);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(false);
            
        }
        if (proximaArea == 2 && teclaZ == true && inMinigame == false)
        {
            minigameRodado = 0;
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(true);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(false);
            
        }
        if (proximaArea == 3 && teclaZ == true)
        {
            minigameRodado = 1;
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(true);
            area05.gameObject.SetActive(false);
             
        }
        if (proximaArea == 4 && teclaZ == true && inMinigame == false)
        {
            minigameRodado = 0;
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(true);
            
        }
        if (proximaArea >= 5) { areaRodada = Random.Range(1, 6);  proximaArea = 5; ultimoRodado = 5; primeiraRun = false; }
    }

    private void RunGameNormal()
    {
        if (jogadorNaArea == true && teclaZ == true && inMinigame == false && jaRodou == false)
        {
            ultimoMinigameRodado = minigameRodado;
            ultimoRodado = areaRodada;
            jogadorNaArea = false; 
            RunRNG();
        }
        RunAreaManager();
        




    }

    [SerializeField] private int setMinigame = 0;

    private void RunRNG()
    {
        minigameRodado = setMinigame;
        //areaRodada = Random.Range(1, 6);
        //if (areaRodada == ultimoRodado) { areaRodada = Random.Range(1, 6); }
        //minigameRodado = Random.Range(0, 2);
        //if (minigameRodado == ultimoMinigameRodado) { minigameRodado=Random.Range(0, 2); }
        //if (areaRodada!=ultimoRodado && minigameRodado != ultimoMinigameRodado) { jaRodou = true; }
    }
    private void RunAreaManager()
    {
        if (areaRodada == 1 && inMinigame ==false )
        {
            area01.gameObject.SetActive(true);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(false);
            
        }
        if (areaRodada == 2 && inMinigame == false)
        {
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(true);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(false);
            
        }
        if (areaRodada == 3 && inMinigame == false)
        {
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(true);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(false);
            
        }
        if (areaRodada == 4 && inMinigame == false)
        {
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(true);
            area05.gameObject.SetActive(false);
            
        }
        if (areaRodada == 5 && inMinigame == false)
        {
            area01.gameObject.SetActive(false);
            area02.gameObject.SetActive(false);
            area03.gameObject.SetActive(false);
            area04.gameObject.SetActive(false);
            area05.gameObject.SetActive(true);
            
        }
    }
    private void RunMinigameManager()
    {
     if (minigameRodado==0 && jogadorNaArea == true && teclaZ == true && inMinigame==false)
        {
            minigame01.gameObject.SetActive(true);
            inMinigame = true;
            jogadorNaArea = false;
        }
        if (minigameRodado == 1 && jogadorNaArea == true && teclaZ == true && inMinigame == false)
        {
            minigame02.gameObject.SetActive(true);
            inMinigame = true;
            jogadorNaArea = false;
        }


    }

    private void RunUIManager()
    {
        if (inMinigame == false) { caixaTxtMundoAberto.gameObject.SetActive(true); caixaTxtMinigame01.gameObject.SetActive(false); caixaTxtMinigame02.gameObject.SetActive(false); }
        if (inMinigame == true && minigameRodado==0) { caixaTxtMinigame01.gameObject.SetActive(true); caixaTxtMundoAberto.gameObject.SetActive(false); }
        if (inMinigame==true && minigameRodado==1) { { caixaTxtMinigame02.gameObject.SetActive(true); caixaTxtMundoAberto.gameObject.SetActive(false); } }



    }


}
