using UnityEngine;
using Spriter2UnityDX;
using System.Linq;
using System;

public class CharactersManager : MonoBehaviour
{
    private readonly EntityRenderer[] _prefabs = new EntityRenderer[3];

    private readonly int[] _layersIds = new int[3];

    private void Start()
    {
        FillLayersIds();

        LoadPrefabs();

        SpawnUsersCharacters();
    }

    public void SpawnUsersCharacters()
    {
        if (_prefabs.All(x => x == null))
            throw new ArgumentNullException($"{nameof(_prefabs)} is empty");

        for (int i = 0; i < _prefabs.Length; i++)
            if (_prefabs[i] != null)
                SpawnCharacter(_prefabs[i], _layersIds[i]);
    }

    private void FillLayersIds()
    {
        _layersIds[0] = LayerId.Character.BackId;
        _layersIds[1] = LayerId.Character.MiddleId;
        _layersIds[2] = LayerId.Character.FrontId;
    }

    private void LoadPrefabs()
    {
        for (int i = 0; i < UserPreferences.ActiveDeck.Characters.Length; i++)
        {
            var collectibleCharacter = UserPreferences.ActiveDeck.Characters[i];

            if (collectibleCharacter != null)
                _prefabs[i] = Resources.Load<EntityRenderer>(collectibleCharacter.PrefabPath);
        }
    }

    private void SpawnCharacter(EntityRenderer prefab, int sortingLayerID)
    {
        // TODO - Setup coordinates
        var character = GameObject.Instantiate(prefab);
        character.SortingLayerID = sortingLayerID;
    }
}
