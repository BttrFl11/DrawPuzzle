using Core.Gameplay.Character;
using UnityEngine;

namespace Core.Gameplay.Drawing
{
    public class DrawerInfo
    {
        public CharacterDrawer Drawer { get; private set; }
        public Vector3[] DrawedPath { get; private set; }

        public DrawerInfo(CharacterDrawer drawer, Vector3[] drawedPath)
        {
            DrawedPath = drawedPath;
            Drawer = drawer;
        }
    }
}
