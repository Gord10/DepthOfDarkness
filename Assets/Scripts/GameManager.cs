using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float gravity = 2f;
    public float deepestPointY = 13f;

    private bool isPearlFound = false;

    public void OnFindingPearl()
    {
        isPearlFound = true;
        GameUi.Instance.ShowPearlText();
    }

    public void OnPlayerTouchSurface()
    {
        if(isPearlFound)
        {
            print("Game end");
        }
    }

}
