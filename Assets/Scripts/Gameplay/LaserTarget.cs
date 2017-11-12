using UnityEngine;

public class LaserTarget : MonoBehaviour {
    [SerializeField] private Renderer _renderer;

    private Laser _targetedBy;
    private MaterialPropertyBlock _propertyBlock;

    public Laser TargetedBy {
        get { return _targetedBy; }
        set {
            if (value != _targetedBy) {
                _targetedBy = value;
                TargetedChanged();
            }
        }
    }

    private void Start() {
        _propertyBlock = new MaterialPropertyBlock();
    }

    private void TargetedChanged() {
        var color = _targetedBy != null ? _targetedBy.Color : Color.black;
        _propertyBlock.SetColor("_EmissionColor", color);
        _renderer.SetPropertyBlock(_propertyBlock);
    }
}
