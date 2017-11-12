using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private Color _color;
    [SerializeField] private int _index;

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

    public void Complete() {
        if (_isCompleted) return;

        _isCompleted = true;
        GameManager.Instance.CompleteLevel(this);
    }
}
