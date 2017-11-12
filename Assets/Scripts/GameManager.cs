using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager> {
    [SerializeField] private int _levelCount = 3;
    [SerializeField] private bool[] _levelsCompleted = new bool[3];

    private int _currentLevel;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetProgress();
            LoadScene(0);
        }
    }

    public bool IsLevelComplete(int level) {
        return _levelsCompleted[level];
    }

    public void CompleteLevel(Level level) {
        _levelsCompleted[level.Index] = true;
        LoadScene(0);
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
        // TODO: transition out

        SceneManager.UnloadSceneAsync(_currentLevel);
        _currentLevel = 0;
        SceneManager.LoadScene(_currentLevel, LoadSceneMode.Additive);
    }

    private void ResetProgress() {
        System.Array.Clear(_levelsCompleted, 0, _levelsCompleted.Length);
    }
}
