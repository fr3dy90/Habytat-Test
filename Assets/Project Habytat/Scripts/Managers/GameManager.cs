using UnityEngine;
using UnityEngine.Serialization;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [FormerlySerializedAs("_loader")] [SerializeField] private LoaderController loaderController;
    [SerializeField] private SceneController _sceneController;
    [SerializeField] private SceneModel _actualScene;
  

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
        
        loaderController = GetComponentInChildren<LoaderController>();
        HandleScenes(_actualScene);
    }

    public void HandleScenes(SceneModel _sceneModel)
    {
        loaderController.LoadScene(_sceneModel);
    }
    
}

public enum SceneName
{
    Main,
    Game,
    Bonus
}
