
using UnityEngine;
using UnityEngine.Events;
public class CoreGameSignals : MonoBehaviour
{
    #region Singleton
    public static CoreGameSignals instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    #endregion

    public UnityAction<GameStates> onChangeGameState = delegate { };
    public UnityAction<int> onLevelInitialize = delegate { };
    public UnityAction onClearActiveLevel = delegate { };
    public UnityAction onLevelSuccesful = delegate { };
    public UnityAction onLevelFailed = delegate { };
    public UnityAction onNextLevel = delegate { };
    public UnityAction onRestartLevel = delegate { };
    public UnityAction onReset = delegate { };
    public UnityAction onPlay = delegate { };
}
