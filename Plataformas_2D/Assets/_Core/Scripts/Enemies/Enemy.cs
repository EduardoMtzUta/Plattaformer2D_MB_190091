using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour
{

public bool sePuedePisar = true;
public int puntos = 100;
public Sprite spriteBlanco;
public Sprite spriteMuerto;
public SpriteRenderer spriteRenderer;
public Animator anim;
public BoxCollider2D boxCollider2D;

public void HacerDaño(){

    GameManager.Instancia.agregarPuntos(puntos,transform.position);
    anim.enabled = false;
    boxCollider2D.enabled = false;
    Invoke("PonerMuerto",0.2f);
    spriteRenderer.sprite = spriteBlanco;
    Invoke("ApagarEnemigo", 1.0f);
}

private void ApagarEnemigo(){
    gameObject.SetActive(false);
}

private void PonerMuerto(){
    spriteRenderer.sprite = spriteMuerto;
}
}
