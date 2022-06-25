using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : Singleton<Music>
{
    protected override void Awake()
    {
        if(_instance)
        {
            Destroy(gameObject);
            return;
        }

        base.Awake();
        DontDestroyOnLoad(gameObject);
    }
}
