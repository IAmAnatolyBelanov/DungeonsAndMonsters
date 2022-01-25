using UnityEngine;
using Spriter2UnityDX;

public class CharactersManager : MonoBehaviour
{
    // TODO - getting prefabs from user's preferences
    [SerializeField]
    private EntityRenderer _prefabBack;
    [SerializeField]
    private EntityRenderer _prefabMiddle;
    [SerializeField]
    private EntityRenderer _prefabFront;

    private void Start()
    {
        SpawnUsersCharacters();
    }

    public void SpawnUsersCharacters()
    {
        SpawnCharacter(_prefabBack, LayerId.Character.BackId);
        SpawnCharacter(_prefabMiddle, LayerId.Character.MiddleId);
        SpawnCharacter(_prefabFront, LayerId.Character.FrontId);
    }

    private void SpawnCharacter(EntityRenderer prefab, int sortingLayerID)
    {
        // TODO - Setup coordinates
        var character = GameObject.Instantiate(prefab);
        character.SortingLayerID = sortingLayerID;
    }
}
