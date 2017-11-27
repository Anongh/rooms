using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class VideoPlayerMultiTexture : MonoBehaviour {
    [SerializeField] private Renderer _renderer;
    [SerializeField] private string[] _materialProperties;

    private VideoPlayer _player;
    private MaterialPropertyBlock _propertyBlock;
    private int[] _materialIds;

    private void Awake() {
        _player = GetComponent<VideoPlayer>();

        _propertyBlock = new MaterialPropertyBlock();
        _materialIds = new int[_materialProperties.Length];
        for (var i = 0; i < _materialProperties.Length; ++i) {
            _materialIds[i] = Shader.PropertyToID(_materialProperties[i]);
        }
    }

    private void Update() {
        if (_player.texture == null) return;

        for (var i = 0; i < _materialIds.Length; ++i) {
            _propertyBlock.SetTexture(_materialIds[i], _player.texture);
        }

        _renderer.SetPropertyBlock(_propertyBlock);
    }
}
