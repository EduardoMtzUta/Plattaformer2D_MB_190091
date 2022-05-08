using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_NivelBoton : MonoBehaviour
{
    public Button nivelBoton;
    public int nivel;
    public TextMeshProUGUI nombreNivel;
    public List<Image> estrellas;
    void Start()
    {
        nivelBoton.onClick.AddListener(OnLevelSelect);
        PonerNombre();
        SetupEstrellas();
    }
    // Detectar el Click
    public void OnLevelSelect()
    {
        Debug.Log("Nivel " + nivel);
        GameManager.Instancia.seleccionDeNivelMenu.gameObject.SetActive(false);
        LevelManager.Instancia.CargarNivel(nivel);
    }

    // Poner Nombre del nivel

    public void PonerNombre()
    {
        nombreNivel.text = "NIVEL " + nivel;
    }
    // Poner las estrellas ganadas

    public void SetupEstrellas(){
        int cuantasEstrellas = DataManager.Instancia.CargarEstrellas("Nivel_"+nivel);
        for (int i = 0; i < cuantasEstrellas; i++)
        {
            estrellas[i].color = Color.white;
        }
    }

}
