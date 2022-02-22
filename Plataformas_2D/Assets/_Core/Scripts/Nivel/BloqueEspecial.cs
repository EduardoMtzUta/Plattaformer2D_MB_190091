using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class BloqueEspecial : MonoBehaviour
{
    public BloqueType tipo;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteApagado;
    public Animator anim;
    public GameObject moneda;
    private bool active = true;
    private int puntos = 100;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!active) { return; }
        if (other.gameObject.tag != Constantes.TAG_PLAYER) { return; }
        if (GameManager.Instancia.player.playerMovement.estaEnSuelo) { return; }

        active = false;
        spriteRenderer.sprite = spriteApagado;
        anim.Play("BloqueEspecialSalto");

        if (tipo == BloqueType.Monedas)
        {
            Debug.Log("Bloque de monedas");
            AnimarMoneda();
        }
        else if (tipo == BloqueType.Hongos)
        {
            Debug.Log("Bloque de Hongos");
        }
        else if (tipo == BloqueType.FlorFuego)
        {
            Debug.Log("Bloque de Flor de fuego");
        }


    }
    public float monedaSaltoTiempo;
    public void AnimarMoneda()
    {
        moneda.gameObject.SetActive(true);
        moneda.transform.DOLocalMove(new Vector2(0, 2f), monedaSaltoTiempo).OnComplete(MonedaOnComplete);
    }
    private void MonedaOnComplete()
    {
        moneda.transform.DOLocalMove(new Vector2(0, 0), monedaSaltoTiempo).SetDelay(0.1f).OnComplete(monedaOff);
        moneda.transform.DOLocalRotate(new Vector3(0,180,0),0.2f).SetLoops(-1);
        void monedaOff()
        {
            moneda.gameObject.SetActive(false);
        }
        GameManager.Instancia.agregarMonedas();
        GameManager.Instancia.agregarPuntos(puntos,transform.position);
    }
}
