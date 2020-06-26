using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool didHitBird = collision.collider.GetComponent<Bird>() != null;
        if (didHitBird)
        {
            Destroy(gameObject);
        }
    }
}
