using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSession gameState = FindObjectOfType<GameSession>();
        if (gameState)
        {
            gameState.LoseGame();
        }
    }
}
