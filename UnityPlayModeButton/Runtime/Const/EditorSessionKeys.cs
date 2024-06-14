namespace RimuruDev.External.RimuruDev.UnityPlayModeButton.Runtime.Const
{
    public static class EditorSessionKeys
    {
        /// <summary>
        /// Ключ по которому будет сохраняться в SessionState текущая сцена запуска GetActiveScene().name
        /// Необходимо для того что бы после того как был совершен переход в Boot сцену помнить какую сцену открыть следующей
        /// </summary>
        public const string LevelDesignerPlayTest = nameof(LevelDesignerPlayTest);
    }
}