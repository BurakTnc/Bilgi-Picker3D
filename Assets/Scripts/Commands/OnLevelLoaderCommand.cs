using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLevelLoaderCommand :ICommand
{
    private Transform _levelHolder;


    public OnLevelLoaderCommand (Transform levelHolder)
    {
        _levelHolder = levelHolder;
    }

    public void Execute()
    {

    }

    public void Execute(int value)
    {
        Object.Instantiate(Resources.Load<GameObject>(path: $"LevelPrefabs/level-{value}"),_levelHolder);
    }
}
