using UnityEngine;

public class MyTest : MonoBehaviour
{
    private void Awake()
    {
        LoaderController.OnCompleteLoadScene += () => { Debug.Log("OnCompleteLoadScene"); };
    }
}
