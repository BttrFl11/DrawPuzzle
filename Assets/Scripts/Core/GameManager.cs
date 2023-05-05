using UnityEngine;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameSettingsSO _settings;

        public GameSettingsSO Settings => _settings;

        private int _targetFrameRate = 60;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            FindObjectOfType<SceneLoader>().LoadNextScene();

            SetFPSLimit();
        }

        private void SetFPSLimit()
        {
            Application.targetFrameRate = _targetFrameRate;
        }
    }
}