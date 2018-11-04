using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {

    // config paramters
    [SerializeField] public SpriteRenderer spriteRenderer;
    [SerializeField] public Sprite FullBlock;
    [SerializeField] public Sprite HalfBlock;
    [SerializeField] public Sprite HollowBlock;
    [SerializeField] public int HitPoint = 3;
    [SerializeField] public AudioClip DestroySound;

    // state
    private GameController _gameController;

    private void Start()
    {
        _gameController = FindObjectOfType<GameController>();
        if (_gameController) 
        {
            _gameController.IncrementBreakableBlock();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is CircleCollider2D) 
        {
            HitPoint--;
            if (HitPoint <= 0)
            {
                DestroyBlock();
            }
            else if (HitPoint == 2)
            {
                spriteRenderer.sprite = HalfBlock;
            }
            else if (HitPoint == 1)
            {
                spriteRenderer.sprite = HollowBlock;
            }
        }
    }

    private void DestroyBlock()
    {
        if (_gameController)
        {
            _gameController.DecrementBreakableBlock();
        }
        AudioSource.PlayClipAtPoint(DestroySound, transform.position);
        Destroy(gameObject);
    }
}
