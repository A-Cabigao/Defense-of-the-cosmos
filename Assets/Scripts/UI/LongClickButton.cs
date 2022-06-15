using UnityEngine;
using UnityEngine.EventSystems;

public class LongClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    CameraMove cameraMove;
    [SerializeField]
    int direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        cameraMove.Direction = direction;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cameraMove.Direction = 0;
    }
}
