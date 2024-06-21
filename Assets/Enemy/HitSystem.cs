using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSystem : MonoBehaviour
{
    private Color _originalColor;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _cdTime;

    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }

    public void HitEffect()
    {
        StopAllCoroutines();
        _spriteRenderer.color = Color.red;
        StartCoroutine(Reset());
    }


    private IEnumerator Reset() 
    {
        yield return new WaitForSeconds(_cdTime);
        _spriteRenderer.color = _originalColor;
    }
}
