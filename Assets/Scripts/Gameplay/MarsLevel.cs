using UnityEngine;

public sealed class MarsLevel : Level {
    private const int NumLasers = 3;

    [SerializeField] private LaserTarget[] _targets;

    private bool[] _isOnTarget = new bool[NumLasers];
    private int _raycastLayerMask;

    private void Start() {
        _raycastLayerMask = LayerMask.GetMask("Laser Target");
    }

    private void Update() {
        var allTargetsHit = true;
        for (int i = 0; i < _targets.Length; ++i) {
            if (_targets[i].TargetedBy == null) {
                allTargetsHit = false;
                break;
            }
        }

        if (allTargetsHit && !IsCompleted) {
            Complete();
        }
    }
}
