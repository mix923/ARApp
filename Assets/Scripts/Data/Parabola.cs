using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInterFace;

namespace Data
{
    public class Parabola : MonoBehaviour
    {
        public List<Vector3> Points { get; private set; }
        public float TimeOfFlying { get; private set; }

        [SerializeField]
        private FloatVariable angleValue;
        [SerializeField]
        private FloatVariable speedValue;
        [SerializeField]
        private GameObject rootHelpPoints;
        [SerializeField]
        private Transform startPoint;
        [SerializeField]
        private List<Transform> helpPoints;

        private void Awake()
        {
            Points = new List<Vector3>();
            angleValue.AddListener(SetParable);
            speedValue.AddListener(SetParable);
        }

        private void Update()
        {
            if ((UserInterFaceManager.Instance.CurrentScreen == TypeScreen.AngleSpeed))
            {
                EnableHelpPoints();
            }
            else
            {
                DisableHelpPoints();
            }
        }

        private void GenerateParable()
        {
            Points.Clear();

            float startHeight = startPoint.localPosition.y;
            float angle = angleValue;
            float velocity = speedValue;

            float velocityDirectionX = velocity * Mathf.Cos(angle * Mathf.Deg2Rad);
            float velocityDirectionY = velocity * (Mathf.Sin(angle * Mathf.Deg2Rad));
            float gravity = -9.8f;

            TimeOfFlying = Mathf.Max((-velocityDirectionY + Mathf.Sqrt(Mathf.Pow(velocityDirectionY, 2f) - 4f * gravity * 0.5f * startHeight))
               / (2f * gravity * 0.5f), (-velocityDirectionY - Mathf.Sqrt(Mathf.Pow(velocityDirectionY, 2f) - 4f * gravity * 0.5f * startHeight))
               / (2f * gravity * 0.5f));

            Points.Add(new Vector3(0, startPoint.localPosition.y, 0));
            Vector3 cachedPoint = Vector3.zero;

            for (int index = 1; index < 50; index++)
            {
                float time = Points[index - 1].z + TimeOfFlying / 49;
                cachedPoint.x = time * velocityDirectionX;
                cachedPoint.y = (float)(startHeight + velocityDirectionY * time + 0.5f * gravity * Mathf.Pow(time, 2));
                cachedPoint.z = time;

                Points.Add(cachedPoint);
            }

            for (int index = 1; index < 50; index++)
            {
                cachedPoint = Points[index];
                cachedPoint.z = 0.0f;
                Points[index] = cachedPoint;
            }
        }

        private void SetHelpPoints()
        {
            Vector3 cachedPoint;

            for (int i = 0; i < helpPoints.Count; i++)
            {
                cachedPoint = Points[i * 2];
                helpPoints[i].localPosition = new Vector3(cachedPoint.x, cachedPoint.y, 0);
            }
        }

        private void DisableHelpPoints()
        {
            rootHelpPoints.gameObject.SetActive(false);
        }

        private void EnableHelpPoints()
        {
            rootHelpPoints.gameObject.SetActive(true);
        }

        private void SetParable(float value)
        {
            GenerateParable();
            SetHelpPoints();
        }

        private void OnDestroy()
        {
            angleValue.RemoveListener(SetParable);
            speedValue.RemoveListener(SetParable);
        }
    }
}
