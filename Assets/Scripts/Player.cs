using Fusion;
using UnityEngine;

public class Player : NetworkBehaviour
{
    private NetworkCharacterControllerPrototype _cc;
    [SerializeField] private Ball _ballPrefab;
    [SerializeField] private PhysicsBall _physicsBallPrefab;
    
    [Networked(OnChanged = nameof(OnBallSpawned))]
    public NetworkBool Spawned { get; set; }
    
    [Networked] private TickTimer _delay { get; set; }

    private Material _material;

    public Material Material
    {
        get
        {
            if (_material == null)
            {
                _material = GetComponentInChildren<MeshRenderer>().material;
            }

            return _material;
        }
    }

    private Vector3 _forward;

    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
        _forward = transform.forward;
    }

    public static void OnBallSpawned(Changed<Player> changed)
    {
        changed.Behaviour.Material.color = Color.white;
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.Direction.Normalize();
            _cc.Move(5 * data.Direction * Runner.DeltaTime);

            if (data.Direction.sqrMagnitude > 0)
            {
                _forward = data.Direction;
            }

            if (_delay.ExpiredOrNotRunning(Runner))
            {
                if ((data.Buttons & NetworkInputData.MouseButton1) != 0)
                {
                    _delay = TickTimer.CreateFromSeconds(Runner, 0.5f);
                    Runner.Spawn(_ballPrefab, transform.position + _forward, Quaternion.LookRotation(_forward),
                        Object.InputAuthority, (runner, o) =>
                        {
                            o.GetComponent<Ball>().Init();
                        });
                    Spawned = !Spawned;
                }
                else if ((data.Buttons & NetworkInputData.MouseButton2) != 0)
                {
                    _delay = TickTimer.CreateFromSeconds(Runner, 0.5f);
                    Runner.Spawn(_physicsBallPrefab, transform.position + _forward, Quaternion.LookRotation(_forward),
                        Object.InputAuthority,
                        (runner, o) =>
                        {
                            o.GetComponent<PhysicsBall>().Init(10 * _forward);
                        });
                    Spawned = !Spawned;
                }
            }
        }
    }

    public override void Render()
    {
        Material.color = Color.Lerp(Material.color, Color.blue, Time.deltaTime);
    }
}
