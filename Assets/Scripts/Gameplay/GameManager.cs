using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviourSingleton<GameManager> {
    private const int NumLevels = 3;
    private const int HubBuildIndex = 0;

    [SerializeField] private bool[] _levelsCompleted = new bool[NumLevels];

    private string _currentScene;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetProgress();
            LoadScene(HubBuildIndex);
        }
    }

    public bool IsLevelComplete(int level) {
        return _levelsCompleted[level - 1];
    }

    public void SetCurrentScene(string sceneName) {
        Debug.LogFormat("[GameManager] Opening scene {0}", sceneName);
        _currentScene = sceneName;

        if (DesaturateScreenFade.HasInstance) DesaturateScreenFade.Instance.StartFadeIn();
    }

    public void CompleteLevel(Level level) {
        Debug.LogFormat("[GameManager] Level {0} complete", level.Index);
        _levelsCompleted[level.Index - 1] = true;
        LoadScene(HubBuildIndex);
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
            SceneManager.UnloadSceneAsync(_currentScene);
            SceneManager.LoadScene(buildIndex, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += OnSceneLoadedSetActive;
        });
    }

    private void OnSceneLoadedSetActive(Scene scene, LoadSceneMode loadSceneMode) {
        SceneManager.sceneLoaded -= OnSceneLoadedSetActive;
        SceneManager.SetActiveScene(scene);
    }

    private void ResetProgress() {
        System.Array.Clear(_levelsCompleted, 0, _levelsCompleted.Length);
    }
}
