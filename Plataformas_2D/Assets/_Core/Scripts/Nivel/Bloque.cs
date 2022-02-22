using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    public ParticleSystem particulasB;
    public SpriteRenderer spriteRendererB;
    public BoxCollider2D colliderB;
    
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != Constantes.TAG_PLAYER){return;}
        if (GameManager.Instancia.player.playerMovement.estaEnSuelo){return;}
        particulasB.Play();
        spriteRendererB.enabled = false;
        colliderB.enabled = false;

    }
}
