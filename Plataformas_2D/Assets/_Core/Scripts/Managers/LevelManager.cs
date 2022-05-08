using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instancia;
    public GameObject loadingMenu;
    public int nivelActual = 1;
    void Start()
    {
        Instancia = this;
        SceneManager.sceneUnloaded += TerminoDeQuitarLaEscena;
        SceneManager.sceneLoaded += EscenaTerminoDeCargar;
    }

    public void Retry(){
        loadingMenu.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_"+nivelActual);
    }

    public void SiguienteNivel()
    {
        loadingMenu.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual++;

    }

    public void CargarNivel(int _nivel){
        loadingMenu.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Nivel_" + nivelActual);
        nivelActual = _nivel;
    }

    private void TerminoDeQuitarLaEscena(Scene scene)
    {
        SceneManager.LoadScene("Nivel_" + nivelActual, LoadSceneMode.Additive);
    }
    private void EscenaTerminoDeCargar(Scene scene, LoadSceneMode mode)
    {
        loadingMenu.gameObject.SetActive(false);
        GameManager.Instancia.IniciaSiguienteNivel();
    }
}
