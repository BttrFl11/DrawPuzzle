using UnityEngine;

namespace Core.Gameplay.Character
{
    public class CharacterAnimator : CharacterMonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string MOVING_PARAM = "IsMoving";

        public void SetMoving(bool moving)
        {
            _animator.SetBool(MOVING_PARAM, moving);
        }
    }
}