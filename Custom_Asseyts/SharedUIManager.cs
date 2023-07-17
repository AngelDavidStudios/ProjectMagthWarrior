using UnityEngine;

public class SharedUIManager : Singleton<SharedUIManager>
{

    [SerializeField] private LoadingPanel _loadingPanel;

    public static LoadingPanel LoadingPanel => Instance?._loadingPanel;
}