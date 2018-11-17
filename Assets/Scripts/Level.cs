using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [SerializeField]
    [Range(0.1f, 10f)]
    private float _gameSpeed = 1.0f;

    // state
    private int _breakableBlockCount = 0;

    public void IncrementBreakableBlock()
    {
        _breakableBlockCount++;
    }

    public void DecrementBreakableBlock()
    {
        _breakableBlockCount--;
        IncrementGameScore();
        CheckForNextLevel();
    }

    private static void IncrementGameScore()
    {
        GameSession game = FindObjectOfType<GameSession>();
        if (game)
        {
            game.IncrementGameScore();
        }
    }

    private void CheckForNextLevel()
    {
        if (_breakableBlockCount < 1)
        {
            _gameSpeed *= 0.2f;
            GameSession game = FindObjectOfType<GameSession>();
            if (game)
            {
                game.WinLevel();
            }
        }
    }

    private void Update()
    {
        AdjustGameSpeed(_gameSpeed);
    }

    private void AdjustGameSpeed(float timeScale)
    {
        Time.timeScale = timeScale;
        Time.fixedDeltaTime = 0.02f * timeScale;
    }
}
