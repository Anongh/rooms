﻿using UnityEngine;

public class HubLevel : MonoBehaviour {
    [SerializeField] private Color[] _colors;
    [SerializeField] private int _numParticles;
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start() {
        for (int i = 0; i < _colors.Length; ++i) {
            if (GameManager.Instance.IsLevelComplete(i)) {
                _particleSystem.Emit(new ParticleSystem.EmitParams {
                    startColor = _colors[i]
                }, _numParticles);
            }
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            GameManager.Instance.GoToNextLevel();
        }
    }
}
