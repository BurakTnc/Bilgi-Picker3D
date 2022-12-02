using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Self Variables

    #region Public Variables

    #endregion

    #region Serialized Variables

    #endregion

    #region Private Variables

    #endregion

    #endregion

    private void OnEnable()
    {
        Subscribtions();
    }

    private void OnDisable()
    {
        UnSubscribtions();
    }

    private void Subscribtions()
    {
        CoreGameSignals.instance.onLevelSuccesful += OnSucces;
        CoreGameSignals.instance.onLevelFailed += OnFailed;
        CoreGameSignals.instance.onReset += OnReset;
    }

    private void UnSubscribtions()
    {
        CoreGameSignals.instance.onLevelSuccesful -= OnSucces;
        CoreGameSignals.instance.onLevelFailed -= OnFailed;
        CoreGameSignals.instance.onReset -= OnReset;
    }

    private void OnSucces()
    {

    }

    private void OnFailed()
    {

    }

    private void NextLevel()
    {
        CoreGameSignals.instance.onNextLevel?.Invoke();
    }

    private void RestartLevel()
    {
        CoreGameSignals.instance.onRestartLevel?.Invoke();
    }

    private void Play()
    {
        CoreGameSignals.instance.onPlay?.Invoke();
    }

    private void OnReset()
    {
        CoreGameSignals.instance.onReset?.Invoke();
    }

}
