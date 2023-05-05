using System.Collections.Generic;
using UnityEngine;
using Core.Gameplay.Character;

public class CharacterList : MonoBehaviour
{
    public List<CharacterIdentity> Characters { get; private set; } = new();

    private void Awake()
    {
        Characters.AddRange(FindObjectsOfType<CharacterIdentity>());
    }
}