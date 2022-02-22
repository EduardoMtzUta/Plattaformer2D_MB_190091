using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    private int vidas = 4;
    public PlayerMovement playerMovement;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteBlanco;
    public Sprite spriteTriste;
    public Animator animator;
    private bool esInmune = false;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Colision con: " + other.name);

        if (other.tag == Constantes.TAG_MONEDA)
        {
            other.gameObject.SetActive(false);
            GameManager.Instancia.agregarMonedas();

            //1. Detectar la colision con el enemigo
        }
        else if (other.tag == Constantes.TAG_ENEMIGO)
        {
            if (other.GetComponent<Enemy>().sePuedePisar && playerMovement.rb.velocity.y < 0 && !esInmune)
            {
                //Dañar al enemigo
                other.GetComponent <Enemy>().HacerDaño();
                playerMovement.rb.velocity = Vector2.zero;
                playerMovement.rb.AddForce(new Vector2(0,330));
            }
            else if(!esInmune){
                HacerDaño();
            }

        }else if (other.tag == Constantes.TAG_PUERTA_OBJETIVO){ 

            //Nivel completado
            Debug.Log("Nivel completado");
            GameManager.Instancia.NivelCompletado();

        }else if(other.tag == Constantes.TAG_BARRANCO){
            GameManager.Instancia.GameOver();
        }
    }
    private void HacerDaño()
    {
        esInmune = true;
        vidas--;

        GameManager.Instancia.QuitarVida(vidas);

        if (vidas <= 0)
        {
            //Murio
            GameManager.Instancia.GameOver();
            return;
        }

        //2. Bloquear movimiento del personaje
        playerMovement.bloquearMovimiento = true;
        playerMovement.rb.velocity = Vector2.zero;

        //3. Aplicar animacion de Hit
        animator.enabled = false;
        spriteRenderer.sprite = spriteBlanco;

        //4. Empujar al personaje

        if (playerMovement.estaVolteandoDerecha)
        {
            playerMovement.rb.AddForce(new Vector2(-100, 400));
        }
        else
        {
            playerMovement.rb.AddForce(new Vector2(100, 400));
        }


        //5. Apagar y prender el personaje
        InvokeRepeating("Parpadeo", 0, 0.15f);
        Invoke("QuitarSpriteBlanco", 0.4f);

        //6. Regresar a la normalidad
        Invoke("RegresoALaNormalidad", 1);

    }

    private void Parpadeo()
    {
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    private void QuitarSpriteBlanco()
    {
        spriteRenderer.sprite = spriteTriste;
    }

    private void RegresoALaNormalidad()
    {
        esInmune=false;
        spriteRenderer.enabled = true;
        playerMovement.rb.velocity = Vector2.zero;
        playerMovement.bloquearMovimiento = false;
        CancelInvoke("Parpadeo");
        animator.enabled = true;

    }

}
