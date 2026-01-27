using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public RectTransform background;
    public RectTransform handle;

    public float moveRange = 100f;

    public Vector2 Direction { get; private set; }
    private Vector2 inputVector;

    // 터치 했을 때
    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    // 드래그 할 때
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, null, out pos))
        {
            inputVector = pos; // 위치 계산
            inputVector = Vector2.ClampMagnitude(inputVector, moveRange); // 이동 범위 제한
            handle.anchoredPosition = inputVector; // 핸들 이미지 이동
            Direction = inputVector / moveRange; // 노말라이즈 비슷한 개념
        }
    }

    // 터치 땔 때 
    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
        Direction = Vector2.zero;
    }
}   
