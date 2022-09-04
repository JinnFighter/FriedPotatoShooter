using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public const byte MouseButton1 = 0x01;

    public byte Buttons;
    public Vector3 Direction;
}
