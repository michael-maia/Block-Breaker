using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {    

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    //Cached reference
    Level level;

    private void Start()
    {
        level = FindObjectOfType<Level>(); //Procura pelo script e não pelo GameObject
        level.CountBreakableBlocks(); //Cada instância da classe Block vai ativar este método do qual vai adicionar +1 ao total de blocos que podemos destruir
    }

    private void OnCollisionEnter2D(Collision2D collision) //collision = Nome do objeto que colidiu com o Bloco
    {
        DestroyBlock();        
    }
    
    private void DestroyBlock() {
        PlayBlockDestroySFX();
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVFX();
    }

    private void PlayBlockDestroySFX() {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound,Camera.main.transform.position); //Escolhemos a Camera pois assim o volume do audio será alto
    }

    //Executa o efeito especial de particulas
    private void TriggerSparklesVFX() { 
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles,2); //Devemos usar o "sparkles" ao invés do "blockSparklesVFX" pois é a instância desse game object
    }
}
