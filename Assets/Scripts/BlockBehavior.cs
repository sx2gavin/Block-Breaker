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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is CircleCollider2D) 
        {
            HitPoint--;
            if (HitPoint <= 0) 
            {
                Destroy(this.gameObject);
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
}
