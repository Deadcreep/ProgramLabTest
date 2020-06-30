using UnityEngine;
using UnityEngine.EventSystems;


namespace Assets.Scripts.Task2
{
    public class CursorFollower : MonoBehaviour, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                float distanceBetweenObjectAndCamera = transform.position.z - Camera.main.transform.position.z;
                var targetPosition = Input.mousePosition;
                targetPosition.z = distanceBetweenObjectAndCamera;
                transform.position = Camera.main.ScreenToWorldPoint(targetPosition);
            }
        }
    }
}