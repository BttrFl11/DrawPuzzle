using Core;
using Core.Gameplay.State;
using UnityEngine;

namespace GUI
{
    public class EndGameUIPanel : MonoBehaviour
    {
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private GameObject _finishPanel;

        private GameStateController _stateController;

        private void Awake()
        {
            _stateController = FindObjectOfType<GameStateController>();

            _gameOverPanel.SetActive(false);
            _finishPanel.SetActive(false);
        }

        private void OnEnable()
        {
            _stateController.OnFinished += ShowFinishPanel;
            _stateController.OnGameOver += ShowGameOverPanel;
        }

        private void OnDisable()
        {
            _stateController.OnFinished -= ShowFinishPanel;
            _stateController.OnGameOver -= ShowGameOverPanel;
        }

        private void ShowFinishPanel()
        {
            _finishPanel.SetActive(true);
        }

        private void ShowGameOverPanel()
        {
            _gameOverPanel.SetActive(true);
        }
    }
}