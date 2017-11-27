using eageramoeba.Lasers;
using UnityEngine;

public class LaserTarget : MonoBehaviour {
    [SerializeField] private Renderer _renderer;
    [SerializeField] private Color _color = Color.red;
    [SerializeField] private Color _offColor = Color.black;
    [SerializeField] private float _emissionColorMult = 1;
    [SerializeField] private Material _correctMaterial;
    [SerializeField] private bool _setColor = true;
    [SerializeField] private bool _setEmission = true;
    [SerializeField] private float _untargetAfterTime = 0.2f;

    private laser _lastHitLaser;
    private float _lastHitTime;
    private MaterialPropertyBlock _propertyBlock;
    private bool _isTargeted;

    public bool IsTargeted {
        get { return _isTargeted; }
    }

    private void Start() {
        _propertyBlock = new MaterialPropertyBlock();
        laserSystem.instance.LaserHit += OnLaserHit;
    }

    private void OnDestroy() {
        laserSystem.instance.LaserHit -= OnLaserHit;
    }

    private void Update() {
        // After not being hit for a while, untarget
        if (_isTargeted && Time.time - _lastHitTime > _untargetAfterTime) {
            SetTargeted(false);
        }
    }

    private void OnLaserHit(laser hitLaser, GameObject hitObject) {
        if (hitObject != gameObject) return;

        _lastHitTime = Time.time;
        if (hitLaser == _lastHitLaser) return;
        _lastHitLaser = hitLaser;

        // Check if the material is the right one
        var hitMaterial = hitLaser.GetComponent<LineRenderer>().sharedMaterial;
        SetTargeted(hitMaterial == _correctMaterial);
    }

    private void SetTargeted(bool isTargeted) {
        _isTargeted = isTargeted;
        if (!isTargeted) {
            _lastHitLaser = null;
        }

        var color = _isTargeted ? _color : _offColor;
        if (_setColor) _propertyBlock.SetColor("_Color", color);
        if (_setEmission) _propertyBlock.SetColor("_EmissionColor", color * _emissionColorMult);
        _renderer.SetPropertyBlock(_propertyBlock);
    }
}
