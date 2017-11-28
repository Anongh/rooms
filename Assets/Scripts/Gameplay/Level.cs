using UnityEngine;

public sealed class Level : MonoBehaviour {
    [SerializeField] private Color _color;
    [SerializeField] private int _index;
    [SerializeField] private LaserTarget[] _targets;

    private bool _isCompleted;

    public Color Color {
        get { return _color; }
    }

    public int Index {
        get { return _index; }
    }

    public bool IsCompleted {
        get { return _isCompleted; }
    }

    private void Start() {
        GameManager.Instance.SetCurrentScene(gameObject.scene.name);
    }

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

    [ContextMenu("Complete")]
    public void Complete() {
        if (_isCompleted) return;

        _isCompleted = true;
        GameManager.Instance.CompleteLevel(this);
    }
}
