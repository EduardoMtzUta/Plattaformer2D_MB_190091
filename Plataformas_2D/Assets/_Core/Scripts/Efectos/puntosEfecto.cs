using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class puntosEfecto : MonoBehaviour
{
    public TextMeshPro texto;
    public float jumpPower = 1;
    public float tiempoDeSalto;
    public void ShowText(string _text, Vector2 _position){
        texto.text = _text;
        transform.position = _position;
        Invoke("SaltarAContador",0.5f);
    }

    private void SaltarAContador(){
        transform.DOJump(GameManager.Instancia.puntosText.transform.position,jumpPower,1,tiempoDeSalto)
        .OnComplete(MovimientoCompletado);
    }
    private void MovimientoCompletado(){
        gameObject.SetActive(false);
        GameManager.Instancia.ActualizarPuntos();
    }
}
