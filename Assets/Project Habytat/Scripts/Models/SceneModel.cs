using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSceneModel", menuName = "SceneModel")]
public class SceneModel : ScriptableObject
{
    public List<GameScenes> scenesToGo;
    public SceneInitializationPoint initializationPoint;
}

public enum SceneInitializationPoint
{
    None,
    OnInit,
    OnStart,
    Manual 
}