// Date   : 16.04.2016 18:36
// Project: Game
// Author : bradur

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIManager : MonoBehaviour
{

    public static UIManager main;

    private Text txtComponent;
    private Color colorVariable;
    private Image imgComponent;

    [SerializeField]
    private GameObject popupPrefab;

    [SerializeField]
    private Transform infoPanelContainer;

    private List<InfoPopup> popupList = new List<InfoPopup>();

    void Awake()
    {
        main = this;
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void SpawnPopup(string title, string description, bool stopTheTime)
    {
        if (stopTheTime)
        {
            Time.timeScale = 0f;
        }
        GameObject newPopupObject = (GameObject)Instantiate(popupPrefab);
        newPopupObject.transform.parent = infoPanelContainer;
        InfoPopup newPopup = newPopupObject.GetComponent<InfoPopup>();
        newPopup.Init(title, description);
        popupList.Add(newPopup);
    }

    public void KillAllPopups()
    {
        for (int i = 0; i < popupList.Count; i += 1)
        {
            popupList[i].Kill();
        }
        popupList.Clear();
    }
}
