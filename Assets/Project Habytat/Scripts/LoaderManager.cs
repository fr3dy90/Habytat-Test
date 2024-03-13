using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderManager : MonoBehaviour
{
    [SerializeField] private SceneFader _sceneFader;
    
    public Action OnLoadedScene;
    
    public void LoadSceneAsync(string sceneName)
    {
        StartCoroutine(LoadSceneAsyncCoroutine(sceneName));
    }

    private IEnumerator LoadSceneAsyncCoroutine(string sceneName)
    {
        yield return _sceneFader.FadeOut(1f);

        if (!SceneManager.GetSceneByName(sceneName).isLoaded)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                _sceneFader.SetProgressBar(asyncLoad.progress);
                yield return null;
            }
        }
        
        yield return _sceneFader.FadeIn(1f);
        OnLoadedScene?.Invoke();
    }
    
    private void DropTableAsync(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName);
    }

    public void OnInit()
    {
        SceneManager.sceneLoaded += SetActiveScene;
    }

    private void SetActiveScene(Scene scene, LoadSceneMode loadMode)
    {
        if(SceneManager.GetActiveScene().name != "Master") DropTableAsync(SceneManager.GetActiveScene().name);
        SceneManager.SetActiveScene(scene);
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= SetActiveScene;
    }
}
