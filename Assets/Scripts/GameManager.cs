using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public float gravity = 2f;
    public float deepestPointY = 13f;

    private bool isPearlFound = false;
    private bool isGameOver = false;
    private float timeWhenGameWasOver = 0; //Uses Time.timeSinceLevelLoad;
    private Boss boss;

    private void Awake()
    {
        boss = FindObjectOfType<Boss>();
        boss.gameObject.SetActive(false);
    }

    public void OnFindingPearl()
    {
        isPearlFound = true;
        GameUi.Instance.ShowPearlText();
        boss.gameObject.SetActive(true);
        boss.StartFiringAtPlayer();
    }

    public void OnPlayerTouchSurface()
    {
        if(isPearlFound)
        {
            print("Game end");
        }
    }

    public void OnPlayerDeath()
    {
        isGameOver = true;
        GameUi.Instance.OnGameOver();
        timeWhenGameWasOver = Time.timeSinceLevelLoad;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public void Update()
    {
#if UNITY_STANDALONE
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
#endif

        if(IsGameOver() && Input.anyKeyDown)
        {
            float threshold = 0.2f;
            if(Time.timeSinceLevelLoad - timeWhenGameWasOver > threshold)
            {
                RestartScene();
            }
        }
    }

    private void RestartScene()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
