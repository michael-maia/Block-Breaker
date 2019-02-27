using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breakSound;    

    private void OnCollisionEnter2D(Collision2D collision) //collision = Nome do objeto que colidiu com o Bloco
    {
        AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position); //Escolhemos a Camera pois assim o volume do audio será alto
        Destroy(gameObject);
    }
}
