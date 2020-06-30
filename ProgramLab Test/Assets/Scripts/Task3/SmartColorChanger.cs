using UnityEngine;
using UnityEngine.EventSystems;
using Assets.Scripts.Task2;
using System.Security.Cryptography;

namespace Assets.Scripts.Task3
{
    public class SmartColorChanger : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Material material;
        private Vector3 oldPosition;
        void Start()
        {

            material = GetComponent<Renderer>().material;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left && transform.position == oldPosition)
                ChangeColor();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                oldPosition = transform.position;
        }
        private void ChangeColor()
        {
            material.color = Random.ColorHSV();
        }
    }
}
