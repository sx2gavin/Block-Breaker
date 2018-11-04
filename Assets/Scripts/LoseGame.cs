using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGame : MonoBehaviour {

    [SerializeField] GameObject ResetButton;

    private void Start()
    {
        ResetButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResetButton.SetActive(true);
    }
}
