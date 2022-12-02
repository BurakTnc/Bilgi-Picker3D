using UnityEngine.Events;
using UnityEngine;

public class CoreUISignals : MonoBehaviour
{
    public UnityAction<UIPanelTypes, int> OnOpenPanel = delegate { };
    public UnityAction<int> OnClosePanel = delegate { };
    public UnityAction OnCloseAllPanel = delegate { };

    #region Singleton
    public static CoreUISignals instance;

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
}
