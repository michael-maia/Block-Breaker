using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision = Nome do objeto que colidiu com o Bloco
        Destroy(gameObject);
    }
}
