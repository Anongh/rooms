using UnityEngine;

public class Laser : MonoBehaviour {
    [SerializeField] private Color _color;
    [SerializeField] private LaserTarget _target;

    private bool _isOnTarget;
    private int _raycastLayerMask;

    public Color Color {
        get { return _color; }
    }

    private void Start() {
        _raycastLayerMask = LayerMask.GetMask("Laser Target");
    }

    private void Update() {
        _isOnTarget = false;

        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, 100,
            _raycastLayerMask, QueryTriggerInteraction.Ignore)) {
            if (hitInfo.collider.transform == _target.transform) {
                _isOnTarget = true;
            }
        }

        if (_isOnTarget) {
            _target.TargetedBy = this;
        } else if (_target.TargetedBy == this) {
            _target.TargetedBy = null;
        }
    }
}
