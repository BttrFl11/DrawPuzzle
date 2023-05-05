using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Character
{
    public class CharacterIdentity : CharacterMonoBehaviour
    {
        [SerializeField] private CharacterDataSO _data;
        public CharacterDataSO Data => _data;

        private List<CharacterMonoBehaviour> _behaviourList = new();

        protected override void Awake()
        {
            AddCharacterBehaviours();
        }

        private void AddCharacterBehaviours()
        {
            CharacterMonoBehaviour[] behaviours = GetComponents<CharacterMonoBehaviour>();
            _behaviourList.AddRange(behaviours);
        }

        public T GetCharacterComponent<T>() where T : CharacterMonoBehaviour
        {
            if (_behaviourList.Count == 0)
            {
                AddCharacterBehaviours();
            }

            foreach (var behaviour in _behaviourList)
            {
                if (behaviour is T beh)
                    return beh;
            }

            return null;
        }
    }
}