using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class ControllerInteraction : MonoBehaviour {
    public bool IsFocused { get; set; }
}
