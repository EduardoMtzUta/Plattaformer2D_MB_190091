using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;
    public puntosEfecto puntosText_Efecto;
    public Player player;
    public int monedas;
    public int puntos;
    public TextMeshProUGUI monedasText;
    public TextMeshProUGUI puntosText;
    public List<UI_Vida> vidasList;
    public GameObject gameOverMenu;
    public GameObject nivelCompletadoMenu;
    void Start()
    {
        Instancia = this;
    }

    void Update()
    {

    }

    public void GameOver()
    {
        player.playerMovement.bloquearMovimiento = true;
        player.playerMovement.Bloquearcorrida();
        gameOverMenu.gameObject.SetActive(true);
    }

    public void NivelCompletado()
    {
        player.playerMovement.Bloquearcorrida();
        player.playerMovement.bloquearMovimiento = true;
        nivelCompletadoMenu.gameObject.SetActive(true);

    }

    public void agregarPuntos(int _puntos, Vector2 _posicion)
    {
        puntos += _puntos;
        puntosText_Efecto.gameObject.SetActive(true);
        puntosText_Efecto.ShowText(_puntos.ToString(), _posicion);
    }

    public void ActualizarPuntos()
    {
        puntosText.text = puntos.ToString();
    }
    public void agregarMonedas()
    {
        monedas++;
        monedasText.text = "X " + monedas.ToString();
    }
    public void QuitarVida(int _vidas)
    {

        if (_vidas < 0)
        {
            return;
        }
        vidasList[_vidas].ApagarVida();
    }
}
