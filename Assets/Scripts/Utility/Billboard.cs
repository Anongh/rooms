using UnityEngine;

/// <summary>
/// Always face -Z towards the active camera.
/// </summary>
[DisallowMultipleComponent]
public sealed class Billboard : MonoBehaviour {
    private void Update() {
        var direction = transform.position - Camera.main.transform.position;
        transform.forward = direction;
    }
}
