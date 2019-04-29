using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;

public class MainMenuSwipeManager : MonoBehaviour
{
    public PanelOpener searchOpener;
    public PanelOpener featuredOpener;

    private bool restrictToSearch = false;
    private bool restrictToFeatured = false;

    private void Awake()
    {
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipe;
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipeRight;
        SwipeDetector.OnSwipe += SwipeDetector_OnSwipeLeft;
    }

    private void SwipeDetector_OnSwipe(SwipeData data)
    {
        Debug.Log("Swipe in Direction: " + data.Direction);
    }

    //open search tab OR close featured tab
    private void SwipeDetector_OnSwipeRight(SwipeData data)
    {
        if(data.Direction == SwipeDirection.Right && restrictToFeatured == false)
        {
            AnalyticsEvent.Custom("SearchPanelOpened", new Dictionary<string, object>
            {
            });
            restrictToFeatured = true;
            restrictToSearch = true;
            searchOpener.OpenPanel();
        }
        else if(data.Direction == SwipeDirection.Right && restrictToFeatured == true)
        {
            restrictToFeatured = false;
            featuredOpener.ClosePanel();
        }
    }

    //close search tab OR open featured tab
    private void SwipeDetector_OnSwipeLeft(SwipeData data)
    {
        if(data.Direction == SwipeDirection.Left && restrictToSearch == false)
        {
            AnalyticsEvent.Custom("FeaturedPanelOpened", new Dictionary<string, object>
            {
            });
            restrictToFeatured = true;
            featuredOpener.OpenPanel();
        }
        else if(data.Direction == SwipeDirection.Left && restrictToSearch == true)
        {
            restrictToSearch = false;
            searchOpener.ClosePanel();
        }
    }


    public void openOrCloseFeatured()
    {
        if (restrictToFeatured == true)
        {
            //onlySwipeRight = false;
            restrictToFeatured = false;
            featuredOpener.ClosePanel();
        }
        else if(restrictToSearch == false)
        {
            //onlySwipeRight = true;
            restrictToFeatured = true;
            featuredOpener.OpenPanel();
        }
    }
    public void openOrCloseSearch()
    {
        if (restrictToSearch == true)
        {
            //onlySwipeLeft = false;
            restrictToSearch = false;
            searchOpener.ClosePanel();
        }
        else if (restrictToFeatured == false)
        {
            //onlySwipeLeft = true; 
            restrictToSearch = true;
            searchOpener.OpenPanel();
        }
    }



}