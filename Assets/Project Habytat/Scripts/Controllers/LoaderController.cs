using System;
using System.Collections;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderController : MonoBehaviour
{
    [SerializeField] private LoaderView _loaderView;
    private IEnumerator onHandleFade;
    private Scene _actualScene;
    private const float _zero = 0;
    private const float _one = 1;
    public static Action OnCompleteLoadScene;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    

    private void OnSceneLoaded(Scene sceneLoaded, LoadSceneMode loadSceneMode)
    {
        _actualScene = sceneLoaded;
        SceneManager.SetActiveScene(_actualScene);
    }

    public void LoadScene(SceneModel _sceneModel)
    {
        if (onHandleFade != null)
        {
            StopCoroutine(onHandleFade);
        }
        onHandleFade = OnFade(_zero, 0f, () =>OnStartLoadScene(_sceneModel));
        StartCoroutine(onHandleFade);
    }

    private void OnStartLoadScene(SceneModel _sceneModel)
    {
        AsyncOperation loadState = SceneManager.LoadSceneAsync(_sceneModel.actualSceneName.ToString(), LoadSceneMode.Additive);
        do
        {
            _loaderView.SetProgress(loadState.progress);
        }while (loadState.progress <= 0.89f);

        if (onHandleFade != null)
        {
            StopCoroutine(onHandleFade);
        }
        onHandleFade = OnFade(_one, loadState.progress, OnComplete);
        StartCoroutine(onHandleFade);
    }

    private void OnComplete()
    {
        
    }

    private IEnumerator OnFade(float start, float _fillValue, Action onComplete)
    {
        _loaderView.HardFade(start, true, _fillValue);
        _loaderView.gameObject.SetActive(true);
        float target = start > _zero ? _zero : _one;
        
        while (start != target)
        {
            start = Mathf.MoveTowards(start, target, Time.deltaTime/1.5f);
           _loaderView.SetAlpha(start);
            yield return null;
        }

        if (target > _zero)
        {
            _loaderView.HardFade(_one, true, _fillValue);
            _loaderView.gameObject.SetActive(false);
        }
        else
        {
            _loaderView.HardFade(_zero, false, _fillValue);
        }
        
        onComplete?.Invoke();
    }
}

