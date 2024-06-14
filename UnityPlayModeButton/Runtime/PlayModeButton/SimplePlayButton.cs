#if UNITY_EDITOR

#if UNITY_TOOLBAR_EXTENDER
#else
using RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.Const;
using RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.Toolbar;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.PlayModeButton
{
    [InitializeOnLoad]
    public static class SimplePlayButton
    {
        private const string ButtonDescription = "Нормалньно запустится с Boot сцены";
        
        static SimplePlayButton()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            GUILayout.FlexibleSpace();

            var iconTexture = (Texture2D)Resources.Load(EditorAssetPath.PlayModeButtonIcon, typeof(Texture2D));

            if (iconTexture != null)
            {
                var buttonStyle = new GUIStyle("Command")
                {
                    imagePosition = ImagePosition.ImageAbove,
                };

                var buttonContent = new GUIContent(iconTexture, ButtonDescription);

                if (GUILayout.Button(buttonContent, buttonStyle))
                    StartWithBootScene();
            }
            else
            {
                if (GUILayout.Button(new GUIContent("Play Boot Scene", ButtonDescription), new GUIStyle("Command")))
                {
                    StartWithBootScene();
                }
            }
        }

        private static void StartWithBootScene()
        {
            if (EditorApplication.isPlaying)
            {
                EditorApplication.isPlaying = false;
            }
            else
            {
                EditorSceneManager.SaveOpenScenes();

                SessionState.SetString(EditorSessionKeys.LevelDesignerPlayTest, SceneManager.GetActiveScene().name);

                // Открываем сцену и переходит в Play Mode ;3
                EditorSceneManager.OpenScene(EditorAssetPath.BootScenePath);
                EditorApplication.isPlaying = true;
            }
        }
    }
}
#endif
#endif