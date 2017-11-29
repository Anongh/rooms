using System.Collections;
using UnityEngine;

public sealed class HubLevel : MonoBehaviour {
    [SerializeField] private Color[] _colors;
    [SerializeField] private int _numParticles;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GameObject _thanksMessage;
    [SerializeField] private GameObject _infoMessage;

    private void Start() {
        for (int i = 0; i < _colors.Length; ++i) {
            if (GameManager.Instance.IsLevelComplete(i + 1)) {
                _particleSystem.Emit(new ParticleSystem.EmitParams {
                    startColor = _colors[i]
                }, _numParticles);
            }
        }

        GameManager.Instance.SetCurrentScene(gameObject.scene.name);

        _thanksMessage.SetActive(GameManager.Instance.AllLevelsComplete);
        _infoMessage.SetActive(!GameManager.Instance.AllLevelsComplete);

        if (GameManager.Instance.AllLevelsComplete) {
            StartCoroutine(Finish());
        }
    }

    private IEnumerator Finish() {
        for (int i = 0; i < 15; ++i) {
            _particleSystem.Emit(new ParticleSystem.EmitParams {
                startColor = _colors[i % _colors.Length]
            }, 30);
            yield return new WaitForSeconds(0.4f);
        }

        DesaturateScreenFade.Instance.FadeColor = Color.white;
        DesaturateScreenFade.Instance.FadeTime = 5;
    }

    private void Update() {
        if (Input.GetButton("Fire1") && !GameManager.Instance.AllLevelsComplete) {
            GameManager.Instance.GoToNextLevel();
        }
    }
}
