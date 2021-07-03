using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUIManager : MonoBehaviour
{
    public StoreManager storeManager;
    public Image objimg;
    public Text Name;
    public Text Detail;
    public Text Price;
    //public Animator display;
    public GameObject scanobject;
    public GameObject storePanel;
    public GameObject storePart;
    public GameObject upgradePart;
    public bool isAction;
    public Button btExit;
    public Button btStore;
    public Button btUpgrade;

    void Start()
    {
        btExit.onClick.AddListener(ExitWindow);
        btStore.onClick.AddListener(OpenStore);
        btUpgrade.onClick.AddListener(OpenUpgrade);
    }

    public void ExitWindow()
    {
        isAction = false;
        storePanel.SetActive(isAction);
    }

    public void OpenStore()
    {
        storePart.SetActive(true);
        upgradePart.SetActive(false);
    }

    public void OpenUpgrade()
    {
        upgradePart.SetActive(true);
        storePart.SetActive(false);
    }

    public void Action(GameObject scanobj)
    {
        if (isAction) isAction = false;
        else 
        {
            isAction = true;
            scanobject = scanobj;
            NPC_DATA npc_Data = scanobject.GetComponent<NPC_DATA>();
            if (npc_Data.isSELLER == true) Display(npc_Data.id, npc_Data.isNPC);
            //display.SetBool("isDisplay", isAction);
        }
        storePanel.SetActive(isAction);
    }

    void Display(string id, bool isNPC)
    {
        /*
        string objName = storeManager.GetStore(id, 0);
        string objDetail = storeManager.GetStore(id, 1);
        string objPrice = storeManager.GetStore(id, 2);
        Name.text = objName;
        Detail.text = objDetail;
        Price.text = objPrice;
        */
    }
}
