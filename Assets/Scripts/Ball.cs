using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //Parametros de configurações
    [SerializeField] Paddle paddle1;

    //State
    Vector2 paddleToBallVector;

	// Use this for initialization
	void Start ()
    {
        //Posição da bola em relação ao paddle
        paddleToBallVector = transform.position - paddle1.transform.position;
        //Debug.Log(paddleToBallVector);
	}
	
	// Update is called once per frame
	void Update ()
    {
       //-> Como calcular a posição da bola <- 
       //Se -> paddleToBallVector = transform.position - paddle1.transform.position e nós temos a posição relativa e a posição atualizada do Paddle
       //Logo -> paddleToBallVector + paddle1.transform.position = transform.position
       //Pois a única informação que falta é a posição atualizada da bola
       Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);    
       Vector2 ballPos = new Vector2(paddleToBallVector.x + paddlePos.x,paddleToBallVector.y + paddlePos.y);
       transform.position = ballPos;
    }
}
