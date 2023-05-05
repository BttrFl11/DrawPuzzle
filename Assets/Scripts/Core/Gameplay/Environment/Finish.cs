using UnityEngine;

namespace Core.Gameplay.Environment
{
    public class Finish : MonoBehaviour
    {
        [SerializeField] private int[] _indexes;

        private bool _isFree = true;

        public bool IsFree => _isFree;

        public bool Compare(int index)
        {
            foreach (int i in _indexes)
            {
                if(i == index) 
                    return true;
            }

            return false;
        }

        public void Reserve()
        {
            _isFree = false;
        }
    }
}