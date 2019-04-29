using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScrollList : MonoBehaviour {

    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;
    


    // Use this for initialization
    void Start () 
    {
        //RefreshDisplay ();
    }

    void RefreshDisplay()
    {
        //RemoveButtons();
        //AddButton();
    }

    public void RemoveButtons()
    {
        while (contentPanel.childCount > 0) 
        {
            GameObject toRemove = transform.GetChild(0).gameObject;
            buttonObjectPool.ReturnObject(toRemove);
        }
    }

    public void AddButton(string viewName)
    {
        GameObject newButton = buttonObjectPool.GetObject();
        newButton.transform.SetParent(contentPanel);

        SelectViewButton selectViewButton = newButton.GetComponent<SelectViewButton>();
        selectViewButton.Setup(viewName, this);
    }
}
