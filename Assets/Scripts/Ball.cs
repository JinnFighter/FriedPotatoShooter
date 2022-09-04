using Fusion;
using UnityEngine;

public class Ball : NetworkBehaviour
{
    private Transform _transform;
    [Networked] private TickTimer _life { get; set; }

    public void Init()
    {
        _life = TickTimer.CreateFromSeconds(Runner, 5f);
    }

    private void Awake()
    {
        _transform = transform;
    }

    public override void FixedUpdateNetwork()
    {
        if (_life.Expired(Runner))
        {
            Runner.Despawn(Object);
        }
        else
        {
            _transform.position += 5 * _transform.forward * Runner.DeltaTime;
        }
    }
}
