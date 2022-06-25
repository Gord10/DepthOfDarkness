using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : Singleton<GameUi>
{
    public Image healthBar;
    public GameObject pearlInfoText;
    public Image pearlImage;
    public GameObject gameOverText;

    protected override void Awake()
    {
        base.Awake();
        pearlInfoText.SetActive(false);
        pearlImage.gameObject.SetActive(false);
        gameOverText.SetActive(false);
    }

    public void SetHealthBarRatio(float ratio)
    {
        healthBar.fillAmount = ratio;
    }

    public void ShowPearlText()
    {
        pearlInfoText.SetActive(true);
        pearlImage.gameObject.SetActive(true);
    }

    public void OnGameOver()
    {
        healthBar.transform.parent.gameObject.SetActive(false);
        gameOverText.SetActive(true);
    }
}
