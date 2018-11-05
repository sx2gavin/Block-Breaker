using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour {

    [SerializeField] 
    private GameObject _resetButton;

    private void Start()
    {
        _resetButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _resetButton.SetActive(true);
    }
}
