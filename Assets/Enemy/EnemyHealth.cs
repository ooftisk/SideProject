using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private UnityEvent<GameObject> Knock;
    [SerializeField] private UnityEvent Hit;
    public bool damaged;

    public void TakeDamage(int amount, GameObject sender)
    {
        health -= amount;
        if (health > 0)
        {
            Knock?.Invoke(sender);
            Hit?.Invoke();
        }
        else if (health <= 0)
        {
            Destroy(gameObject);
        }
        StartCoroutine(ResetDamaged());
    }


    private IEnumerator ResetDamaged() 
    {
        damaged = true;
        yield return new WaitForSeconds(0.25f);
        damaged = false;
    }
}


    
