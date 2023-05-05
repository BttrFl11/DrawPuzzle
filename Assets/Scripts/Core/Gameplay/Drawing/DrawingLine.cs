using System.Collections.Generic;
using UnityEngine;

namespace Core.Gameplay.Drawing
{
    [RequireComponent(typeof(LineRenderer))]
    public class DrawingLine : MonoBehaviour
    {
        private float _minDistanceBtwPoints;
        private LineRenderer _lineRenderer;

        public void Init(Material material, float minDistanceBtwPoints)
        {
            _lineRenderer.material = material;
            _minDistanceBtwPoints = minDistanceBtwPoints;
        }

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        public void SetPoint(Vector2 position)
        {
            if (CanSetPoint(position) == false)
                return;

            AddPosition(position);
        }

        public Vector3[] GetPositions()
        {
            List<Vector3> positions = new();
            for (int i = 0; i < _lineRenderer.positionCount; i++)
            {
                positions.Add(_lineRenderer.GetPosition(i));
            }

            return positions.ToArray();
        }

        public void Reset()
        {
            _lineRenderer.positionCount = 0;
        }

        private void AddPosition(Vector2 position)
        {
            _lineRenderer.positionCount++;
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, position);
        }

        private bool CanSetPoint(Vector2 position)
        {
            if (_lineRenderer.positionCount == 0)
                return true;

            Vector2 lastPointPosition = _lineRenderer.GetPosition(_lineRenderer.positionCount - 1);
            if (Vector2.Distance(position, lastPointPosition) > _minDistanceBtwPoints)
                return true;

            return false;
        }
    }
}