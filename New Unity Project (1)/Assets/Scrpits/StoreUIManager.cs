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
    public bool isAction;

    public void Action(GameObject scanobj)
    {
        if (isAction) isAction = false;
        else if (!isAction)
        {
            scanobject = scanobj;
            NPC_DATA npc_Data = scanobject.GetComponent<NPC_DATA>();
            if (npc_Data.isSELLER == true) Display(npc_Data.id, npc_Data.isNPC);
            //display.SetBool("isDisplay", isAction);
        }
    }

    void Display(string id, bool isNPC)
    {
        Debug.Log(id);
        string objName = storeManager.GetStore(id, 0);
        Debug.Log(objName);
        string objDetail = storeManager.GetStore(id, 1);
        string objPrice = storeManager.GetStore(id, 2);
        Name.text = objName;
        Detail.text = objDetail;
        Price.text = objPrice;
    }
}