using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [field: SerializeField] public Button HostButton { get; private set; }
    [field: SerializeField] public Button JoinButton { get; private set; }
    
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
        Debug.Log("Joining Room");
    }

    private void OnHostButtonClicked()
    {
        Debug.Log("Hosting Room");
    }
}
