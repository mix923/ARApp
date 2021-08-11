using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class Target : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable distanceValue;

        private void Awake()
        {
            distanceValue.AddListener(SetDistance);
        }

        private void SetDistance(float distance)
        {
            transform.localPosition = new Vector3(10 + distance, 0, 0);
        }

        private void OnDestroy()
        {
            distanceValue.RemoveAll();
        }
    }
}