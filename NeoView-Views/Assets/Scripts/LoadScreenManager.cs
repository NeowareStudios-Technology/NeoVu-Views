using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenManager : MonoBehaviour
{
    public GameObject loadingPanel;

    public void SwitchLoadingPanel()
    {
        if(loadingPanel.active)
        {
            loadingPanel.SetActive(false);
        }
        else
        {
            loadingPanel.SetActive(true);
        }
    }
}
