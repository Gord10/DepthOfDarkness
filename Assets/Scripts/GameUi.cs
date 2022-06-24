using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUi : Singleton<GameUi>
{
    public Image healthBar;

    public void SetHealthBarRatio(float ratio)
    {
        healthBar.fillAmount = ratio;
    }
}
