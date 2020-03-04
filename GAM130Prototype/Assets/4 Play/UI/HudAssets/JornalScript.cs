using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JornalScript : MonoBehaviour
{

    public GameObject logBTN;
    public GameObject jornalCanvas;
    public GameObject hudCanvas;
    public Text LogTitle;
    public Text LogText;


    public List<JornalData> jornalDatas = new List<JornalData>();
    public Transform logButtonParent;

    void Awake()
    {
        jornalCanvas.SetActive(false);
        hudCanvas.SetActive(true);
        Cursor.visible = false;

        
    }

    [ContextMenu("Add Test Logs")]
    public void DebugAddLog()
    {        
        AddLog("test");
        AddLog("Log 1");
        AddLog("Log 2");
        AddLog("Log 3");
    }

    public void AddLog(string logName)
    {
       for (int i = 0; jornalDatas.Count > i; i++)
        {
            if (jornalDatas[i].logTitle == logName)
            {
                SetupButton(jornalDatas[i]);
            }
                    
        }
    }

    void SetupButton(JornalData data)
    {
        GameObject clone = Instantiate(logBTN, logButtonParent);
        clone.name = data.logTitle;
        clone.GetComponentInChildren<Text>().text = data.logTitle;

        Button logButton = clone.GetComponent<Button>();
        if(logButton != null)
        {
            logButton.onClick.AddListener(() => LogTitle.text = data.logTitle);
            logButton.onClick.AddListener(() => LogText.text = data.text);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("j"))
        {
            changeHudState();
        }
    }

    private void changeHudState()
    {
        if (jornalCanvas.activeInHierarchy == true)
        {
            jornalCanvas.SetActive(false);
            hudCanvas.SetActive(true);
            Cursor.visible = false;
        }
        else
        {
            jornalCanvas.SetActive(true);
            hudCanvas.SetActive(false);
            Cursor.visible = true;
        }
    }    
}
