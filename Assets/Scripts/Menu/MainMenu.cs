using Fusion;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [field: SerializeField] public Button HostButton { get; private set; }
    [field: SerializeField] public Button JoinButton { get; private set; }

    [SerializeField] private RunnerWrapper _runnerRoot;
    private bool _hasSelected;
    
    // Start is called before the first frame update
    void Start()
    {
        HostButton.onClick.AddListener(OnHostButtonClicked);
        JoinButton.onClick.AddListener(OnJoinButtonClicked);
    }

    private void OnDestroy()
    {
        HostButton.onClick.RemoveListener(OnHostButtonClicked);
        JoinButton.onClick.RemoveListener(OnJoinButtonClicked);
    }

    private void OnJoinButtonClicked()
    {
        if (!_hasSelected)
        {
            _hasSelected = true;
            _runnerRoot.StartGame(GameMode.Client);
        }
    }

    private void OnHostButtonClicked()
    {
        if (!_hasSelected)
        {
            _hasSelected = true;
            _runnerRoot.StartGame(GameMode.Host);
        }
    }
}
