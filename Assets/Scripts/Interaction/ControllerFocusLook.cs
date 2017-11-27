using UnityEngine;

public class ControllerFocusLook : MonoBehaviour {
    private const float MaxDistance = 10f;

    private ControllerInteraction _lastHit;

    private void Update() {
        RaycastHit hitInfo;
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, MaxDistance, 0,
            QueryTriggerInteraction.Collide)) {

            var interaction = hitInfo.transform.GetComponent<ControllerInteraction>();
            if (interaction) {
                UpdateInteraction(interaction);
                return;
            }
        }

        UpdateInteraction(null);
    }

    private void UpdateInteraction(ControllerInteraction newInteraction) {
        if (newInteraction != _lastHit) {
            if (_lastHit) _lastHit.IsFocused = false;
            if (newInteraction) newInteraction.IsFocused = true;
            _lastHit = newInteraction;
        }
    }
}
