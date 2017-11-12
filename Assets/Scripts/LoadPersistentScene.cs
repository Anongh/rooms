using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPersistentScene : MonoBehaviour {
    private const string SceneName = "PersistentScene";

    private void Awake() {
        var persistentScene = SceneManager.GetSceneByName(SceneName);

        if (!persistentScene.IsValid()) {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
            //SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    //private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode) {
    //    if (scene.name == SceneName) {
    //        SceneManager.sceneLoaded -= OnSceneLoaded;
    //        SceneManager.SetActiveScene(scene);
    //    }
    //}
}
