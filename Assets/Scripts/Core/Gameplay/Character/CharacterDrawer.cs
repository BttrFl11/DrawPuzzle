using Core.Gameplay.Drawing;
using Core.Gameplay.Environment;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Core.Gameplay.Character
{
    public class CharacterDrawer : CharacterMonoBehaviour, IPointerDownHandler
    {
        private Camera _camera;
        private DrawingLine _drawLine;
        private bool _isDrawing;
        private bool _drawed;

        private readonly Collider2D[] _finishResults = new Collider2D[1];

        public static event Action<DrawerInfo> OnPathDrawed;

        protected override void Awake()
        {
            _camera = Camera.main;
            _drawLine = Instantiate(Identity.Data.LinePrefab, Vector3.zero, Quaternion.identity);
            _drawLine.Init(Identity.Data.LineMaterial, Identity.Data.MinDistanceBtwLinePoints);
        }

        private void GetMousePosition(out Vector3 mousePosition)
        {
            mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        private void Update()
        {
            if (_isDrawing == false)
                return;

            GetMousePosition(out Vector3 mousePosition);
            SetStartPoint();

            if (Input.GetMouseButtonUp(0) && _drawed == false)
            {
                _isDrawing = false;

                if (CollidedFinish())
                {
                    Finish finish = _finishResults[0].GetComponent<Finish>();
                    if (IsValidFinish(finish))
                        OnDrawed();
                    else
                        _drawLine.Reset();
                }
                else
                {
                    _drawLine.Reset();
                }
            }

            void OnDrawed()
            {
                _drawed = true;

                OnPathDrawed?.Invoke(new DrawerInfo(this, _drawLine.GetPositions()));
            }
            void SetStartPoint()
            {
                _drawLine.SetPoint(mousePosition);
            }
            bool CollidedFinish()
            {
                return Physics2D.OverlapCircleNonAlloc(mousePosition, 0.1f, _finishResults, Identity.Data.FinishLayer) > 0;
            }
            bool IsValidFinish(Finish finish)
            {
                bool valid = finish != null && finish.Compare(Identity.Data.Index) && finish.IsFree;
                if (valid)
                    finish.Reserve();
                return valid;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (_drawed == false)
                _isDrawing = true;
        }
    }
}