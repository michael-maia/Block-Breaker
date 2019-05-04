using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Necessário para a variável de tipo Text

public class GameSession : MonoBehaviour {

    //Config Parameters
    [Range(0.1f,10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 83;
    [SerializeField] Text scoreText; //O tipo Text serve para conectarmos o Text Object no inspector no Unity Editor

    //State Variables
    [SerializeField] int currentScore = 0;

    //Singleton Pattern
    void Awake() { 
        int gameStatusCount = FindObjectsOfType<GameSession>().Length; //É Objects com S no final pois estamos procurando mais de um GameSession
        if(gameStatusCount > 1) { //Caso já tenha carregado mais de um GameSession script
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start(){
        scoreText.text = currentScore.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        Time.timeScale = gameSpeed;
	}

    //Cada bloco destruído aumenta o score e atualiza o scoreText
    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame() { //Destrói o game object GameSession ao clicarmos para jogar novamente para que o placar fique zerado
        Destroy(gameObject);
    }
}
