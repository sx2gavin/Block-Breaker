using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior: MonoBehaviour {
    [SerializeField]
    public GameObject Ball;

    [SerializeField]
    public Rigidbody2D BallRigidBody;

    private Vector2 _ballLocation;
    private double _ballVelocity;
    private Vector2 _direction;
    private int _collisionCounter;

	// Use this for initialization
	void Start () {
        /*_ballLocation = Ball.transform.position;
        _ballVelocity = 0.1;
        _direction = new Vector2(0, -1);
        */
        BallRigidBody.velocity = new Vector2(0, -1);
	}
	
	// Update is called once per frame
	void Update () {
        // _ballLocation += new Vector2((float)(_direction.x * _ballVelocity), (float)(_direction.y * _ballVelocity));
        // Ball.transform.position = _ballLocation;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (_collisionCounter == 0)
        // {
        //     _collisionCounter++;
        //     ContactPoint2D contact = collision.GetContact(0);
        //     Vector2 normal = contact.normal;
        //     _direction = Reflection(_direction, normal);
		// 
        //     _ballVelocity += 0.001;
        // }
        // else
        // {
        //     _collisionCounter++;
        //     return;
        // }
    }

    private Vector2 Reflection(Vector2 incomingVector, Vector2 normalVector)
    {
        normalVector.Normalize();
        float h = Vector2.Dot(incomingVector, normalVector);
        Vector2 resultVector = incomingVector - 2.0f * h * normalVector;

        return resultVector;
    }
}