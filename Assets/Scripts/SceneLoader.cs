﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
        //Criando um index para as cenas através da classe SceneManager
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1); //Carrega a próxima cena
    }

    //Carregando a cena inicial caso o jogo esteja na última cena
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0); //Index = 0, é a nossa primeira cena
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GameSettings() {
        SceneManager.LoadScene("Configuration");
    }

    public void ReturnToStartMenu() {
        SceneManager.LoadScene("StartMenu");
    }

}
