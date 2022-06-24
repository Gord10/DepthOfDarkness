using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Fish : MonoBehaviour
{
    public float speed = 1;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.DOMoveX(transform.position.x + Random.Range(0.5f, 1.5f), speed).SetSpeedBased().
                                                           SetLoops(-1, LoopType.Yoyo).
                                                           SetEase(Ease.Linear).
                                                           OnStepComplete(() => spriteRenderer.flipX = !spriteRenderer.flipX);

        //The deepest the fish, the darkest it is
        float t = Mathf.InverseLerp(0, GameManager.Instance.deepestPointY, transform.position.y);
        Color color = Color.Lerp(Color.white, Color.black, t);
        spriteRenderer.color = color; 
    }
}
