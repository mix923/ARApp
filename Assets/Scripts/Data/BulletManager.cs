using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ScriptableObjectArchitecture;
using Architecture;

namespace Data
{
    public class BulletManager : Singleton<BulletManager>
    {
        [SerializeField]
        [Range(1, 5)]
        private float timeScale;
        [SerializeField]
        private Parabola parabola;
        [SerializeField]
        private GameObject bulletPrefab;
        [SerializeField]
        private GameEventBase OnCompleteLevel;
        [SerializeField]
        private IntGameEvent OnHitTarget;

        [Header("MeasurementData")]
        [SerializeField]
        private Transform redPointLeft;
        [SerializeField]
        private Transform redPointRight;
        [SerializeField]
        private Transform yellowPointLeft;
        [SerializeField]
        private Transform yellowPointRight;
        [SerializeField]
        private Transform greenPointLeft;
        [SerializeField]
        private Transform greenPointRight;

        [Header("RewardData")]
        [SerializeField]
        [Range(50, 100)]
        private int greenPoint;
        [SerializeField]
        [Range(50, 30)]
        private int yellowPoint;
        [SerializeField]
        [Range(10, 30)]
        private int redPoint;

        private void CheckScoredPoints()
        {
            float xPosition = bulletPrefab.transform.localPosition.x;

            if (xPosition >= greenPointLeft.localPosition.x && xPosition <= greenPointRight.localPosition.x)
            {
                OnHitTarget?.Raise(greenPoint);
            }
            else if (xPosition >= yellowPointLeft.localPosition.x && xPosition <= yellowPointRight.localPosition.x)
            {
                OnHitTarget?.Raise(yellowPoint);
            }
            else if (xPosition >= redPointLeft.localPosition.x && xPosition <= redPointRight.localPosition.x)
            {
                OnHitTarget?.Raise(redPoint);
            }
        }

        public void ShootBullet()
        {
            bulletPrefab.GetComponent<MeshRenderer>().enabled = true;
            bulletPrefab.transform.DOLocalPath(parabola.Points.ToArray(), parabola.TimeOfFlying * timeScale).SetEase(Ease.OutCubic).OnComplete(() =>
            {
                CheckScoredPoints();
                OnCompleteLevel?.Raise();
            });
        }

        public void ResetBullet()
        {
            bulletPrefab.transform.localPosition = Vector3.zero;
            bulletPrefab.GetComponent<MeshRenderer>().enabled = false;
        }

    }
}
