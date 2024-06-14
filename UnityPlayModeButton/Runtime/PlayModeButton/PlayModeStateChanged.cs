#if UNITY_EDITOR
#if UNITY_TOOLBAR_EXTENDER
#else
using RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.Const;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.PlayModeButton
{
    [InitializeOnLoad]
    public static class PlayModeStateChanged
    {
        static PlayModeStateChanged()
        {
            EditorApplication.playModeStateChanged += LogPlayModeState;
        }

        private static void LogPlayModeState(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredEditMode)
            {
                var lastScene = SessionState.GetString(EditorSessionKeys.LevelDesignerPlayTest, SceneName.Boot);

                if (!string.IsNullOrEmpty(lastScene) && lastScene != SceneName.Boot)
                {
                    var guids = AssetDatabase.FindAssets(lastScene + " t:Scene", new[] { EditorAssetPath.AllScenesPath });
                    if (guids.Length == 0)
                    {
                        Debug.LogWarning("Scene '" + lastScene + "' not found. Loading 'Boot' scene.");
                        EditorSceneManager.OpenScene(EditorAssetPath.BootScenePath);
                    }
                    else
                    {
                        var scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
                        EditorSceneManager.OpenScene(scenePath);
                    }
                }
            }
        }
    }
}
#endif
#endif