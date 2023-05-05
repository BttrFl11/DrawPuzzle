using UnityEngine;
using DG.Tweening;
using System;
using Core.Gameplay.Environment;

namespace Core.Gameplay.Character
{
    public class CharacterMovement : CharacterMonoBehaviour
    {
        private Tween _moveTween;
        private CharacterAnimator _characterAnimator;

        public static event Action OnCharacterCollide;
        public static event Action OnCharacterPathComplete;

        protected override void Awake()
        {
            _characterAnimator = Identity.GetCharacterComponent<CharacterAnimator>();
        }

        protected override void OnEnable()
        {
            OnCharacterCollide += StopMoving;
        }

        protected override void OnDisable()
        {
            OnCharacterCollide -= StopMoving;
        }

        public void MoveByPath(Vector3[] path)
        {
            _characterAnimator.SetMoving(true);

            _moveTween = transform.DOPath(path, Identity.Data.MoveDuration, PathType.Linear, PathMode.TopDown2D)
                .SetLink(gameObject)
                .OnComplete(OnPathComplete);
        }

        private void OnPathComplete()
        {
            OnCharacterPathComplete?.Invoke();

            StopMoving();
        }

        private void StopMoving()
        {
            _characterAnimator.SetMoving(false);

            if (_moveTween != null)
                _moveTween.Kill();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out Obstacle _))
            {
                OnCharacterCollide?.Invoke();
            }
        }
    }
}