using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] protected SceneModel _sceneModel;
    [SerializeField] protected AudioModel _audioModel;
    [SerializeField] protected SceneModel _sceneToLoad;
    
    protected virtual void Awake()
    {
        HandleScene();   
    }

    private void HandleScene()
    {
        switch (_sceneModel.actualSceneState)
        {
            case SceneState.Init:
                OnInit();
                break;
        }
    }
    
    protected virtual void OnInit()
    {
        _sceneModel.actualSceneState = SceneState.Init;
    }
}

public enum SceneState
{
    Init
}
