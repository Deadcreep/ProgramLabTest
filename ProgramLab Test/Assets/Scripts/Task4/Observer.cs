using System;
using System.Collections;
using UnityEngine;


namespace Assets.Scripts.Task4
{
    public class Observer : MonoBehaviour
    {
        public static event Action ObserverCall;
        private Publisher[] publishers;
        private Material material;
        private static Observer _instance;

        private void Awake()
        {
            if (_instance == null)
                _instance = this;
            else
                Destroy(this);
        }

        private void Start()
        {
            publishers = Resources.FindObjectsOfTypeAll<Publisher>();
            material = GetComponent<Renderer>().material;
            StartCoroutine(ChangeColor());
        }

        private IEnumerator ChangeColor()
        {
            while (true)
            {
                material.color = UnityEngine.Random.ColorHSV();
                ObserverCall.Invoke();
                yield return new WaitForSeconds(1);
            }
        }

        private void OnDestroy()
        {
            StopAllCoroutines();
        }
    }
}
