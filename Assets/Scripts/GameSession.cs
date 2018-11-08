using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Config parameters
    [SerializeField]
    private GameObject _nextLevelButton;

    [SerializeField]
    private GameObject _tryAgainButton;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    private int _gameScore = 0;

    [SerializeField]
    private int _scorePerBlock = 100;

    [SerializeField]
    private bool _isAutoPlayEnabled = false;

    public bool IsAutoPlayEnabled
    {
        get
        {
            return _isAutoPlayEnabled;
        }
    }

    public void LoseGame()
    {
        _tryAgainButton.SetActive(true);
    }

    public void WinLevel()
    {
        _nextLevelButton.SetActive(true);
    }

    public void IncrementGameScore()
    {
        _gameScore += _scorePerBlock;
        _scoreText.text = "Score: " + _gameScore;
    }

    public void ResetLevelExceptForScores()
    {
        _tryAgainButton.SetActive(false);
        _nextLevelButton.SetActive(false);
    }

    public void ResetLevel()
    {
        _gameScore = 0;
        _scoreText.text = "Score: " + _gameScore;
        ResetLevelExceptForScores();
    }

    private void Awake()
    {
        int gameStatesCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatesCount > 1) 
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ResetLevel();
    }

}