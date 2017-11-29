using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviourSingleton<GameManager> {
    private const int NumLevels = 3;
    private const int HubBuildIndex = 0;

    [SerializeField] private bool[] _levelsCompleted = new bool[NumLevels];
    [SerializeField] private AudioClip _winClip;

    private string _currentScene;
    private AudioSource _audioSource;

    protected override void Awake() {
        // Single instance
        if (HasInstance) {
            DestroyImmediate(gameObject);
            return;
        }

        base.Awake();

        // Persist across levels
        DontDestroyOnLoad(gameObject);

        _audioSource = gameObject.AddComponent<AudioSource>();
    }

    protected override void OnDestroy() {
        if (Instance == this) {
            base.OnDestroy();
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetProgress();
            LoadScene(HubBuildIndex);
        }
    }

    public bool IsLevelComplete(int level) {
        return _levelsCompleted[level - 1];
    }

    public bool AllLevelsComplete {
        get {
            return _levelsCompleted[_levelsCompleted.Length - 1];
        }
    }

    public void SetCurrentScene(string sceneName) {
        Debug.LogFormat("[GameManager] Opening scene {0}", sceneName);
        _currentScene = sceneName;

        if (DesaturateScreenFade.HasInstance) DesaturateScreenFade.Instance.StartFadeIn();
    }

    public void CompleteLevel(Level level) {
        Debug.LogFormat("[GameManager] Level {0} complete", level.Index);
        _levelsCompleted[level.Index - 1] = true;
        _audioSource.PlayOneShot(_winClip);

        DOTween.Sequence()
            .AppendInterval(2)
            .AppendCallback(() => LoadScene(HubBuildIndex));
    }

    public void GoToNextLevel() {
        int nextLevel = 1;
        for (int i = 0; i < _levelsCompleted.Length; ++i) {
            if (!_levelsCompleted[i]) {
                nextLevel = i + 1; // convert 0-indexed to 1-indexed
                break;
            }
        }

        LoadScene(nextLevel);
    }

    private void LoadScene(int buildIndex) {
        DesaturateScreenFade.Instance.StartFadeOut(() => {
            //SceneManager.UnloadSceneAsync(_currentScene);
            SceneManager.LoadScene(buildIndex);
            //SceneManager.sceneLoaded += OnSceneLoadedSetActive;
        });
    }

    //private void OnSceneLoadedSetActive(Scene scene, LoadSceneMode loadSceneMode) {
    //    SceneManager.sceneLoaded -= OnSceneLoadedSetActive;
    //    SceneManager.SetActiveScene(scene);
    //}

    private void ResetProgress() {
        System.Array.Clear(_levelsCompleted, 0, _levelsCompleted.Length);
    }
}
