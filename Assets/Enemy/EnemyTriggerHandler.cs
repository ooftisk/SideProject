using UnityEngine;

public class EnemyTriggerHandler : MonoBehaviour
{
    public bool PlayerDetected;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerDetected = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
          PlayerDetected = false;
        }
    }

}
