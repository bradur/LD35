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
    private List<GameObject> skillList = new List<GameObject>();

    [SerializeField]
    private RectTransform skillBar;

    [SerializeField]
    private GameObject skillBarParent;

    [SerializeField]
    private List<GameObject> mainMenuList = new List<GameObject>();

    private int skillSize = 50;
    private int skillMargin = 10;

    [SerializeField]
    private Skill dummySkill;

    [SerializeField]
    private GameObject titleDisplayPrefab;

    private TitleDisplay titleDisplay;

    void Awake()
    {
        main = this;
    }

    void Start()
    {
        if (!WorldManager.main.DebugMode) { 
            OpenMainMenu();
        }
    }

    public void OpenMainMenu()
    {
        HideSkillBar();
        foreach (GameObject popup in mainMenuList)
        {
            GameObject newPopup = (GameObject)Instantiate(popup, Vector3.zero, Quaternion.identity);
            newPopup.transform.SetParent(infoPanelContainer, false);
            popupList.Add(newPopup.GetComponent<InfoPopup>());
        }
    }

    public void ShowSkillBar()
    {
        skillBarParent.SetActive(true);
        skillBar.gameObject.SetActive(true);
    }

    public void HideSkillBar()
    {
        skillBarParent.SetActive(false);
        skillBar.gameObject.SetActive(false);
    }

    void Update()
    {

    }

    public List<GameObject> GetSkills()
    {
        return skillList;
    }

    public List<Skill> SetSkills(bool[] enabledSkills)
    {
        List<Skill> newSkills = new List<Skill>();
        foreach (Transform child in skillBarParent.transform)
        {
            Destroy(child.gameObject);
        }
        int tempX = -150;
        int barSize = skillMargin * 2;
        for (int i = 0; i < enabledSkills.Length; i += 1)
        {
            tempX += skillSize + skillMargin;
            barSize += skillSize + skillMargin;
            GameObject newSkillObject = (GameObject)Instantiate(skillList[i]);
            Skill newSkill = newSkillObject.GetComponent<Skill>();
            newSkill.SetEnabled(enabledSkills[i]);
            newSkill.transform.SetParent(skillBarParent.transform, false);
            newSkills.Add(newSkill);
            RectTransform rt = newSkill.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(tempX, 0);
        }
        skillBar.sizeDelta = new Vector2(barSize, skillBar.sizeDelta.y);
        return newSkills;
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

    public void SpawnTitle(string title)
    {
        GameObject titleDisplayObject = (GameObject)Instantiate(titleDisplayPrefab);
        titleDisplay = titleDisplayObject.GetComponent<TitleDisplay>();
        titleDisplay.transform.SetParent(infoPanelContainer, false);
        titleDisplay.Init(title);
    }

    public void KillAllPopups()
    {
        Time.timeScale = 1f;
        for (int i = 0; i < popupList.Count; i += 1)
        {
            popupList[i].Kill();
        }

        popupList.Clear();
    }
}
