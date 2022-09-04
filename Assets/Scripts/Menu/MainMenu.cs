using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [field: SerializeField] public Button HostButton { get; private set; }
    [field: SerializeField] public Button JoinButton { get; private set; }

    [SerializeField] private NetworkRunner _runner;
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
            StartGame(GameMode.Client);
        }
    }

    private void OnHostButtonClicked()
    {
        if (!_hasSelected)
        {
            _hasSelected = true;
            StartGame(GameMode.Host);
        }
    }
    
    private async void StartGame(GameMode gameMode)
    {
        _runner.ProvideInput = true;

        await _runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            SessionName = "TestRoom",
            Scene = SceneManager.GetSceneByName("Gameplay").buildIndex,
            SceneManager = _runner.gameObject.AddComponent<NetworkSceneManagerDefault>(),
        });
    }
}
