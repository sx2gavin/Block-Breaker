using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour {
    [SerializeField]
    public GameObject Myself;

    [SerializeField]
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    public Sprite FullBlock;

    [SerializeField]
    public Sprite HalfBlock;

    [SerializeField]
    public Sprite HollowBlock;

    private int _brickLife;

	// Use this for initialization
	void Start () 
    {
        _brickLife = 3;
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider is CircleCollider2D) 
        {
            _brickLife--;
            if (_brickLife <= 0) 
            {
                Destroy(Myself);
            }
            else if (_brickLife == 2)
            {
                spriteRenderer.sprite = HalfBlock;
            }
            else if (_brickLife == 1)
            {
                spriteRenderer.sprite = HollowBlock;
            }
        }
    }
}
