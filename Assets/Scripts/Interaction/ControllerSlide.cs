using UnityEngine;

public sealed class ControllerSlide : ControllerInteraction {
    [SerializeField] private Transform _slider;
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private float _speed = 1;

//    private bool _isFocused;

    private void Update() {
        if (!IsFocused) return;

        var slideInput = Input.GetAxis("Xbox RStick X");

        var offset = _point2.position - _point1.position;
        var distance = offset.magnitude;
        var direction = offset / distance;

        var t = Vector3.Dot(_slider.position - _point1.position, direction);
        t += slideInput * _speed * Time.deltaTime;
        t /= distance;
        t = Mathf.Clamp01(t);

        _slider.position = Vector3.Lerp(_point1.position, _point2.position, t);
    }

//    private void OnTriggerEnter(Collider other) {
//        if (other.CompareTag("Player")) {
//            _isFocused = true;
//        }
//    }
//
//    private void OnTriggerExit(Collider other) {
//        if (other.CompareTag("Player")) {
//            _isFocused = false;
//        }
//    }

    private void OnDrawGizmos() {
        if (!_slider) return;

        Gizmos.color = Color.white;
        if (_point1) Gizmos.DrawLine(_point1.position, _slider.position);
        if (_point2) Gizmos.DrawLine(_point2.position, _slider.position);
    }
}
