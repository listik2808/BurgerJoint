using UnityEngine;

namespace Scripts.Infrastructure
{
    public class Bootstrapper : MonoBehaviour 
    {
        public Game _game;

        private void Awake()
        {
            _game = new Game();

            DontDestroyOnLoad(this);
        }
    }
}
