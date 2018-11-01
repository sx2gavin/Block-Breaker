using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior: MonoBehaviour {

    // config parameters
    [SerializeField] public PaddleBehavior Paddle;
    [SerializeField] public float BallSpeed = 10f;

    // states
    private Vector2 _distance;
    private Rigidbody2D _rigidbody2DComponent;
    private bool _launched;
    private Vector2 _ballDirection;

	// Use this for initialization
	void Start () 
    {
        _launched = false;
        _distance = transform.position - Paddle.transform.position;
        _rigidbody2DComponent = GetComponent<Rigidbody2D>();
        _ballDirection = new Vector2(0, 1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_launched == false) 
        {
            StickBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _launched = true;
            if (_rigidbody2DComponent != null)
            {
                _rigidbody2DComponent.velocity = BallSpeed * _ballDirection;
            }
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(Paddle.transform.position.x, Paddle.transform.position.y);
        transform.position = paddlePos + _distance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ContactPoint2D contact = collision.GetContact(0);
        //_ballDirection = Reflection(contact.relativeVelocity, contact.normal);
        //_ballDirection.Normalize();
        //BallSpeed += 0.01f;

        //_rigidbody2DComponent.velocity = BallSpeed * _ballDirection;
    }

    private Vector2 Reflection(Vector2 incomingVector, Vector2 normalVector)
    {
        normalVector.Normalize();
        float h = Vector2.Dot(incomingVector, normalVector);
        Vector2 resultVector = incomingVector - 2.0f * h * normalVector;

        return resultVector;
    }
}