using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    //Parametros de configurações
    [SerializeField] Paddle paddle1;    
    [SerializeField] float xPush = 2f; //Vel. de lançamento em X
    [SerializeField] float yPush = 15f; //Vel. de lançamento em Y    

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false; //Var. booleana para saber se a bola foi lançada do Paddle

    // Use this for initialization
    void Start ()
    {
        //Posição da bola em relação ao paddle
        paddleToBallVector = transform.position - paddle1.transform.position;        
	}
	
	// Update is called once per frame
	void Update ()
    {     
        if(!hasStarted)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
              
    }   

    private void LockBallToPaddle()
    {
        //-> Como calcular a posição da bola <- 
        //Se -> paddleToBallVector = transform.position - paddle1.transform.position e nós temos a posição relativa e a posição atualizada do Paddle
        //Logo -> paddleToBallVector + paddle1.transform.position = transform.position
        //Pois a única informação que falta é a posição atualizada da bola
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);
        Vector2 ballPos = new Vector2(paddleToBallVector.x + paddlePos.x,paddleToBallVector.y + paddlePos.y);
        transform.position = ballPos;
    }

    private void LaunchOnMouseClick()
    {
        if(Input.GetMouseButtonDown(0)) //0 = Botão esquerdo do mouse
        {
            hasStarted = true;
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush,yPush);            
        }        
    }
}
