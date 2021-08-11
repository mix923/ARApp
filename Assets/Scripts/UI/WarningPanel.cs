using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningPanel : MonoBehaviour
{
    private void Awake()
    {
        TrackingManager.Instance.OnLostTracking += DisablePanel;
        TrackingManager.Instance.OnFoundTracking += EnablePanel;
    }

    private void DisablePanel()
    {
        gameObject.SetActive(false);
    }

    private void EnablePanel()
    {
        gameObject.SetActive(true);
    }
}
