using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBulletCollisionDetect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        { 
            Destroy(gameObject);
        }
    }
}
