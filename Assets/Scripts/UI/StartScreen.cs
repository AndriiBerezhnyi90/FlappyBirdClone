using UnityEngine.Events;
using UnityEngine.EventSystems;

public class StartScreen : Screen, IPointerClickHandler
{
    public event UnityAction StartButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartButtonClick?.Invoke();
    }
}