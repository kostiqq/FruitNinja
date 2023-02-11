using UnityEngine;

[CreateAssetMenu(fileName = "SceneConfig", menuName = "Configs/Scene config", order = 4)]
public class SceneConfig : ScriptableObject
{
    public int MenuSceneIndex = 0;
    public int GameSceneIndex = 1;
}
