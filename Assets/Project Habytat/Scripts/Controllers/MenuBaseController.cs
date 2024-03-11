using UnityEngine;

public class MenuBaseController : MonoBehaviour
{
    [SerializeField] private SceneMainController _sceneController;
    private void OnEnable()
    {
        MenuInputController.Instance.onAcceopt += OnAccept;
    }
    
    private void OnDisable()
    {
        MenuInputController.Instance.onAcceopt -= OnAccept;
    }

    private void OnAccept()
    {
        _sceneController.OnLoadScene();   
    }
}
