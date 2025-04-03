using TMPro;
using UnityEngine;
using System.Collections;
using DG.Tweening;

public class PopupPresenter : MonoBehaviour
{
    [SerializeField] private GameObject _popupPanel;
    [SerializeField] private TMP_Text _resourceText;
    [SerializeField] private float _showDuration = 2f;
    [SerializeField] private float _animationDuration = 0.5f;
    [SerializeField] private Vector2 _hiddenPosition = new Vector2(-200f, 100f);
    [SerializeField] private Vector2 _visiblePosition = new Vector2(-500f, 350f);

    private RectTransform _rectTransform;
    private Sequence _animationSequence;

    private void Awake()
    {
        _rectTransform = _popupPanel.GetComponent<RectTransform>();
        _rectTransform.anchoredPosition = _hiddenPosition;
        _popupPanel.SetActive(false);
    }

    public void ShowPopup(string resourceId, int amount, int total)
    {
        _animationSequence?.Kill();
        _popupPanel.SetActive(true);

        _resourceText.text = $"{resourceId} + {amount} \ntotal: {total} ";
        
        _animationSequence = DOTween.Sequence()
            .Append(_rectTransform.DOAnchorPos(_visiblePosition, _animationDuration)
            .SetEase(Ease.OutBack))
            .AppendInterval(_showDuration)
            .Append(_rectTransform.DOAnchorPos(_hiddenPosition, _animationDuration)
            .SetEase(Ease.InBack))
            .Play()
            .OnComplete(() => 
            {
                _popupPanel.SetActive(false);
                _animationSequence = null;
            });
    }

    private void OnDestroy()
    {
        _animationSequence?.Kill();
    }
}