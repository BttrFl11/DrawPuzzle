using Core.State;
using System;
using UnityEngine;

namespace Core.Gameplay.State
{
    public class GameStateController : MonoBehaviour
    {
        private GameState _state;
        public GameState State => _state;

        public event Action<GameState> OnStateChanged;
        public event Action OnPaused;
        public event Action OnGameOver;
        public event Action OnFinished;
        public event Action OnPlaying;

        private void Start()
        {
            ChangeState(GameState.Playing);
        }

        public void ChangeState(GameState newState)
        {
            switch (newState)
            {
                case GameState.Playing:
                    OnPlaying?.Invoke();
                    break;
                case GameState.Paused:
                    OnPaused?.Invoke();
                    break;
                case GameState.Finished:
                    OnFinished?.Invoke();
                    break;
                case GameState.GameOver:
                    OnGameOver?.Invoke();
                    break;
            }

            OnStateChanged?.Invoke(newState);
            _state = newState;
        }
    }
}