using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        GameSession gameState = FindObjectOfType<GameSession>();
        if (gameState)
        {
            gameState.ResetLevelExceptForScores();
        }
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void ReloadScene()
    {
        GameSession gameState = FindObjectOfType<GameSession>();
        if (gameState)
        {
            gameState.ResetLevel();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadFirstScene()
    {
        GameSession gameState = FindObjectOfType<GameSession>();
        if (gameState)
        {
            Destroy(gameState.gameObject);
        }
        SceneManager.LoadScene(0);
    }

	public void QuitGame()
	{
		Application.Quit();
	}
}
