using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A multiple-instance MonoBehaviour which allows its instances to be accessed directly.
/// Create subclasses like this:
/// public class Test : MonoBehaviourList<Test> ...
/// </summary>
public abstract class MonoBehaviourList<T> : MonoBehaviour where T : MonoBehaviourList<T> {
    private static List<T> _instances;

    public static List<T> Instances {
        get {
            if (_instances == null) _instances = new List<T>();
            return _instances;
        }
    }

    protected virtual void Awake() {
        Instances.Add((T) this);
    }

    protected virtual void OnDestroy() {
        Instances.Remove((T) this);
    }
}
