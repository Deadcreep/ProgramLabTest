using UnityEngine;


namespace Assets.Scripts.Task4
{
    public class Publisher : MonoBehaviour
    {
        private Material material;

        void Start()
        {
            Observer.ObserverCall += ObserverCallHandler;
            material = GetComponent<Renderer>().material;
        }

        private void ObserverCallHandler()
        {
            material.color = Random.ColorHSV();
        }

        private void OnDestroy()
        {
            Observer.ObserverCall -= ObserverCallHandler;
        }
    }
}
