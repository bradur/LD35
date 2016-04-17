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

    [SerializeField]
    private List<Skill> skillList = new List<Skill>();

    [SerializeField]
    private RectTransform skillBar;

    private int skillSize = 50;
    private int skillMargin = 10;

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

    public List<Skill> GetSkills()
    {
        return skillList;
    }

    public void SetSkills(bool[] enabledSkills)
    {
        int tempX = -150;
        int barSize = skillMargin * 2;
        for (int i = 0; i < enabledSkills.Length; i += 1)
        {
            if (enabledSkills[i])
            {
                tempX += skillSize + skillMargin;
                barSize += skillSize + skillMargin;
                skillList[i].gameObject.SetActive(true);
                RectTransform rt = skillList[i].GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2(tempX, 0);
            }
            else
            {
                skillList[i].gameObject.SetActive(false);
            }
        }
        skillBar.sizeDelta = new Vector2(barSize, skillBar.sizeDelta.y);
    }

    public InfoPopup SpawnPopup(string title, string description, bool stopTheTime)
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
        return newPopup;
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
