using Scripts.Input;
using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            RegisterInputService();
        }

        private static void RegisterInputService()
        {
            if (Application.isEditor)
                InputService = new MobileInputService();//StandaloneInputService();
            else
                InputService = new MobileInputService();
        }
    }
}
