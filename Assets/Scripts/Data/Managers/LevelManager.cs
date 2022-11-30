using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Public Variables

    #endregion
    #region Seriralized Variables
    [SerializeField] private int totalLevelCount, levelID;
    [SerializeField] private Transform levelHolder;
    #endregion
    #region Private Variables
    private CD_Level _levelData;
    private OnLevelLoaderCommand _levelLoaderCommand;
    private OnLevelDestroyerCommand _levelDestroyerCommand;
    #endregion

    private void Awake()
    {
        _levelData = GetLevelData();
        levelID = GetActiveLevel();
        Init();
    }

    void Start()
    {
        OnInitializeLevel();
    }


    private CD_Level GetLevelData() => Resources.Load<CD_Level>(path: "Data/CD_Level");

    private int GetActiveLevel()
    {
        if (ES3.FileExists())
        {
            if (ES3.KeyExists("Level"))
            {
                return ES3.Load<int>(key: "Level");
            }
        }

        return 0;
        
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }
    private void OnDisable()
    {
        UnSubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.instance.onLevelInitialize += _levelLoaderCommand.Execute;
        CoreGameSignals.instance.onClearActiveLevel += _levelDestroyerCommand.Execute;
        CoreGameSignals.instance.onNextLevel += OnNextLevel;
        CoreGameSignals.instance.onRestartLevel += OnRestartLevel;
    }
    private void UnSubscribeEvents()
    {
        CoreGameSignals.instance.onLevelInitialize -= _levelLoaderCommand.Execute;
        CoreGameSignals.instance.onClearActiveLevel -= _levelDestroyerCommand.Execute;
        CoreGameSignals.instance.onNextLevel -= OnNextLevel;
        CoreGameSignals.instance.onRestartLevel -= OnRestartLevel;
    }

    private void Init()
    {
        _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
        _levelDestroyerCommand = new OnLevelDestroyerCommand(levelHolder);
    }

    private void OnInitializeLevel()
    {
        _levelLoaderCommand.Execute(levelID);
    }

    private void OnClearActiveLevel()
    {
        _levelDestroyerCommand.Execute();
    }
    private void OnNextLevel()
    {
        levelID++;
        CoreGameSignals.instance.onClearActiveLevel?.Invoke();
        CoreGameSignals.instance.onReset?.Invoke();
        CoreGameSignals.instance.onLevelInitialize?.Invoke(levelID);
    }
    private void OnRestartLevel()
    {
        CoreGameSignals.instance.onClearActiveLevel?.Invoke();
        CoreGameSignals.instance.onReset?.Invoke();
        CoreGameSignals.instance.onLevelInitialize?.Invoke(levelID);
    }

}
