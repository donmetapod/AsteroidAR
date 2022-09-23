using System.Linq;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITOR
public static class FindMissingScripts
{
    [MenuItem("Utilities/Find Missing Scripts in Project")]
    static void FindMissingScriptsInProject()
    {
        string[] _prefabPaths = AssetDatabase.GetAllAssetPaths().Where(path => path.EndsWith(".prefab", System.StringComparison.OrdinalIgnoreCase)).ToArray();
        int _missingScriptsInPrefabsCount = 0;
        foreach (var path in _prefabPaths)
        {
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            foreach (var component in prefab.GetComponentsInChildren<Component>())
            {
                if (component == null)
                {
                    Debug.Log($"Prefab found with missing script {path}", prefab);
                    _missingScriptsInPrefabsCount++;
                    break;
                }
            }
        }
        if (_missingScriptsInPrefabsCount == 0)
        {
            Debug.Log("No missing scripts found in prefabs");
        }
    }

    [MenuItem("Utilities/Find Missing Scripts in Scene")]
    static void FindMissingScriptsInScene()
    {
        int _missingScriptsInObjectsCount = 0;
        foreach (var gameObject in GameObject.FindObjectsOfType<GameObject>(true))
        {
            foreach (var component in gameObject.GetComponentsInChildren<Component>())
            {
                if (component == null)
                {
                    Debug.Log($"{gameObject.name} is missing a script", gameObject);
                    _missingScriptsInObjectsCount++;
                    break;
                }
            }
        }

        if (_missingScriptsInObjectsCount == 0)
        {
            Debug.Log("No missing scripts in scene objects");
        }
    }
}
#endif