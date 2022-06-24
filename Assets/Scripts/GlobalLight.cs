using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLight : MonoBehaviour
{
    public float brightestIntensity = 0.5f;
    public float darkestIntensity = 0;

    private Light2D light;
    private Player player;

    private void Awake()
    {
        light = GetComponent<Light2D>();
        player = FindObjectOfType<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Mathf.InverseLerp(0, GameManager.Instance.deepestPointY, player.transform.position.y);
        light.intensity = Mathf.Lerp(brightestIntensity, darkestIntensity, t);
    }
}
