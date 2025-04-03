using TMPro;
using UnityEngine;

public class BuildingUIPresenter : MonoBehaviour
{
    [SerializeField] private TMP_Text _resourceLabel;
    [SerializeField] private ResourceProducer _producer;

    private void Start()
    {
        _producer.OnAmountUpdated += HandleAmountUpdated;
        UpdateUI(_producer.Amount);
    }

    private void OnDestroy()
    {
        if (_producer != null)
            _producer.OnAmountUpdated -= HandleAmountUpdated;
    }

    private void HandleAmountUpdated(int newAmount)
    {
        UpdateUI(newAmount);
    }

    private void UpdateUI(int amount)
    {
        _resourceLabel.text = $"{_producer.ResourceId}\n{amount}";
    }
}