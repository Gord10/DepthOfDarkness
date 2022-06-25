using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pearl : MonoBehaviour
{
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;

    private void Awake()
    {
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    public void GetCollected()
    {
        collider.enabled = false;
        spriteRenderer.enabled = false;
        audioSource.Play();
        GameManager.Instance.OnFindingPearl();
    }
}
