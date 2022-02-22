using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void OnRetryClick(){
        Debug.Log("GAME OVER - RETRY CLICK");
        SceneManager.LoadScene("Game");
    }
}
