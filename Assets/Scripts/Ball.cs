using UnityEngine;
//using Random = UnityEngine.Random;

public class Ball : MonoBehaviour {

    //Parametros de configurações
    [SerializeField] Paddle paddle1;    
    [SerializeField] float xPush = 2f; //Vel. de lançamento em X
    [SerializeField] float yPush = 15f; //Vel. de lançamento em Y 
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.5f;

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false; //Var. booleana para saber se o jogo começou    

    //Cached component references
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;

    // Use this for initialization
    void Start ()
    {        
        paddleToBallVector = transform.position - paddle1.transform.position; //Posição da bola em relação ao paddle
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
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

    private void LockBallToPaddle() //Prende a bola ao Paddle
    {
        //-> Como calcular a posição da bola <- 
        //Se -> paddleToBallVector = transform.position - paddle1.transform.position e nós temos a posição relativa e a posição atualizada do Paddle
        //Logo -> paddleToBallVector + paddle1.transform.position = transform.position
        //Pois a única informação que falta é a posição atualizada da bola
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x,paddle1.transform.position.y);
        Vector2 ballPos = new Vector2(paddleToBallVector.x + paddlePos.x,paddleToBallVector.y + paddlePos.y);
        transform.position = ballPos;
    }

    private void LaunchOnMouseClick() //Lança a Bola ao clicar o botão esquerdo do mouse
    {
        if(Input.GetMouseButtonDown(0)) //0 = Botão esquerdo do mouse
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush,yPush);            
        }        
    }

    public void OnCollisionEnter2D(Collision2D collision)        
    {
        //Adicionar um vetor aleatório de velocidade para que a bola possa se mover mais a cada colisão
        Vector2 velocityTweak = new Vector2(Random.Range(0f,randomFactor),Random.Range(0f,randomFactor));
        if(hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidbody2D.velocity += velocityTweak;
        }        
    }
}
