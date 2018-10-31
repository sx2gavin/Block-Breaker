using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleBehavior : MonoBehaviour {

    [SerializeField]
    public Camera SceneCamera;

    private Vector3 _paddleLocation; 

	// Use this for initialization
	void Start () {
        _paddleLocation = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = SceneCamera.ScreenPointToRay(Input.mousePosition);
        _paddleLocation.x = ray.origin.x;
        this.transform.position = _paddleLocation;
	}
}
