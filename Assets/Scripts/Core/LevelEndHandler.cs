using Core.Gameplay.Character;
using Core.Gameplay.State;
using Core.State;
using UnityEngine;

namespace Core
{
    public class LevelEndHandler : MonoBehaviour
    {
        private GameStateController _stateController;

        private void Awake()
        {
            _stateController = FindObjectOfType<GameStateController>();
        }

        private void OnEnable()
        {
            CharacterMovement.OnCharacterCollide += OnGameOver;
            CharacterMovement.OnCharacterPathComplete += OnFinished;
        }

        private void OnDisable()
        {
            CharacterMovement.OnCharacterCollide -= OnGameOver;
            CharacterMovement.OnCharacterPathComplete -= OnFinished;
        }

        private void OnGameOver()
        {
            if (_stateController.State == GameState.GameOver ||
                _stateController.State == GameState.Finished)
                return;

            _stateController.ChangeState(GameState.GameOver);
        }

        private void OnFinished()
        {
            if (_stateController.State == GameState.GameOver ||
                _stateController.State == GameState.Finished)
                return;

            _stateController.ChangeState(GameState.Finished);
        }
    }
}