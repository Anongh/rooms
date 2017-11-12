using UnityEngine;
using System.Collections;
using UnityEngine.PostProcessing;

/// <summary>
/// Fades the screen from black after a new scene is loaded.
/// </summary>
[RequireComponent(typeof(PostProcessingBehaviour))]
public sealed class DesaturateScreenFade : MonoBehaviourSingleton<DesaturateScreenFade> {
    /// <summary>
    /// How long it takes to fade.
    /// </summary>
    public float FadeTime = 2.0f;

    private float _current = 1;
    private bool _isFading;
    private PostProcessingBehaviour _postProcess;
    private PostProcessingProfile _profile;
    private Material _fadeMaterial;
    private readonly YieldInstruction _fadeInstruction = new WaitForEndOfFrame();

    protected override void Awake() {
        base.Awake();

        _postProcess = GetComponent<PostProcessingBehaviour>();
        _profile = Instantiate(_postProcess.profile);
        _postProcess.profile = _profile;

        // Create the fade material
        _fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
    }

    /// <summary>
    /// Starts the fade in
    /// </summary>
    private void OnEnable() {
        _current = 1;
        StartFadeIn();
    }

//    /// <summary>
//    /// Starts a fade in when a new level is loaded
//    /// </summary>
//#if UNITY_5_4_OR_NEWER
//    void OnLevelFinishedLoading(int level) {
//#else
//    void OnLevelWasLoaded(int level) {
//#endif
//        current = 1;
//        StartCoroutine(Fade(0));
//    }

    protected override void OnDestroy() {
        base.OnDestroy();

        // Cleans up the fade material
        if (_fadeMaterial != null) {
            Destroy(_fadeMaterial);
        }

        DestroyImmediate(_profile);
    }

    public void StartFade(float to, System.Action callback = null) {
        if (_isFading) return;
        StartCoroutine(Fade(to, callback));
    }

    public void StartFadeOut(System.Action callback = null) {
        StartFade(1, callback);
    }

    public void StartFadeIn(System.Action callback = null) {
        StartFade(0, callback);
    }

    private IEnumerator Fade(float to, System.Action callback = null) {
        _isFading = true;
        float elapsedTime = 0.0f;
        var start = _current;
        while (elapsedTime < FadeTime) {
            _current = Mathf.Lerp(start, to, elapsedTime / FadeTime);
            UpdateSaturation();

            yield return _fadeInstruction;
            elapsedTime += Time.deltaTime;
        }

        _current = to;
        UpdateSaturation();
        _isFading = false;
        if (callback != null) callback();
    }

    private void UpdateSaturation() {
        var colorGrading = _profile.colorGrading.settings;
        colorGrading.basic.saturation = 1 - _current;
        _profile.colorGrading.settings = colorGrading;
    }

    /// <summary>
    /// Renders the fade overlay when attached to a camera object
    /// </summary>
    private void OnPostRender() {
        if (_current > 0) {
            _fadeMaterial.color = new Color(0, 0, 0, _current);
            _fadeMaterial.SetPass(0);
            GL.PushMatrix();
            GL.LoadOrtho();
            GL.Color(_fadeMaterial.color);
            GL.Begin(GL.QUADS);
            GL.Vertex3(0f, 0f, -12f);
            GL.Vertex3(0f, 1f, -12f);
            GL.Vertex3(1f, 1f, -12f);
            GL.Vertex3(1f, 0f, -12f);
            GL.End();
            GL.PopMatrix();
        }
    }
}
