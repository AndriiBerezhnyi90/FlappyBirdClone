using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GameOverScreen : Screen, IPointerClickHandler
{
    public event UnityAction RestartButtonClick;

    public void OnPointerClick(PointerEventData eventData)
    {
        RestartButtonClick?.Invoke();
    }
}