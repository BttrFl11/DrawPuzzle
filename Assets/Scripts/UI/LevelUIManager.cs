using Core;
using UnityEngine;

namespace UI
{
    public class LevelUIManager : MonoBehaviour
    {
        private SceneLoader _sceneLoader;

        private void Awake()
        {
            _sceneLoader = FindObjectOfType<SceneLoader>();
        }

        public void Restart()
        {
            _sceneLoader.Restart();
        }

        public void LoadMenu()
        {
            _sceneLoader.LoadScene(GameConst.MENU_BUILD_INDEX);
        }

        public void NextLevel()
        {
            _sceneLoader.LoadNextScene();
        }
    }
}