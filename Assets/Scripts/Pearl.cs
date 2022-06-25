using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering.Universal;

public class Pearl : MonoBehaviour
{
    public Color darkestTweenColor = new Color(0.6f, 0.6f, 0.6f);
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private Light2D light;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        light = GetComponentInChildren<Light2D>();
        spriteRenderer.DOColor(darkestTweenColor, 1f).SetLoops(-1, LoopType.Yoyo);
    }

    public void GetCollected()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
        spriteRenderer.DOKill();
        audioSource.Play();
        light.enabled = false;
        GameManager.Instance.OnFindingPearl();
    }
}
