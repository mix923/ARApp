using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

namespace Data
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField]
        private CannonType cannonType;
        [SerializeField]
        private CannonTypeVariable currentSelectedCannon;
        [SerializeField]
        private FloatVariable angleValue;
        [SerializeField]
        private Transform rootAngle;
        [SerializeField]
        private GameObject rootModel;

        private void OnEnable()
        {
            angleValue.AddListener(SetAngle);
            currentSelectedCannon.AddListener(ActivateCannon);
        }

        private void SetAngle(float value)
        {
            rootAngle.localEulerAngles = new Vector3(0, value, 0);
        }

        private void ActivateCannon(CannonType selectedCannon)
        {
            if (cannonType.Equals(selectedCannon))
            {
                rootModel.SetActive(true);
            }
            else
            {
                rootModel.SetActive(false);
            }
        }

        private void OnDisable()
        {
            angleValue.RemoveListener(SetAngle);
            currentSelectedCannon.RemoveListener(ActivateCannon);
        }
    }
}

public enum CannonType
{
    Normal,
    Ultra,
    Special
}