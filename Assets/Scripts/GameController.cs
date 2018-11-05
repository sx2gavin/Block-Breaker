using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    // Config parameters
    [SerializeField]
    private GameObject _nextLevelButton;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    [SerializeField]
    [Range(0.1f, 2f)]
    private float _gameSpeed = 1.0f;

    [SerializeField]
    private int _gameScore = 0;

    [SerializeField]
    private int _scorePerBlock = 100;


    private int _breakableBlockCount = 0;

    private void Start()
    {
        _scoreText.text = "Score: 0";
        _nextLevelButton.SetActive(false);
    }

    private void Update()
    {
        AdjustGameSpeed(_gameSpeed);
    }

    public void IncrementBreakableBlock() 
    {
        _breakableBlockCount++;
    }

    public void DecrementBreakableBlock()
    {
        _breakableBlockCount--;

        UpdateGameScore();
        CheckForNextLevel();
    }

    private void CheckForNextLevel()
    {
        if (_breakableBlockCount < 1)
        {
            _gameSpeed *= 0.2f;
            _nextLevelButton.SetActive(true);
        }
    }

    private void UpdateGameScore()
    {
        _gameScore += _scorePerBlock;
        _scoreText.text = "Score: " + _gameScore;
    }

    private void AdjustGameSpeed(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = 0.02f * timeScale;
    }
}