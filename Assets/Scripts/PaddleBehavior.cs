using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    // config parameters
    [SerializeField] private float _screenWidthInWorld = 16f;
    [SerializeField] private float _paddlePosXMin = 1f;
    [SerializeField] private float _paddlePosXMax = 15f;
    [SerializeField] private BallBehavior _ball;

    // cached components
    private GameSession _gameSession;

    private void Start()
    {
        _gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame 
    void Update ()
    {
        float paddleXPos = Mathf.Clamp(GetPaddleXPos(), _paddlePosXMin, _paddlePosXMax);
        Vector2 newPaddlePos = new Vector2(paddleXPos, transform.position.y);
        transform.position = newPaddlePos;
    }

    private float GetPaddleXPos()
    {
        if (_gameSession && _gameSession.IsAutoPlayEnabled) 
        {
            return _ball.transform.position.x;
        }
        else
        {
            float paddleXPos = Input.mousePosition.x / Screen.width * _screenWidthInWorld;
            return paddleXPos;
        }
    }
}
