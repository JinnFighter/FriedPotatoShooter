using Fusion;
using UnityEngine;

public struct NetworkInputData : INetworkInput
{
    public const byte MouseButton1 = 0x01;
    public const byte MouseButton2 = 0x02;

    public byte Buttons;
    public Vector3 Direction;
}
