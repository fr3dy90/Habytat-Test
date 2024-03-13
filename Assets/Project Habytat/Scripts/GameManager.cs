using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private LoaderManager _loaderManager; 
    
    public static GameManager Instance;
    public Action OnInitScene;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        _loaderManager.OnInit();
        _loaderManager.OnLoadedScene += OnSceneLoaded;
        OnLoadScene(GameScenes.Main);
    }
    
    private void OnLoadScene(GameScenes sceneToLoad)
    {
        _loaderManager.LoadSceneAsync(sceneToLoad.ToString());
    }
    
    private void OnSceneLoaded()
    {
        OnInitScene?.Invoke();        
    }

   
}

public enum GameStates
{
    OnPause,
    OnGame,
    
}

public enum GameScenes
{
    Main,
    Game,
    Bonus
}
