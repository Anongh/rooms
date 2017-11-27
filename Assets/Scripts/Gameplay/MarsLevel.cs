using UnityEngine;

public sealed class MarsLevel : Level {
    [SerializeField] private LaserTarget[] _targets;

    private void Update() {
        var allTargetsHit = true;
        for (int i = 0; i < _targets.Length; ++i) {
            if (!_targets[i].IsTargeted) {
                allTargetsHit = false;
                break;
            }
        }

        if (allTargetsHit && !IsCompleted) {
            Complete();
        }
    }
}
