using UnityEngine;
using Spriter2UnityDX;
using System.Linq;
using System;

public class CharactersManager : MonoBehaviour
{
    private readonly ICollectibleCharacter[] _collectibleCharacters = new ICollectibleCharacter[3];

    private readonly int[] _layersIds = new int[3];

    private void Start()
    {
        FillLayersIds();

        LoadPrefabs();

        SpawnUsersCharacters();
    }

    public void SpawnUsersCharacters()
    {
        if (_collectibleCharacters.All(x => x == null))
            throw new ArgumentNullException($"{nameof(_collectibleCharacters)} is empty");

        for (int i = 0; i < _collectibleCharacters.Length; i++)
            if (_collectibleCharacters[i] != null)
                SpawnCharacter(_collectibleCharacters[i], _layersIds[i]);
    }

    private void FillLayersIds()
    {
        _layersIds[0] = LayerId.Character.BackId;
        _layersIds[1] = LayerId.Character.MiddleId;
        _layersIds[2] = LayerId.Character.FrontId;
    }

    private void LoadPrefabs()
    {
        var collectibleCharacters = UserPreferences.ActiveDeck.Characters;

        for (int i = 0; i < collectibleCharacters.Length; i++)
            if (collectibleCharacters[i] != null)
                _collectibleCharacters[i] = collectibleCharacters[i];
    }

    private void SpawnCharacter(ICollectibleCharacter collectibleCharacter, int sortingLayerID)
    {
        // TODO - Setup coordinates
        var prefab = Resources.Load<EntityRenderer>(collectibleCharacter.PrefabPath);
        var character = GameObject.Instantiate(prefab);
        character.SortingLayerID = sortingLayerID;

        var userCharacter = character.gameObject.GetComponent<UserCharacter>();
        userCharacter.Initialize(collectibleCharacter);
    }
}
