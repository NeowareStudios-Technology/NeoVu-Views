using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectViewButton : MonoBehaviour
{
    public AWSManager awsm;
    public Button button;
    public TMP_Text viewName;
    public TMP_Text highlightedViewName;
    private ScrollList scrollList;

    // Start is called before the first frame update
    void Start()
    {
        awsm = GameObject.Find("AWS_Scripts").GetComponent<AWSManager>();
    }

    public void Setup(string currentViewName, ScrollList currentScrollList)
    {
        viewName.text = currentViewName;
        highlightedViewName.text = currentViewName;
        scrollList = currentScrollList;
    }

    public void StartAssetDownloads()
    {
        awsm.DowloadDataSet(viewName.text);
    }
    
}