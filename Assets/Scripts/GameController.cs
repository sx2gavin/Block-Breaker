using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    [SerializeField] public GameObject NextLevelButton;

    private int _breakableBlockCount = 0;

    private void Start()
    {
        NextLevelButton.SetActive(false);
    }

    public void IncrementBreakableBlock() 
    {
        _breakableBlockCount++;
    }

    public void DecrementBreakableBlock()
    {
        _breakableBlockCount--;

        if (_breakableBlockCount < 1) 
        {
            NextLevelButton.SetActive(true);
        }
    }
}