using UnityEngine;

public class HubLevel : MonoBehaviour {
    private void Start() {
        // TODO: light transitions
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameManager.Instance.GoToNextLevel();
        }
    }
}
