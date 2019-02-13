using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField] float screenWidthInUnits = 16f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Queremos saber a posição do mouse no eixo X
        //Dividimos pela largura da tela para termos o valor em porcentagem e multiplicamos pela largura da tela (em unidades)
        //Assim, o valor é em unidades em relação a largura da tela (de 0 até 16 neste caso)
        float mousePosInX = Input.mousePosition.x / Screen.width * screenWidthInUnits; //Variável foi criada para ser definida no Transform do Paddle

        Vector2 paddlePos = new Vector2(mousePosInX,transform.position.y); //Cria um vetor com 2 dimensões
        transform.position = paddlePos; //Muda a posição do Paddle de acordo com o paddlePos
	}
}
