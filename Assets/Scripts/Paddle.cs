using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    //Parametros de configuração
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float minX = 1.0f;
    [SerializeField] float maxX = 15.0f;

    //Cached component references
    GameSession myGameSession;
    Ball myBall;

	// Use this for initialization
	void Start () {
        //Queremos encontrar o script com este nome
        myGameSession = FindObjectOfType<GameSession>();
        myBall = FindObjectOfType<Ball>();
    }
	
	// Update is called once per frame
	void Update () {
        //Queremos saber a posição do mouse no eixo X
        //Dividimos pela largura da tela para termos o valor em porcentagem e multiplicamos pela largura da tela (em unidades)
        //Assim, o valor é em unidades em relação a largura da tela (de 0 até 16 neste caso)
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y); //Cria um vetor com 2 dimensões
        paddlePos.x = Mathf.Clamp(GetXPos(),minX,maxX); //Limita o quanto o Paddle pode se mover para não ultrapassar o limite da tela        
        transform.position = paddlePos; //Muda a posição do Paddle de acordo com o paddlePos
	} 

    //Determina se a posição do Paddle está ligada à posição da bola ou ao movimento do mouse
    private float GetXPos() {
        if(myGameSession.IsAutoPlayEnabled()) {
            return myBall.transform.position.x;
        }
        else {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits; //Variável foi criada para ser definida no Transform do Paddle
        }
    }
}
