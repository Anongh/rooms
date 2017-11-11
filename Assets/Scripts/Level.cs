using UnityEngine;

public class Level : MonoBehaviour {
    [SerializeField] private Color _color;
    [SerializeField] private int _index;

    public Color Color {
        get { return _color; }
    }

    public int Index {
        get { return _index; }
    }

    public void Complete() {
        GameManager.Instance.CompleteLevel(this);
    }
}
