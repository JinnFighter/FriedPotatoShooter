using Fusion;
using UnityEngine;

public class RunnerWrapper : MonoBehaviour
{
    private NetworkRunner _runner;
    
    public async void StartGame(GameMode gameMode)
    {
        _runner = gameObject.AddComponent<NetworkRunner>();
        _runner.ProvideInput = true;

        var res = await _runner.StartGame(new StartGameArgs
        {
            GameMode = gameMode,
            SessionName = "TestRoom",
            Scene = 1,
            SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>(),
        });
        
        Debug.Log(res.ShutdownReason);
    }
}
