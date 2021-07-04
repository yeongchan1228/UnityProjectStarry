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
    public bool isAction, isSamekey;
    //bool isfrist;
    public Button btExit;
    public Button btStore;
    GameObject PlayerUI;
    MenuControl menuControl;
    public Button btUpgrade;
    public Scrollbar scrollbar;
    public GameObject obj, store, Inventory, upgrade;
    public GameObject Delete_obj, noSale_obj, Buy_obj, noBuy_obj, upgrade_obj;
    public InputField input, input2;
    string select_delete_item, select_buy_item;
    int save_i, save_j, select_buy_item_price, seed_count;
    Transform Parent;
    UserInfo userInfo;
    GameObject user_man, user_woman;
    int sale_count, buy_count;
    public Sprite[] fruit_afters, invens, seeds, swords, tools;
    private Sprite[] fishes1, fishes2, fishes3, fishes4, fishes5, fishes6, fishes7, fishes8, fishes9, fishes10;
    int sword_price, armor_price, fishrod_price, hoe_price, waterPPU_price;

    void Start()
    {
        Inventory = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
        btExit.onClick.AddListener(ExitWindow);
        btStore.onClick.AddListener(OpenStore);
        btUpgrade.onClick.AddListener(OpenUpgrade);
        user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
        menuControl = GameObject.Find("MenuManager").GetComponent<MenuControl>();
        user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        seeds = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
        swords = Resources.LoadAll<Sprite>("Sprites/sword");
        tools = Resources.LoadAll<Sprite>("Sprites/Tool");
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
        userInfo.setGold(50000);
        store = storePart.transform.GetChild(0).transform.GetChild(0).gameObject;
        upgrade = upgradePart.transform.GetChild(0).transform.GetChild(0).gameObject;
        for(int i = 0; i < store.transform.childCount; i++) // ���� ��ư �����ʵ��
        {
            Button btt = store.transform.GetChild(i).transform.GetChild(5).GetComponent<Button>();
            btt.onClick.AddListener(IntoInven);
        }
        for (int i = 0; i < upgrade.transform.childCount; i++) // ���� ��ư �����ʵ��
        {
            Button btt = upgrade.transform.GetChild(i).transform.GetChild(5).GetComponent<Button>();
            btt.onClick.AddListener(Item_Upgrade);
        }
        set_Sword();
        set_Armor();
        set_Fishrod();
        set_Hoe();
        set_WaterPPU();
    }

    public void Item_Upgrade()
    {
        GameObject Upgrade_Button = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        if (Upgrade_Button.name.Equals("Sword"))
        {
            Text price = upgrade.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();
            Button btt = upgrade.transform.GetChild(0).transform.GetChild(5).GetComponent<Button>();
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            Image UISword = PlayerUI.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
            int usergold = userInfo.getGold();
            if (userInfo.getItem_Weapon().GetWeaponName().Equals("rustysword") && usergold > sword_price)
            {
                usergold -= sword_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "5,000G";
                UISword.sprite = swords[9] as Sprite;
                sword_price = 5000;
                userInfo.getItem_Weapon().SetWeaponName("woodsword");
                userInfo.getItem_Weapon().SetWeaponPower(10);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("woodsword") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[8] as Sprite;
                sword_price = 15000;
                price.text = "15,000G";
                userInfo.getItem_Weapon().SetWeaponName("steelsword");
                userInfo.getItem_Weapon().SetWeaponPower(20);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("steelsword") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[7] as Sprite;
                sword_price = 28000;
                price.text = "28,000G";
                userInfo.getItem_Weapon().SetWeaponName("silversword");
                userInfo.getItem_Weapon().SetWeaponPower(30);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("silversword") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[0] as Sprite;
                sword_price = 50000;
                price.text = "50,000G";
                userInfo.getItem_Weapon().SetWeaponName("cutlass");
                userInfo.getItem_Weapon().SetWeaponPower(40);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("cutlass") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[1] as Sprite;
                sword_price = 80000;
                price.text = "80,000G";
                userInfo.getItem_Weapon().SetWeaponName("darksword");
                userInfo.getItem_Weapon().SetWeaponPower(50);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("darksword") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[5] as Sprite;
                sword_price = 170000;
                price.text = "170,000G";
                userInfo.getItem_Weapon().SetWeaponName("obsidian");
                userInfo.getItem_Weapon().SetWeaponPower(60);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("obsidian") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[3] as Sprite;
                sword_price = 350000;
                price.text = "350,000G";
                userInfo.getItem_Weapon().SetWeaponName("holysword");
                userInfo.getItem_Weapon().SetWeaponPower(70);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("holysword") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[4] as Sprite;
                sword_price = 500000;
                price.text = "500,000G";
                userInfo.getItem_Weapon().SetWeaponName("lavasword");
                userInfo.getItem_Weapon().SetWeaponPower(80);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Weapon().GetWeaponName().Equals("lavasword") && usergold > sword_price)
            {
                usergold -= sword_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                UISword.sprite = swords[2] as Sprite;
                sword_price = 0;
                price.text = "0G";
                btt.interactable = false;
                userInfo.getItem_Weapon().SetWeaponName("galaxysword");
                userInfo.getItem_Weapon().SetWeaponPower(100);
                upgrade_obj.SetActive(true);
            }
            else
            {
                noBuy_obj.SetActive(true);
            }
        }
        else if (Upgrade_Button.name.Equals("Armor"))
        {
            Text price = upgrade.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
            Button btt = upgrade.transform.GetChild(1).transform.GetChild(5).GetComponent<Button>();
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            int usergold = userInfo.getGold();
            if (userInfo.getItem_Armor().GetArmorName() == null && usergold > armor_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "70,000G";
                armor_price = 70000;
                userInfo.getItem_Armor().SetArmorName("stonetop");
                userInfo.getItem_Armor().SetArmorPower(3);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Armor().GetArmorName().Equals("stonetop") && usergold > armor_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "150,000G";
                armor_price = 150000;
                userInfo.getItem_Armor().SetArmorName("silvertop");
                userInfo.getItem_Armor().SetArmorPower(7);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Armor().GetArmorName().Equals("silvertop") && usergold > armor_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "300,000G";
                armor_price = 300000;
                userInfo.getItem_Armor().SetArmorName("iridiumtop");
                userInfo.getItem_Armor().SetArmorPower(12);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Armor().GetArmorName().Equals("iridiumtop") && usergold > armor_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "0G";
                armor_price = 0;
                userInfo.getItem_Armor().SetArmorName("diatop");
                userInfo.getItem_Armor().SetArmorPower(20);
                btt.interactable = false;
                upgrade_obj.SetActive(true);
            }
        }
        else if (Upgrade_Button.name.Equals("Fish"))
        {
            Text price = upgrade.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
            Button btt = upgrade.transform.GetChild(2).transform.GetChild(5).GetComponent<Button>();
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            Image UIFishing = PlayerUI.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).GetComponent<Image>();
            int usergold = userInfo.getGold();
            if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Stone_FishingRod") && usergold > fishrod_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "30,000G";
                armor_price = 30000;
                UIFishing.sprite = tools[2] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Guri_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(2);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Guri_FishingRod") && usergold > fishrod_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "50,000G";
                armor_price = 50000;
                UIFishing.sprite = tools[8] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Sliver_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(3);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Sliver_FishingRod") && usergold > fishrod_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "80,000G";
                armor_price = 80000;
                UIFishing.sprite = tools[5] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Iridium_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(4);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Iridium_FishingRod") && usergold > fishrod_price)
            {
                usergold -= armor_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "0G";
                armor_price = 0;
                UIFishing.sprite = tools[0] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Dia_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(6);
                btt.interactable = false;
                upgrade_obj.SetActive(true);
            }
        }
        else if (Upgrade_Button.name.Equals("Homi"))
        {
            Text price = upgrade.transform.GetChild(3).transform.GetChild(2).GetComponent<Text>();
            Button btt = upgrade.transform.GetChild(3).transform.GetChild(5).GetComponent<Button>();
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            Image UIFishing = PlayerUI.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
            int usergold = userInfo.getGold();
        }
    }
    void set_Sword()
    {
        Text price = upgrade.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>();
        Button btt = upgrade.transform.GetChild(0).transform.GetChild(5).GetComponent<Button>();
        if (userInfo.getItem_Weapon().GetWeaponName().Equals("rustysword")) { sword_price = 1500; price.text = "1,500G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("woodsword")) { sword_price = 5000; price.text = "5,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("steelsword")) { sword_price = 15000; price.text = "15,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("silversword")) { sword_price = 28000; price.text = "28,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("cutlass")) { sword_price = 50000; price.text = "50,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("darksword")) { sword_price = 80000; price.text = "80,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("obsidian")) { sword_price = 170000; price.text = "170,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("holysword")) { sword_price = 350000; price.text = "350,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("lavasword")) { sword_price = 500000; price.text = "500,000G"; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("galaxysword")) { sword_price = 0; price.text = "0G"; btt.interactable = false; }
    }
    void set_Armor()
    {
        Text price = upgrade.transform.GetChild(1).transform.GetChild(2).GetComponent<Text>();
        Debug.LogError(price);
        Button btt = upgrade.transform.GetChild(1).transform.GetChild(5).GetComponent<Button>();
        if (userInfo.getItem_Armor().GetArmorName() == null) { armor_price = 25000; price.text = "25,000G"; }
        else if (userInfo.getItem_Armor().GetArmorName().Equals("stonetop")) { armor_price = 70000; price.text = "70,000G"; }
        else if (userInfo.getItem_Armor().GetArmorName().Equals("silvertop")) { armor_price = 150000; price.text = "150,000G"; }
        else if (userInfo.getItem_Armor().GetArmorName().Equals("iridiumtop")) { armor_price = 300000; price.text = "300,000G"; }
        else if (userInfo.getItem_Armor().GetArmorName().Equals("diatop")) { armor_price = 0; price.text = "0G"; btt.interactable = false; }
    }
    void set_Fishrod()
    {
        Text price = upgrade.transform.GetChild(2).transform.GetChild(2).GetComponent<Text>();
        Button btt = upgrade.transform.GetChild(2).transform.GetChild(5).GetComponent<Button>();
        if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Stone_FishingRod")) { fishrod_price = 10000; price.text = "10,000G"; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Guri_FishingRod")) { fishrod_price = 30000; price.text = "30,000G"; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Silver_FishingRod")) { fishrod_price = 50000; price.text = "50,000G"; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Iridium_FishingRod")) { fishrod_price = 80000; price.text = "80,000G"; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Dia_FishingRod")) { fishrod_price = 0; price.text = "0G"; btt.interactable = false; }
    }
    void set_Hoe()
    {
        Text price = upgrade.transform.GetChild(3).transform.GetChild(2).GetComponent<Text>();
        Button btt = upgrade.transform.GetChild(3).transform.GetChild(5).GetComponent<Button>();
        if (userInfo.getItem_Hoe().GetHoeName().Equals("Stone_Hoe")) { hoe_price = 10000; price.text = "10,000G"; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Guri_Hoe")) { hoe_price = 30000; price.text = "30,000G"; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Silver_Hoe")) { hoe_price = 50000; price.text = "50,000G"; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Iridium_Hoe")) { hoe_price = 80000; price.text = "80,000G"; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Dia_Hoe")) { hoe_price = 0; price.text = "0G"; btt.interactable = false; }
    }
    void set_WaterPPU()
    {
        Text price = upgrade.transform.GetChild(4).transform.GetChild(2).GetComponent<Text>();
        Button btt = upgrade.transform.GetChild(4).transform.GetChild(5).GetComponent<Button>();
        if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Stone_Water")) { waterPPU_price = 10000; price.text = "10,000G"; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Guri_Water")) { waterPPU_price = 30000; price.text = "30,000G"; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Silver_Water")) { waterPPU_price = 50000; price.text = "50,000G"; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Iridium_Water")) { waterPPU_price = 80000; price.text = "80,000G"; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Dia_Water")) { waterPPU_price = 0; price.text = "0G"; btt.interactable = false; }
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
            save_i++;
            save_j++;
        }
        for(int i = 0; i<userInfo.FishItemkey.Count; i++, save_i++, save_j++)
        {
            Debug.LogError("�����");
            Child = Instantiate(obj, new Vector3(0, 0, 0), Quaternion.identity);
            Child.SetActive(true);
            Child.name = userInfo.FishItemkey[i];
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

    public void IntoInven()
    {
        buy_count = 0;
        seed_count = 0;
        input2.text = "0";
        GameObject Buy_Button = EventSystem.current.currentSelectedGameObject.transform.parent.gameObject;
        Text select_buy = Buy_Button.transform.GetChild(0).GetComponent<Text>();
        Text select_buy_price = Buy_Button.transform.GetChild(2).GetComponent<Text>();
        Debug.LogError(select_buy_price);
        Debug.LogError(select_buy_price.text);
        select_buy_item = select_buy.text;
        Buy_obj.SetActive(true);
    }

    public void buy_Okay()
    {
        buy_count = int.Parse(input2.text);
        if(select_buy_item.Equals("������")) { select_buy_item_price = 100000; user_Inven(); }
        else if(select_buy_item.Equals("�� ����")) { select_buy_item_price = 30; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 45; user_Inven(); }
        else if (select_buy_item.Equals("��� ����")) { select_buy_item_price = 60; user_Inven(); }
        else if (select_buy_item.Equals("������ ����")) { select_buy_item_price = 100; user_Inven(); }
        else if (select_buy_item.Equals("�ƺ�ī�� ����")) { select_buy_item_price = 250; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 150; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 500; user_Inven(); }
        else if (select_buy_item.Equals("��纣�� ����")) { select_buy_item_price = 350; user_Inven(); }
        else if (select_buy_item.Equals("��� ����")) { select_buy_item_price = 220; user_Inven(); }
        else if (select_buy_item.Equals("���ξ��� ����")) { select_buy_item_price = 450; user_Inven(); }
        else if (select_buy_item.Equals("ȣ�� ����")) { select_buy_item_price = 320; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 80; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 420; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 170; user_Inven(); }
        else if (select_buy_item.Equals("�丶�� ����")) { select_buy_item_price = 200; user_Inven(); }
        else if (select_buy_item.Equals("���� ����")) { select_buy_item_price = 480; user_Inven(); }
        else if (select_buy_item.Equals("�Ǹ��� ���� ����")) { select_buy_item_price = 666; user_Inven(); }
        else if (select_buy_item.Equals("õ���� ���� ����")) { select_buy_item_price = 777; user_Inven(); }
        else if (select_buy_item.Equals("���� ���� ����")) { select_buy_item_price = 999; user_Inven(); }
    }
    
    void user_Inven()
    {
        int userGold = userInfo.getGold();
        if (userGold > select_buy_item_price * buy_count && buy_count != 0)
        {
            userInfo.setGold(userGold - select_buy_item_price * buy_count);
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            UIGold.text = userInfo.getGold().ToString();
            for (int i = 0; i < userInfo.SeedItemkey.Count; i++)
            {
                if (userInfo.SeedItemkey[i].Equals(select_buy_item))
                {
                    seed_count = userInfo.SeedItem[select_buy_item];
                    isSamekey = true;
                }
            }
            seed_count = seed_count + buy_count;
            if (!isSamekey)
            {
                userInfo.SeedItemkey.Add(select_buy_item);
                userInfo.SeedItem.Add(select_buy_item, seed_count);
            }
            userInfo.SeedItem[select_buy_item] = seed_count;
            isSamekey = false;
            for (int i = 0; i < userInfo.SeedItemkey.Count; i++)
            {
                GameObject bottonobj = menuControl.InventorySeed.transform.GetChild(i).gameObject;

                bottonobj.SetActive(true);
                Image bottonimg = bottonobj.GetComponent<Image>();

                if (i == 0)
                {
                    bottonimg.sprite = invens[1] as Sprite; // �κ� ����
                }
                GameObject Image = bottonobj.transform.GetChild(0).gameObject;
                Image seedimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                if (userInfo.SeedItemkey[i].Equals("������")) { seedimg.sprite = seeds[10]; }
                else if (userInfo.SeedItemkey[i].Equals("�� ����")) { seedimg.sprite = seeds[9]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[12]; }
                else if (userInfo.SeedItemkey[i].Equals("��� ����")) { seedimg.sprite = seeds[1]; }
                else if (userInfo.SeedItemkey[i].Equals("������ ����")) { seedimg.sprite = seeds[3]; }
                else if (userInfo.SeedItemkey[i].Equals("�ƺ�ī�� ����")) { seedimg.sprite = seeds[4]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[5]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[6]; }
                else if (userInfo.SeedItemkey[i].Equals("��纣�� ����")) { seedimg.sprite = seeds[0]; }
                else if (userInfo.SeedItemkey[i].Equals("��� ����")) { seedimg.sprite = seeds[8]; }
                else if (userInfo.SeedItemkey[i].Equals("���ξ��� ����")) { seedimg.sprite = seeds[11]; }
                else if (userInfo.SeedItemkey[i].Equals("ȣ�� ����")) { seedimg.sprite = seeds[13]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[14]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[16]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[17]; }
                else if (userInfo.SeedItemkey[i].Equals("�丶�� ����")) { seedimg.sprite = seeds[18]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ����")) { seedimg.sprite = seeds[19]; }
                else if (userInfo.SeedItemkey[i].Equals("�Ǹ��� ���� ����")) { seedimg.sprite = seeds[2]; }
                else if (userInfo.SeedItemkey[i].Equals("õ���� ���� ����")) { seedimg.sprite = seeds[7]; }
                else if (userInfo.SeedItemkey[i].Equals("���� ���� ����")) { seedimg.sprite = seeds[15]; }
                Image.SetActive(true);
                GameObject text = bottonobj.transform.GetChild(1).gameObject;
                Debug.LogError(text);
                Text Seedtext = text.GetComponent<Text>(); // ���� ����
                Seedtext.text = userInfo.SeedItem[userInfo.SeedItemkey[i]].ToString();
                text.SetActive(true);
                seed_count = 0;
                Buy_obj.SetActive(false);
            }
        }
        else if(buy_count == 0) { Buy_obj.SetActive(false); }
        else
        {
            Buy_obj.SetActive(false);
            noBuy_obj.SetActive(true);
        }
    }
    public void buy_Cancel()
    {
        Buy_obj.SetActive(false);
    }

    public void On_Sale_Item()
    {
        sale_count = 0;
        input.text = "0";
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

    void Reset_Fruit()
    {
        GameObject InvenFruit = Inventory.transform.GetChild(7).gameObject;
        for(int i = 0; i < 20; i++)
        {
            Image invenimg = InvenFruit.transform.GetChild(i).GetComponent<Image>();
            invenimg.sprite = invens[0] as Sprite;
            GameObject inven_img1 = InvenFruit.transform.GetChild(i).transform.GetChild(0).gameObject;
            GameObject inven_img2 = InvenFruit.transform.GetChild(i).transform.GetChild(1).gameObject;
            if (inven_img1.activeSelf) { inven_img1.SetActive(false); }
            if (inven_img2.activeSelf) { inven_img2.SetActive(false); }
        }
        for(int i =0; i < userInfo.FruitItemkey.Count; i++)
        {
            GameObject bottonobj = InvenFruit.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            if (i == 0)
            {
                bottonimg.sprite = invens[1] as Sprite; // �κ� ����
            }
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image Fruitimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.FruitItemkey[i].Equals("Blueberry")) { Fruitimg.sprite = fruit_afters[0]; }
            else if (userInfo.FruitItemkey[i].Equals("carrot")) { Fruitimg.sprite = fruit_afters[1]; }
            else if (userInfo.FruitItemkey[i].Equals("DARK")) { Fruitimg.sprite = fruit_afters[2]; }
            else if (userInfo.FruitItemkey[i].Equals("dhrtntn1")) { Fruitimg.sprite = fruit_afters[3]; }
            else if (userInfo.FruitItemkey[i].Equals("dkqhzkeh1")) { Fruitimg.sprite = fruit_afters[4]; }
            else if (userInfo.FruitItemkey[i].Equals("Grape")) { Fruitimg.sprite = fruit_afters[5]; }
            else if (userInfo.FruitItemkey[i].Equals("lemon1")) { Fruitimg.sprite = fruit_afters[6]; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { Fruitimg.sprite = fruit_afters[7]; }
            else if (userInfo.FruitItemkey[i].Equals("melon")) { Fruitimg.sprite = fruit_afters[8]; }
            else if (userInfo.FruitItemkey[i].Equals("mil1")) { Fruitimg.sprite = fruit_afters[9]; }
            else if (userInfo.FruitItemkey[i].Equals("pineapple1")) { Fruitimg.sprite = fruit_afters[10]; }
            else if (userInfo.FruitItemkey[i].Equals("Potato")) { Fruitimg.sprite = fruit_afters[11]; }
            else if (userInfo.FruitItemkey[i].Equals("Pumpkin")) { Fruitimg.sprite = fruit_afters[12]; }
            else if (userInfo.FruitItemkey[i].Equals("rkwl1")) { Fruitimg.sprite = fruit_afters[13]; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { Fruitimg.sprite = fruit_afters[14]; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { Fruitimg.sprite = fruit_afters[15]; }
            else if (userInfo.FruitItemkey[i].Equals("tnsan1")) { Fruitimg.sprite = fruit_afters[16]; }
            else if (userInfo.FruitItemkey[i].Equals("Tomato")) { Fruitimg.sprite = fruit_afters[17]; }
            else if (userInfo.FruitItemkey[i].Equals("watermelon")) { Fruitimg.sprite = fruit_afters[18]; }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fruittext = text.GetComponent<Text>(); // ���� ����
            Fruittext.text = userInfo.FruitItem[userInfo.FruitItemkey[i]].ToString();
            text.SetActive(true);
        }
    }
    void Reset_Fish()
    {
        GameObject InvenFish = Inventory.transform.GetChild(8).gameObject;
        for (int i = 0; i < 20; i++)
        {
            Image invenimg = InvenFish.transform.GetChild(i).GetComponent<Image>();
            invenimg.sprite = invens[0] as Sprite;
            GameObject inven_img1 = InvenFish.transform.GetChild(i).transform.GetChild(0).gameObject;
            GameObject inven_img2 = InvenFish.transform.GetChild(i).transform.GetChild(1).gameObject;
            if (inven_img1.activeSelf) { inven_img1.SetActive(false); }
            if (inven_img2.activeSelf) { inven_img2.SetActive(false); }
        }
        for (int i = 0; i < userInfo.FruitItemkey.Count; i++)
        {
            GameObject bottonobj = InvenFish.transform.GetChild(i).gameObject;
            bottonobj.SetActive(true);
            Image bottonimg = bottonobj.GetComponent<Image>();
            if (i == 0)
            {
                bottonimg.sprite = invens[1] as Sprite; // �κ� ����
            }
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image Fishimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.FishItemkey[i].Equals("����ѹ����")) { Fishimg.sprite = fishes1[0]; }
            else if (userInfo.FishItemkey[i].Equals("���������")) { Fishimg.sprite = fishes2[0]; }
            else if (userInfo.FishItemkey[i].Equals("��Ȳ�����")) { Fishimg.sprite = fishes2[1]; }
            else if (userInfo.FishItemkey[i].Equals("��������")) { Fishimg.sprite = fishes3[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ʷϹ����")) { Fishimg.sprite = fishes3[1]; }
            else if (userInfo.FishItemkey[i].Equals("���������")) { Fishimg.sprite = fishes4[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ϴû������")) { Fishimg.sprite = fishes4[1]; }
            else if (userInfo.FishItemkey[i].Equals("���󹰰��")) { Fishimg.sprite = fishes5[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ǻ繰���")) { Fishimg.sprite = fishes5[1]; }
            else if (userInfo.FishItemkey[i].Equals("��ι����")) { Fishimg.sprite = fishes6[0]; }
            else if (userInfo.FishItemkey[i].Equals("�����������")) { Fishimg.sprite = fishes6[1]; }
            else if (userInfo.FishItemkey[i].Equals("���ֹ����")) { Fishimg.sprite = fishes7[0]; }
            else if (userInfo.FishItemkey[i].Equals("���ι����")) { Fishimg.sprite = fishes7[1]; }
            else if (userInfo.FishItemkey[i].Equals("�źι����")) { Fishimg.sprite = fishes7[2]; }
            else if (userInfo.FishItemkey[i].Equals("�Ż繰���")) { Fishimg.sprite = fishes7[3]; }
            else if (userInfo.FishItemkey[i].Equals("�Ǹ������")) { Fishimg.sprite = fishes8[0]; }
            else if (userInfo.FishItemkey[i].Equals("õ�繰���")) { Fishimg.sprite = fishes8[1]; }
            else if (userInfo.FishItemkey[i].Equals("���¸��ʹ����")) { Fishimg.sprite = fishes9[1]; }
            else if (userInfo.FishItemkey[i].Equals("����������")) { Fishimg.sprite = fishes9[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ҸӴ��ǻ�������")) { Fishimg.sprite = fishes10[0]; }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fishtext = text.GetComponent<Text>(); // ���� ����
            Fishtext.text = userInfo.FishItem[userInfo.FishItemkey[i]].ToString();
            text.SetActive(true);
        }
    }

        void Delete_Item_Fruit(string name, int price)
        {
            int count2 = int.Parse(input.text);
            if (userInfo.FruitItem[name] < count2)
            {
                Delete_obj.SetActive(false);
                noSale_obj.SetActive(true);
            }
            else if (userInfo.FruitItem[name] == count2)
            {
                userInfo.FruitItemkey.Remove(name);
                userInfo.FruitItem.Remove(name);
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
                Reset_Fruit();
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
                Reset_Fruit();
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
                Reset_Fish();
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
                UIGold.text = userInfo.getGold().ToString(); ;
                Reset_Fish();
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
        public void Up_Button2()
        {
            buy_count = int.Parse(input2.text);
            buy_count++;
            input2.text = buy_count.ToString();
        }

        public void Down_Button2()
        {
            buy_count = int.Parse(input2.text);
            buy_count--;
            input2.text = buy_count.ToString();
        }
        public void Delete_No()
        {
            Delete_obj.SetActive(false);
        }
        public void Upgrade_finish()
    {
        upgrade_obj.SetActive(false);
    }
        public void Buy_No()
        {
            noBuy_obj.SetActive(false);
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
