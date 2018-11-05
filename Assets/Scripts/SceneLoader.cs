using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private GameState _gameController;

    private void Start()
    {
        _gameController = FindObjectOfType<GameState>();
    }

    public void LoadNextScene()
    {
        _gameController.ResetLevelExceptForScores();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }

    public void ReloadScene()
    {
        _gameController.ResetLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadFirstScene()
    {
        _gameController.ResetLevelExceptForScores();
        SceneManager.LoadScene(0);
    }

	public void QuitGame()
	{
		Application.Quit();
	}
}
