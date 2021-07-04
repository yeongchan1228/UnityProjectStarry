using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreUIManager : MonoBehaviour
{
    public StoreManager storeManager;
    public Image objimg;
    //public Animator display;
    public GameObject scanobject;
    public GameObject storePanel;
    public GameObject storePart;
    public GameObject upgradePart;
    public GameObject salePart;
    public bool isAction;
    //bool isfrist;
    public Button btExit;
    public Button btStore;
    GameObject PlayerUI;
    public Button btUpgrade;
    public Scrollbar scrollbar;
    public GameObject obj;
    public GameObject Delete_obj, noSale_obj;
    public InputField input;
    string select_delete_item;
    int save_i, save_j;
    Transform Parent;
    UserInfo userInfo;
    GameObject user_man, user_woman;
    int sale_count;
    public Sprite[] fruit_afters;
    private Sprite[] fishes1, fishes2, fishes3, fishes4, fishes5, fishes6, fishes7, fishes8, fishes9, fishes10;

    void Start()
    {
        btExit.onClick.AddListener(ExitWindow);
        btStore.onClick.AddListener(OpenStore);
        btUpgrade.onClick.AddListener(OpenUpgrade);
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        fishes1 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�1"); // 1����
        fishes2 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�2"); // 2����
        fishes3 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�3"); // 2����
        fishes4 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�4"); // 2����
        fishes5 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�5"); // 2����
        fishes6 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�6"); // 2����
        fishes7 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�7"); // 4����
        fishes8 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�8"); // 2����
        fishes9 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�9"); // 2����
        fishes10 = Resources.LoadAll<Sprite>("Sprites/fish/���̵�10"); // 1����
        PlayerUI = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
        UserInfo userinfo2 = user_man.GetComponent<UserInfo>();
        if (userinfo2.isTrue)
        {
            userInfo = user_man.GetComponent<UserInfo>();
        }
        else
        {
            userInfo = user_woman.GetComponent<UserInfo>();
        }
        Parent = salePart.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<Transform>();
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
        salePart.SetActive(false);
    }

    public void OpenUpgrade()
    {
        upgradePart.SetActive(true);
        storePart.SetActive(false);
        salePart.SetActive(false);

    }
    public void OpenSale()
    {
        scrollbar.size = 1f;
        save_i = 0;
        save_j = 0;
        upgradePart.SetActive(false);
        storePart.SetActive(false);
        salePart.SetActive(true);
        /*if (!isfrist)
        {
            userInfo.FruitItemkey.Add("Blueberry");
            userInfo.FruitItem.Add("Blueberry", 1);
            userInfo.FruitItemkey.Add("DARK");
            userInfo.FruitItem.Add("DARK", 1);
            userInfo.FruitItemkey.Add("lemon1");
            userInfo.FruitItem.Add("lemon1", 1);
            userInfo.FishItemkey.Add("�Ǹ������");
            userInfo.FishItem.Add("�Ǹ������", 1);
            userInfo.FishItemkey.Add("õ�繰���");
            userInfo.FishItem.Add("õ�繰���", 1);
            isfrist = true;
        }*/
        GameObject Child;
        for(int i = 0, j = 0; i < userInfo.FruitItemkey.Count; i++,j++)
        {
            Child = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            Child.SetActive(true);
            Child.name = userInfo.FruitItemkey[i];
            Child.transform.SetParent(Parent);
            Text Name = Child.transform.GetChild(0).GetComponent<Text>();
            Text Price = Child.transform.GetChild(2).GetComponent<Text>();
            Text Detail = Child.transform.GetChild(1).GetComponent<Text>();
            Image image = Child.transform.GetChild(3).GetComponent<Image>();
            Button button = Child.transform.GetChild(5).GetComponent<Button>();
            button.onClick.AddListener(On_Sale_Item);
            RectTransform childtrans = Child.GetComponent<RectTransform>();
            childtrans.anchoredPosition = new Vector2(264.8705f, -63.0913f * (i+1+j));
            childtrans.sizeDelta = new Vector2(529.741f, 126.1826f);
            if (userInfo.FruitItemkey[i].Equals("Blueberry")) { Name.text = "��纣��"; Price.text = "520G"; Detail.text = "���� ������ ��� ��纣���̴�."; image.sprite = fruit_afters[0]; }
            else if (userInfo.FruitItemkey[i].Equals("carrot")) { Name.text = "���"; Price.text = "110G"; Detail.text = "�̽��� ����̴�."; image.sprite = fruit_afters[1]; }
            else if (userInfo.FruitItemkey[i].Equals("DARK")) { Name.text = "�Ǹ��� ����"; Price.text = "2,666G"; Detail.text = "������ ū���� �� �� ���� �����̴�."; image.sprite = fruit_afters[2]; }
            else if (userInfo.FruitItemkey[i].Equals("dhrtntn1")) { Name.text = "������"; Price.text = "290G"; Detail.text = "������ �������̴�."; image.sprite = fruit_afters[3]; }
            else if (userInfo.FruitItemkey[i].Equals("dkqhzkeh1")) { Name.text = "�ƺ�ī��"; Price.text = "570G"; Detail.text = "�ε巯�� �ƺ�ī���̴�."; image.sprite = fruit_afters[4]; }
            else if (userInfo.FruitItemkey[i].Equals("Grape")) { Name.text = "����"; Price.text = "280G"; Detail.text = "���ִ� �����̴�."; image.sprite = fruit_afters[5]; }
            else if (userInfo.FruitItemkey[i].Equals("lemon1")) { Name.text = "����"; Price.text = "800G"; Detail.text = "������ �����̴�."; image.sprite = fruit_afters[6]; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { Name.text = "õ���� ����"; Price.text = "2,777G"; Detail.text = "�ż��� ���� �������� �����̴�."; image.sprite = fruit_afters[7]; }
            else if (userInfo.FruitItemkey[i].Equals("melon")) { Name.text = "���"; Price.text = "600G"; Detail.text = "�޴��� �����̴�."; image.sprite = fruit_afters[8]; }
            else if (userInfo.FruitItemkey[i].Equals("mil1")) { Name.text = "��"; Price.text = "50G"; Detail.text = "���̴�."; image.sprite = fruit_afters[9]; }
            else if (userInfo.FruitItemkey[i].Equals("pineapple1")) { Name.text = "���ξ���"; Price.text = "1,000G"; Detail.text = "��ŭ�� ���ξ����̴�."; image.sprite = fruit_afters[10]; }
            else if (userInfo.FruitItemkey[i].Equals("Potato")) { Name.text = "����"; Price.text = "195G"; Detail.text = "�����̴�."; image.sprite = fruit_afters[11]; }
            else if (userInfo.FruitItemkey[i].Equals("Pumpkin")) { Name.text = "ȣ��"; Price.text = "740G"; Detail.text = "���� ���� ȣ���̴�."; image.sprite = fruit_afters[12]; }
            else if (userInfo.FruitItemkey[i].Equals("rkwl1")) { Name.text = "����"; Price.text = "480G"; Detail.text = "���� ���� ���� �����̴�."; image.sprite = fruit_afters[13]; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { Name.text = "����"; Price.text = "3,939G"; Detail.text = "������ ū���� �� �� ���� �����̴�."; image.sprite = fruit_afters[14]; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { Name.text = "����"; Price.text = "770G"; Detail.text = "���¸����� ����� ����ִ� �����̴�."; image.sprite = fruit_afters[15]; }
            else if (userInfo.FruitItemkey[i].Equals("tnsan1")) { Name.text = "����"; Price.text = "390G"; Detail.text = "�̽��� �����̴�."; image.sprite = fruit_afters[16]; }
            else if (userInfo.FruitItemkey[i].Equals("Tomato")) { Name.text = "�丶��"; Price.text = "450G"; Detail.text = "�̽��� �丶���̴�."; image.sprite = fruit_afters[17]; }
            else if (userInfo.FruitItemkey[i].Equals("watermelon")) { Name.text = "����"; Price.text = "1,200G"; Detail.text = "���� �ÿ��� �����̴�."; image.sprite = fruit_afters[18]; }
            save_i = i;
            save_j = j;
            if(save_i+save_j > 3)
            {
                scrollbar.size -= 0.05f;
            }
        }
        save_i++;
        save_j++;
        for(int i = 0; i<userInfo.FishItemkey.Count; i++, save_i++, save_j++)
        {
            Child = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            Child.SetActive(true);
            Child.name = userInfo.FruitItemkey[i];
            Child.transform.SetParent(Parent);
            Text Name = Child.transform.GetChild(0).GetComponent<Text>();
            Text Price = Child.transform.GetChild(2).GetComponent<Text>();
            Text Detail = Child.transform.GetChild(1).GetComponent<Text>();
            Image image = Child.transform.GetChild(3).GetComponent<Image>();
            Button button = Child.transform.GetChild(5).GetComponent<Button>();
            RectTransform childtrans = Child.GetComponent<RectTransform>();
            button.onClick.AddListener(On_Sale_Item);
            childtrans.anchoredPosition = new Vector2(264.8705f, -63.0913f * (save_i + 1 + save_j));
            childtrans.sizeDelta = new Vector2(529.741f, 126.1826f);
            if (userInfo.FishItemkey[i].Equals("����ѹ����")) { Name.text = "����� �����"; Price.text = "250G"; Detail.text = "����������"; image.sprite = fishes1[0]; }
            else if (userInfo.FishItemkey[i].Equals("���������")) { Name.text = "���� �����"; Price.text = "300G"; Detail.text = "����������"; image.sprite = fishes2[0]; }
            else if (userInfo.FishItemkey[i].Equals("��Ȳ�����")) { Name.text = "��Ȳ �����"; Price.text = "300G"; Detail.text = "����������"; image.sprite = fishes2[1]; }
            else if (userInfo.FishItemkey[i].Equals("��������")) { Name.text = "��� �����"; Price.text = "400G"; Detail.text = "����������"; image.sprite = fishes3[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ʷϹ����")) { Name.text = "�ʷ� �����"; Price.text = "400G"; Detail.text = "����������"; image.sprite = fishes3[1]; }
            else if (userInfo.FishItemkey[i].Equals("���������")) { Name.text = "���� �����"; Price.text = "550G"; Detail.text = "����������"; image.sprite = fishes4[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ϴû������")) { Name.text = "�ϴû� �����"; Price.text = "550G"; Detail.text = "����������"; image.sprite = fishes4[1]; }
            else if (userInfo.FishItemkey[i].Equals("���󹰰��")) { Name.text = "���� �����"; Price.text = "550G"; Detail.text = "����������"; image.sprite = fishes5[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ǻ繰���")) { Name.text = "�ǻ� �����"; Price.text = "800G"; Detail.text = "����������"; image.sprite = fishes5[1]; }
            else if (userInfo.FishItemkey[i].Equals("��ι����")) { Name.text = "��� �����"; Price.text = "800G"; Detail.text = "����������"; image.sprite = fishes6[0]; }
            else if (userInfo.FishItemkey[i].Equals("�����������")) { Name.text = "������ �����"; Price.text = "1,500G"; Detail.text = "����������"; image.sprite = fishes6[1]; }
            else if (userInfo.FishItemkey[i].Equals("���ֹ����")) { Name.text = "���� �����"; Price.text = "3,000G"; Detail.text = "����������"; image.sprite = fishes7[0]; }
            else if (userInfo.FishItemkey[i].Equals("���ι����")) { Name.text = "���� �����"; Price.text = "3,000G"; Detail.text = "����������"; image.sprite = fishes7[1]; }
            else if (userInfo.FishItemkey[i].Equals("�źι����")) { Name.text = "�ź� �����"; Price.text = "3,000G"; Detail.text = "����������"; image.sprite = fishes7[2]; }
            else if (userInfo.FishItemkey[i].Equals("�Ż繰���")) { Name.text = "�Ż� �����"; Price.text = "3,000G"; Detail.text = "����������"; image.sprite = fishes7[3]; }
            else if (userInfo.FishItemkey[i].Equals("�Ǹ������")) { Name.text = "�Ǹ� �����"; Price.text = "5,000G"; Detail.text = "����������"; image.sprite = fishes8[0]; }
            else if (userInfo.FishItemkey[i].Equals("õ�繰���")) { Name.text = "õ�� �����"; Price.text = "5,000G"; Detail.text = "����������"; image.sprite = fishes8[1]; }
            else if (userInfo.FishItemkey[i].Equals("���¸��ʹ����")) { Name.text = "���¸��� �����"; Price.text = "7,000G"; Detail.text = "����������"; image.sprite = fishes9[1]; }
            else if (userInfo.FishItemkey[i].Equals("����������")) { Name.text = "����� �����"; Price.text = "7,000G"; Detail.text = "����������"; image.sprite = fishes9[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ҸӴ��ǻ�������")) { Name.text = "�ҸӴ��ǻ�� �����"; Price.text = "100,000G"; Detail.text = "����������"; image.sprite = fishes10[0]; }
        }
        if (save_i + save_j > 3)
        {
            scrollbar.size -= 0.05f;
        }
        save_i = 0; save_j = 0;
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

    public void On_Sale_Item()
    {
        sale_count = 0;
        input.text = "0";
        Delete_obj.SetActive(true);
        GameObject Delete_Button = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Text select_delete = Delete_Button.transform.GetChild(0).GetComponent<Text>();
        select_delete_item = select_delete.text;
        Delete_obj.SetActive(true);
    }

    public void Delete_Okay()
    {
        Debug.LogError(select_delete_item);
        if (select_delete_item.Equals("��纣��")) { Delete_Item_Fruit("Blueberry", 520); }
        else if (select_delete_item.Equals("���")) { Delete_Item_Fruit("carrot", 110); }
        else if (select_delete_item.Equals("�Ǹ��� ����")) { Delete_Item_Fruit("DARK", 2666); }
        else if (select_delete_item.Equals("������")) { Delete_Item_Fruit("dhrtntn1", 290); }
        else if (select_delete_item.Equals("�ƺ�ī��")) { Delete_Item_Fruit("dkqhzkeh1", 570); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("Grape", 280); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("lemon1", 800); }
        else if (select_delete_item.Equals("õ���� ����")) { Delete_Item_Fruit("LIGHT",2777); }
        else if (select_delete_item.Equals("���")) { Delete_Item_Fruit("melon",600); }
        else if (select_delete_item.Equals("��")) { Delete_Item_Fruit("mil1",50); }
        else if (select_delete_item.Equals("���ξ���")) { Delete_Item_Fruit("pineapple1",1000); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("Potato",195); }
        else if (select_delete_item.Equals("ȣ��")) { Delete_Item_Fruit("Pumpkin",740); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("rkwl1",480); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("starry",3939); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("Strawberry",770); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("tnsan1",390); }
        else if (select_delete_item.Equals("�丶��")) { Delete_Item_Fruit("Tomato",450); }
        else if (select_delete_item.Equals("����")) { Delete_Item_Fruit("watermelon",1200); }

       if (select_delete_item.Equals("����� �����")) { Delete_Item_Fish("����ѹ����", 50); }
        else if (select_delete_item.Equals("���� �����")) { Delete_Item_Fish("���������", 130); }
        else if (select_delete_item.Equals("��Ȳ �����")) { Delete_Item_Fish("��Ȳ�����", 150); }
        else if (select_delete_item.Equals("��� �����")) { Delete_Item_Fish("��������", 200); }
        else if (select_delete_item.Equals("�ʷ� �����")) { Delete_Item_Fish("�ʷϹ����", 230); }
        else if (select_delete_item.Equals("���� �����")) { Delete_Item_Fish("���������", 300); }
        else if (select_delete_item.Equals("�ϴû� �����")) { Delete_Item_Fish("�ϴû������", 250); }
        else if (select_delete_item.Equals("���� �����")) { Delete_Item_Fish("���󹰰��", 320); }
        else if (select_delete_item.Equals("�ǻ� �����")) { Delete_Item_Fish("�ǻ繰���", 450); }
        else if (select_delete_item.Equals("��� �����")) { Delete_Item_Fish("��ι����", 530); }
        else if (select_delete_item.Equals("������ �����")) { Delete_Item_Fish("�����������", 620); }
        else if (select_delete_item.Equals("���� �����")) { Delete_Item_Fish("���ֹ����",800); }
        else if (select_delete_item.Equals("���� �����")) { Delete_Item_Fish("���ι����", 750); }
        else if (select_delete_item.Equals("�ź� �����")) { Delete_Item_Fish("�źι����", 1234); }
        else if (select_delete_item.Equals("�Ż� �����")) { Delete_Item_Fish("�Ż繰���", 1234); }
        else if (select_delete_item.Equals("�Ǹ� �����")) { Delete_Item_Fish("�Ǹ������", 2666); }
        else if (select_delete_item.Equals("õ�� �����")) { Delete_Item_Fish("õ�繰���", 2777); }
        else if (select_delete_item.Equals("���¸��� �����")) { Delete_Item_Fish("���¸��ʹ����", 5959); }
        else if (select_delete_item.Equals("����� �����")) { Delete_Item_Fish("����������", 3999); }
        else if (select_delete_item.Equals("�ҸӴ��ǻ�� �����")) { Delete_Item_Fish("�ҸӴ��ǻ�������", 10000); }
    }

    void Delete_Item_Fruit(string name, int price)
    {
        int count2 = int.Parse(input.text);
        if (userInfo.FruitItem[name] < count2)
        {
            Delete_obj.SetActive(false);
            noSale_obj.SetActive(true);
        }
        else if(userInfo.FruitItem[name] == count2)
        {
            userInfo.FruitItemkey.Remove(name);
            userInfo.FruitItem.Remove(name);
            int mygold = userInfo.getGold();
            mygold = mygold + (price * count2);
            userInfo.setGold(mygold);
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            UIGold.text = userInfo.getGold().ToString();
            for(int i = 0; i<Parent.transform.childCount; i++) // ��� ������Ʈ �ı�
            {
                Destroy(Parent.GetChild(i).gameObject);
            }
            OpenSale(); // �ٽ� ����
            Delete_obj.SetActive(false);
        }
        else
        {
            int have_count = userInfo.FruitItem[name];
            userInfo.FruitItem[name] = have_count - count2;
            int mygold = userInfo.getGold();
            mygold = mygold + (price * count2);
            userInfo.setGold(mygold);
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            UIGold.text = userInfo.getGold().ToString();
            Delete_obj.SetActive(false);
        }
    }
    void Delete_Item_Fish(string name, int price)
    {
        int count2 = int.Parse(input.text);
        if (userInfo.FishItem[name] < count2)
        {
            Delete_obj.SetActive(false);
            noSale_obj.SetActive(true);
        }
        else if (userInfo.FishItem[name] == count2)
        {
            userInfo.FishItemkey.Remove(name);
            userInfo.FishItem.Remove(name);
            int mygold = userInfo.getGold();
            mygold = mygold + (price * count2);
            userInfo.setGold(mygold);
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            UIGold.text = userInfo.getGold().ToString();
            for (int i = 0; i < Parent.transform.childCount; i++) // ��� ������Ʈ �ı�
            {
                Destroy(Parent.GetChild(i).gameObject);
            }
            OpenSale(); // �ٽ� ����
            Delete_obj.SetActive(false);
        }
        else
        {
            int have_count = userInfo.FishItem[name];
            userInfo.FishItem[name] = have_count - count2;
            int mygold = userInfo.getGold();
            mygold = mygold + (price * count2);
            userInfo.setGold(mygold);
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            UIGold.text = userInfo.getGold().ToString();
            Delete_obj.SetActive(false);
        }
    }

    public void no_sale_okay()
    {
        noSale_obj.SetActive(false);
    }






    public void Up_Button()
    {
        sale_count = int.Parse(input.text);
        sale_count++;
        input.text = sale_count.ToString();
    }

    public void Down_Button()
    {

        sale_count = int.Parse(input.text);
        sale_count--;
        input.text = sale_count.ToString();
    }
    public void Delete_No()
    {
        Delete_obj.SetActive(false);
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
