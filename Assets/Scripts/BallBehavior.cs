using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{

    // config parameters
    [SerializeField] private PaddleBehavior _paddle;
    [SerializeField] private Camera _sceneCamera;
    [SerializeField] private float _cameraShakeFactor = 0.1f;
    [SerializeField] private float _cameraShakeWait = 0.01f;
    [SerializeField] private int _cameraShakeCount = 8;
    [SerializeField] private float _ballSpeed = 10f;
    [SerializeField] private AudioClip[] _ballSounds;
    [SerializeField] private float _ballRandomFactor = 1f;

    // states
    private Vector2 _distance;
    private bool _launched;
    private Vector3 _originalCameraPos;
    private float _launchAngleRange = 60.0f;

    // cached components
    private AudioSource _audioSource;
    private Rigidbody2D _rigidbody2DComponent;

	// Use this for initialization
	void Start () 
    {
        _launched = false;
        _distance = transform.position - _paddle.transform.position;
        _originalCameraPos = _sceneCamera.transform.position;
        _audioSource = GetComponent<AudioSource>();
        _rigidbody2DComponent = GetComponent<Rigidbody2D>();
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
                float randomLaunchAngle = Random.Range(90.0f - _launchAngleRange / 2, 90.0f + _launchAngleRange / 2);
                float x = Mathf.Cos(randomLaunchAngle * Mathf.Deg2Rad);
                float y = Mathf.Sin(randomLaunchAngle * Mathf.Deg2Rad);
                Vector2 ballDirection = new Vector2(x, y);
                _rigidbody2DComponent.velocity = _ballSpeed * ballDirection;
            }
        }
    }

    private void StickBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(_paddle.transform.position.x, _paddle.transform.position.y);
        transform.position = paddlePos + _distance;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_launched)
        {
            AddRandomAngleToBall();
            PlayBallHitSound();

            if (collision.collider.tag == "Breakable")
            {
                StartCoroutine("ShakeCamera");
            }
        }
    }

    private void AddRandomAngleToBall()
    {
        /*
        float x = Random.Range(0, BallRandomFactor);
        float y = Random.Range(0, BallRandomFactor);
        Vector2 randomForce = new Vector2(x, y);
        */
        Vector2 currentVelocity = _rigidbody2DComponent.velocity;
        float magnitude = currentVelocity.magnitude;
        float angle = Mathf.Atan2(currentVelocity.y, currentVelocity.x);
        float randomAngleDelta = Random.Range(-_ballRandomFactor, _ballRandomFactor);
        angle += randomAngleDelta * Mathf.Deg2Rad;
        currentVelocity.x = Mathf.Cos(angle) * magnitude;
        currentVelocity.y = Mathf.Sin(angle) * magnitude;
        _rigidbody2DComponent.velocity = currentVelocity;
    }

    private void PlayBallHitSound()
    {
        AudioClip playSound = _ballSounds[Random.Range(0, _ballSounds.Length)];
        if (_audioSource)
        {
            _audioSource.PlayOneShot(playSound);
        }
    }

    private Vector2 Reflection(Vector2 incomingVector, Vector2 normalVector)
    {
        normalVector.Normalize();
        float h = Vector2.Dot(incomingVector, normalVector);
        Vector2 resultVector = incomingVector - 2.0f * h * normalVector;

        return resultVector;
    }


    private IEnumerator ShakeCamera()
    {
        for (int i = 0; i < _cameraShakeCount; i++) 
        {
            ShiftCameraRandomly();
            yield return new WaitForSeconds(_cameraShakeWait);
        }
        _sceneCamera.transform.position = _originalCameraPos;
    }

    private void ShiftCameraRandomly()
    {
        float shiftX = Random.Range(-_cameraShakeFactor, _cameraShakeFactor);
        float shiftY = Random.Range(-_cameraShakeFactor, _cameraShakeFactor);
        _sceneCamera.transform.position = _originalCameraPos + new Vector3(shiftX, shiftY, 0.0f);
    }
}