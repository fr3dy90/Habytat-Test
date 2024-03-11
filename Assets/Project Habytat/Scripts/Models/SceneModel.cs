using UnityEngine;

[CreateAssetMenu(fileName = "SceneModel", menuName = "ScriptableObjects/SceneModel")]
public class SceneModel : ScriptableObject
{
   public SceneName actualSceneName;
   public SceneState actualSceneState;
}
