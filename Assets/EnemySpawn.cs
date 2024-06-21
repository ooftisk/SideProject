using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]private GameObject _enemy;

    public void SpawnEnemy()
    {
      Instantiate(_enemy, transform.position, Quaternion.identity);  
    }
    
}
