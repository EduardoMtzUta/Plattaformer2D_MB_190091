using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instancia;
    public List<AudioSource> listaDeSonidos;


    void Start()
    {
        Instancia = this;
    }
    public void PlayAudio(int _sound)
    {
        listaDeSonidos[_sound].Play();
    }
    public static int AUDIO_SALTO = 0;
    public static int AUDIO_MONEDA = 1;
    public static int AUDIO_BARRANCO = 2;
    public static int AUDIO_ROMPERBLOQUE = 3;
    public static int AUDIO_NIVELCOMPLETADO = 4;
}
