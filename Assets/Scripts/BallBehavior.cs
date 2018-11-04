using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBehavior : MonoBehaviour
{

    // config parameters
    [SerializeField] public PaddleBehavior Paddle;
    [SerializeField] public Camera SceneCamera;
    [SerializeField] public float CameraShakeFactor = 0.01f;
    [SerializeField] public float CameraShakeWait = 0.01f;
    [SerializeField] public int CameraShakeCount = 4;
    [SerializeField] public float BallSpeed = 10f;
    [SerializeField] public AudioClip[] BallSounds;

    // states
    private Vector2 _distance;
    private Rigidbody2D _rigidbody2DComponent;
    private bool _launched;
    private Vector2 _ballDirection;
    private Vector3 _originalCameraPos;

    // cached components
    private AudioSource _audioSource;

	// Use this for initialization
	void Start () 
    {
        _launched = false;
        _distance = transform.position - Paddle.transform.position;
        _rigidbody2DComponent = GetComponent<Rigidbody2D>();
        _ballDirection = new Vector2(0, 1);
        _originalCameraPos = SceneCamera.transform.position;
        _audioSource = GetComponent<AudioSource>();
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
        if (_launched)
        {
            AudioClip playSound = BallSounds[Random.Range(0, BallSounds.Length)];
            if (_audioSource)
            {
                _audioSource.PlayOneShot(playSound);
            }

            if (collision.collider.tag == "Block")
            {
                StartCoroutine("ShakeCamera");
            }
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
        for (int i = 0; i < CameraShakeCount; i++) 
        {
            ShiftCameraRandomly();
            yield return new WaitForSeconds(CameraShakeWait);
        }
        SceneCamera.transform.position = _originalCameraPos;
    }

    private void ShiftCameraRandomly()
    {
        float shiftX = Random.Range(-CameraShakeFactor, CameraShakeFactor);
        float shiftY = Random.Range(-CameraShakeFactor, CameraShakeFactor);
        SceneCamera.transform.position = _originalCameraPos + new Vector3(shiftX, shiftY, 0.0f);
    }
}