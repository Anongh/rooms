using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Add this class to a GameObject to receive its collision events and make them publicly available to other classes.
/// </summary>
public sealed class CollisionListener : MonoBehaviour {
    [System.Serializable]
    public class CollisionEvent : UnityEvent<Collision> {
    }

    [System.Serializable]
    public class TriggerEvent : UnityEvent<Collider> {
    }

    [SerializeField] private CollisionEvent _collisionEnter, _collisionExit;
    [SerializeField] private TriggerEvent _triggerEnter, _triggerExit;

    public CollisionEvent CollisionEnter {
        get { return _collisionEnter; }
    }

    public CollisionEvent CollisionExit {
        get { return _collisionExit; }
    }

    public TriggerEvent TriggerEnter {
        get { return _triggerEnter; }
    }

    public TriggerEvent TriggerExit {
        get { return _triggerExit; }
    }

    private void OnCollisionEnter(Collision collision) {
        _collisionEnter.Invoke(collision);
    }

    private void OnCollisionExit(Collision collision) {
        _collisionExit.Invoke(collision);
    }

    private void OnTriggerEnter(Collider other) {
        _triggerEnter.Invoke(other);
    }

    private void OnTriggerExit(Collider other) {
        _triggerExit.Invoke(other);
    }
}
