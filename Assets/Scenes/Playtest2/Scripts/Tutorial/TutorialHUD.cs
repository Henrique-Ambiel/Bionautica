using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHUD : MonoBehaviour
{
    public GameObject TutorialOverlay;
    private bool isGamePaused = true;

    void Start()
    {
        {
            TutorialOverlay.SetActive(true); // Aciona o Canva TutorialOverlay.
            Time.timeScale = 0f; // Pausa o jogo
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGamePaused && Input.GetKeyDown(KeyCode.X))
        {
            TutorialOverlay.SetActive(false);  // Esconde o TutorialOverlay da tela.
            isGamePaused = false;
            Time.timeScale = 1f; // Remove o pause do jogo.
        }
    }
}
