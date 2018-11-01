using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    [SerializeField]
    public float screenWidthInWorld = 16f;

    [SerializeField]
    public float paddlePosXMin = 1f;

    [SerializeField]
    public float paddlePosXMax = 15f;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame 
	void Update () 
    {
        float paddleXPos = Input.mousePosition.x / Screen.width * screenWidthInWorld;
        paddleXPos = Mathf.Clamp(paddleXPos, paddlePosXMin, paddlePosXMax);
        Vector2 newPaddlePos = new Vector2(paddleXPos, transform.position.y);
        transform.position = newPaddlePos;
	}
}
