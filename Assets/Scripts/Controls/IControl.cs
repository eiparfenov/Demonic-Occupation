using System;
using UnityEngine;

namespace Controls
{
    public interface IControl
    {
        event Action onShootStart;
        event Action onShootProgress;
        event Action onShootStop;
        Vector3 moveDirection { get; }
        Vector3 shootDirection { get; }
    }
}