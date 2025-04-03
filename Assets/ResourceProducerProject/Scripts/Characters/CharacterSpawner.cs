using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private PopupPresenter _popupPresenter;
    private IResourceManager _resourceManager;

    private void Start()
    {
        _resourceManager = FindFirstObjectByType<ResourceManager>();
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
         GameObject character = Instantiate(_characterPrefab, _spawnPoint.position, Quaternion.identity);
        var interaction = character.GetComponent<CharacterInteraction>();
        if (interaction != null)
        {
            interaction.Initialize(_resourceManager, _popupPresenter);
        }
    }
}
