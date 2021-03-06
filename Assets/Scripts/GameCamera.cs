using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GameCamera : MonoBehaviour
{
    public Color brightestColor = Color.blue;
    public Color darkestColor = Color.black;

    private Player player;
    private Camera camera;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.IsGameOver())
        {
            return;
        }
        //Follow the player in Y axis
        Vector3 position = transform.position;
        position.y = player.transform.position.y;
        transform.position = position;

        //Set the background color depending on how deep the player/camera is
        float t = Mathf.InverseLerp(0, GameManager.Instance.deepestPointY, transform.position.y);
        Color backgroundColor = Color.Lerp(brightestColor, darkestColor, t);
        camera.backgroundColor = backgroundColor;
    }
}
