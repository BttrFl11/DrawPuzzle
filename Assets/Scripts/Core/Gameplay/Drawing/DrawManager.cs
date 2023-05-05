using Core.Gameplay.Character;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Drawing
{
    public class DrawManager : MonoBehaviour
    {
        private CharacterList _characterList;
        private List<DrawerInfo> _drawersInfoList = new();

        private void Awake()
        {
            _characterList = FindObjectOfType<CharacterList>();
        }

        private void OnEnable()
        {
            CharacterDrawer.OnPathDrawed += OnLineDrawed;
        }

        private void OnDisable()
        {
            CharacterDrawer.OnPathDrawed -= OnLineDrawed;
        }

        private void InvokeCharactersMove()
        {
            foreach (var drawerInfo in _drawersInfoList)
            {
                CharacterMovement movement = drawerInfo.Drawer.GetComponent<CharacterMovement>();
                movement.MoveByPath(drawerInfo.DrawedPath);
            }
        }

        private void OnLineDrawed(DrawerInfo drawerInfo)
        {
            _drawersInfoList.Add(drawerInfo);

            if (_drawersInfoList.Count != _characterList.Characters.Count)
                return;

            // if all characters has drawed the path

            InvokeCharactersMove();
        }
    }
}