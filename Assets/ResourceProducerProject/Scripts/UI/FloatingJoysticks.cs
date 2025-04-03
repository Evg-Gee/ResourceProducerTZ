using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[DisallowMultipleComponent]
public class FloatingJoysticks : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform _background;
    [SerializeField] private RectTransform _handle;
    private Vector2 _input;

    public float Horizontal => _input.x;
    public float Vertical => _input.y;
    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos = eventData.position - (Vector2)_background.position;
        _input = Vector2.ClampMagnitude(pos / (_background.sizeDelta / 2), 1f);
        _handle.anchoredPosition = _input * (_background.sizeDelta / 2);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _input = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }
}