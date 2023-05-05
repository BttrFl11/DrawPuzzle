using UnityEngine;

namespace Core.Gameplay.Character
{
    public abstract class CharacterMonoBehaviour : MonoBehaviour
    {
        private CharacterIdentity _identity;
        public CharacterIdentity Identity
        {
            get
            {
                if (_identity != null)
                    return _identity;

                return _identity = GetComponent<CharacterIdentity>();
            }
        }

        protected virtual void Awake() { }
        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        protected virtual void Start() { }
    }
}