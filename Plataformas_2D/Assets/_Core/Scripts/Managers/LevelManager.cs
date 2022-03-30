using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instancia;
    public GameObject loadingMenu;
    void Start()
    {
        Instancia = this;
        SceneManager.sceneUnloaded += TerminoDeQuitarLaEscena;
        SceneManager.sceneLoaded += EscenaTerminoDeCargar;
    }

    public int nivelActual = 1;
    public void SiguienteNivel()
    {
        loadingMenu.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual++;

    }

    private void TerminoDeQuitarLaEscena(Scene scene)
    {
        SceneManager.LoadScene("Nivel_" + nivelActual, LoadSceneMode.Additive);
    }
    private void EscenaTerminoDeCargar(Scene scene, LoadSceneMode mode)
    {
        loadingMenu.gameObject.SetActive(false);
    }
}
