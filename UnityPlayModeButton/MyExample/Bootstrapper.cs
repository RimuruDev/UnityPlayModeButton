using System;
using RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.Const;
using UnityEditor;
using UnityEngine;

namespace RimuruDev.External.RimuruDev.UnityPlayModeButton.MyExample
{
    // Допустим он находится на сцене Boot
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            // Apply debug settings..
            // others...

            Initialize();
        }

        // Тут у нас либо переход в стейт BootState либо то что душе угодно по инициализации игры
        private void Initialize()
        {
            if (Exist())
            {
                Destroy(gameObject);
                return;
            }

            EnterBootstrapState();

            return;

            void EnterBootstrapState()
            {
#if UNITY_EDITOR
                // Получили временный нейм сцены в который хотим перейти
                var customLevelName = SessionState.GetString(EditorSessionKeys.LevelDesignerPlayTest, null);

                // Можно проверить на какую-то конкретную сцену а можно болд положить и использоватьк ак есть) 
                if (customLevelName != null)
                {
                    if (customLevelName.StartsWith("Level_") || customLevelName.Contains("Level_"))
                    {
                        // gameStateMachine.PrepareStateMachine<string>(typeof(BootstrapState), customLevelName);
                        return;
                    }
                }
#endif
                // Если же переходим с Boot сцены без кнопки то грузимся как обычно.
                // gameStateMachine.PrepareStateMachine(typeof(BootstrapState));
            }

            bool Exist()
            {
                var bootstrapper = FindObjectOfType<Bootstrapper>();
                return bootstrapper is not null && bootstrapper != this;
            }
        }
    }
}