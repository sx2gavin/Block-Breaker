using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {

    // config paramters
    [SerializeField] public Sprite[] BlockSprites;
    [SerializeField] public int MaxHitPoints = 3;
    [SerializeField] public AudioClip DestroySound;
    [SerializeField] public GameObject blockHitVFX;

    // state
    private Level _level;
    private int _currentHits = 0;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        if (_level) 
        {
            if (tag == "Breakable")
            {
                _level.IncrementBreakableBlock();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is CircleCollider2D) 
        {
            if (tag == "Breakable")
            {
                TriggerBlockHitVFX(collision.GetContact(0).point);
                _currentHits++;
                if (_currentHits >= MaxHitPoints)
                {
                    DestroyBlock();
                }
                else
                {
                    UpdateSpriteBasedOnHits();
                }
            }
        }
    }

    private void UpdateSpriteBasedOnHits()
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        if (render)
        {
            int spriteIndex = _currentHits;
            if (spriteIndex >= BlockSprites.Length) 
            {
                spriteIndex = BlockSprites.Length - 1;
            }

            if (BlockSprites[spriteIndex] != null)
            {
                render.sprite = BlockSprites[spriteIndex];
            }
            else
            {
                Debug.LogError("One of the block sprites is missing from " + gameObject.name);
            }
        }
    }

    private void DestroyBlock()
    {
        if (_level)
        {
            _level.DecrementBreakableBlock();
        }
        else
        {
            Debug.LogError("Error: Game Controller not found.");
        }
        AudioSource.PlayClipAtPoint(DestroySound, transform.position);
        Destroy(gameObject);
    }

    private void TriggerBlockHitVFX(Vector3 position)
    {
        Vector3 playVFXPos = position;
        playVFXPos.z = -0.01f;
        GameObject sparkle = Instantiate(blockHitVFX, playVFXPos, Quaternion.identity);
        Destroy(sparkle, 1.0f);
    }
}