using System;
using UnityEngine;
using Zenject;
using Vector2 = UnityEngine.Vector2;

namespace Controls
{
    public class PCControl: IControl ,ITickable
    {
        public event Action onShootStart;
        public event Action onShootProgress;
        public event Action onShootStop;
        public Vector3 moveDirection { get; private set; }
        public Vector3 shootDirection { get; private set; }

        private bool _shootInProgress;

        public void Tick()
        {
            Vector3 moveDir = new Vector3(
                (Input.GetKey(KeyCode.D) ? 1f : 0f) - (Input.GetKey(KeyCode.A) ? 1f : 0f),
                (Input.GetKey(KeyCode.W) ? 1f : 0f) - (Input.GetKey(KeyCode.S) ? 1f : 0f)
            ).normalized;
            moveDirection = moveDir;

            if (Input.GetMouseButton(0))
            {
                shootDirection = (
                        Input.mousePosition -
                        new Vector3(Screen.width / 2f, Screen.height / 2f)
                ).normalized;
                
            }
            
            if(Input.GetMouseButtonDown(0))
                onShootStart?.Invoke();
            if(Input.GetMouseButtonUp(0))
                onShootStop?.Invoke();
            if(_shootInProgress && Input.GetMouseButton(0))
                onShootProgress?.Invoke();
                
            _shootInProgress = Input.GetMouseButton(0);
        }

    }
}