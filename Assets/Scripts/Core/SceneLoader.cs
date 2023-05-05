using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Animator _crossfadeAnimator;
        [SerializeField] private float _transitionTime;
       
        public void LoadScene(int index)
        {
            StartCoroutine(Load(index));
        }

        public void LoadNextScene()
        {
            StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex + 1));
        }

        public void Restart()
        {
            StartCoroutine(Load(SceneManager.GetActiveScene().buildIndex));
        }

        private IEnumerator Load(int index)
        {
            _crossfadeAnimator.SetTrigger("Start");

            yield return new WaitForSeconds(_transitionTime);

            SceneManager.LoadScene(index);
        }
    }
}