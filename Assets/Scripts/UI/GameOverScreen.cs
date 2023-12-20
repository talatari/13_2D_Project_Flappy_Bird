using System;

namespace Scripts
{
    public class GameOverScreen : Screen
    {
        public event Action RestartButtonClicked;
        
        protected override void OnButtonClick() => 
            RestartButtonClicked?.Invoke();
    }
}