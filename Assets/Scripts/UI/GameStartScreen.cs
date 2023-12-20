using System;

namespace Scripts
{
    public class GameStartScreen : Screen
    {
        public event Action StartButtonClicked;
        
        protected override void OnButtonClick() => 
            StartButtonClicked?.Invoke();
    }
}