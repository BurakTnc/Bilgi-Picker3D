using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    #region SelfVariables

    #region SerializedVariables
    [SerializeField] private GameStates state;
    #endregion

    #endregion


    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.instance.onChangeGameState += OnChangeGameState;
    }
    private void UnSubscribeEvents()
    {
        CoreGameSignals.instance.onChangeGameState -= OnChangeGameState;
    }
    private void OnDisable()
    {
        
    }
    private void OnChangeGameState(GameStates states)
    {
        state = states;
    }
}
