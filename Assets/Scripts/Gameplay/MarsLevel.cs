using UnityEngine;

public class MarsLevel : Level {
    private const int NumLasers = 3;

    [SerializeField] private Transform[] _lasers;

    private bool[] _isOnTarget = new bool[NumLasers];
    private int _raycastLayerMask;

    private void Start() {
        _raycastLayerMask = LayerMask.GetMask("Laser Target");
    }

    private void Update() {
        for (int i = 0; i < NumLasers; ++i) {
            RaycastHit hitInfo;
            if (Physics.Raycast(_lasers[i].position, _lasers[i].forward, out hitInfo, 100,
                _raycastLayerMask, QueryTriggerInteraction.Ignore)) {
                // TODO: specific satellite
                _isOnTarget[i] = true;
            } else {
                _isOnTarget[i] = false;
            }
        }
    }
}
