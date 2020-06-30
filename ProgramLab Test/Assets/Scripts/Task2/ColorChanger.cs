using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Task2
{
    public class ColorChanger : MonoBehaviour
    {
        private Material material;
        private Vector3 oldPosition;

        void Start()
        {
            material = GetComponent<Renderer>().material;
        }

        private void OnMouseDown()
        {
            oldPosition = transform.position;
        }

        private void OnMouseUp()
        {
            if (transform.position == oldPosition)
                ChangeColor();
        }

        private void ChangeColor()
        {
            material.color = Random.ColorHSV();
        }
    }
}
