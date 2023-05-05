using Core.Gameplay.Drawing;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/CharacterData")]
public class CharacterDataSO : ScriptableObject
{
    [SerializeField] private int _index;
    [SerializeField] private float _minDistanceBtwLinePoints = 0.15f;
    [SerializeField] private float _moveDuration;
    [SerializeField] private Material _lineMaterial;
    [SerializeField] private DrawingLine _linePrefab;
    [SerializeField] private LayerMask _finishLayer;

    public float MinDistanceBtwLinePoints => _minDistanceBtwLinePoints;
    public Material LineMaterial => _lineMaterial;
    public DrawingLine LinePrefab => _linePrefab;
    public LayerMask FinishLayer => _finishLayer;
    public int Index => _index;
    public float MoveDuration => _moveDuration;
}