using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameSession : MonoBehaviour
{
    // Config parameters
    [SerializeField] GameObject _nextLevelButton;
    [SerializeField] GameObject _tryAgainButton;
    [SerializeField] GameObject _uiBackground;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] int _gameScore = 0;
    [SerializeField] int _scorePerBlock = 100;
    [SerializeField] bool _isAutoPlayEnabled = false;

    public bool IsAutoPlayEnabled
    {
        get
        {
            return _isAutoPlayEnabled;
        }
    }

    public void LoseGame()
    {
        _uiBackground.SetActive(true);
        _tryAgainButton.SetActive(true);
    }

    public void WinLevel()
    {
        _uiBackground.SetActive(true);
        _nextLevelButton.SetActive(true);
    }

    public void IncrementGameScore()
    {
        _gameScore += _scorePerBlock;
        _scoreText.text = "Score: " + _gameScore;
    }

    public void ResetLevelExceptForScores()
    {
        _uiBackground.SetActive(false);
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