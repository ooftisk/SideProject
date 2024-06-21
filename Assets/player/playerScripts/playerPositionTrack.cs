using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionTrack : MonoBehaviour
{
    private static Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = transform;
    }

    public static Vector3 PlayerPosition
    { 
        get { return _playerTransform.position; }
    }
}
