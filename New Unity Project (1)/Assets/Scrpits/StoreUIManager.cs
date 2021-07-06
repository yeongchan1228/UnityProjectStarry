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
    public bool isAction, isSamekey, isfirst;
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
    int save_i, save_j, select_buy_item_price, seed_count, story_count;
    Transform Parent;
    UserInfo userInfo;
    GameObject user_man, user_woman;
    int sale_count, buy_count;
    public Sprite[] fruit_afters, invens, seeds, swords, tools;
    private Sprite[] fishes1, fishes2, fishes3, fishes4, fishes5, fishes6, fishes7, fishes8, fishes9, fishes10;
    int sword_price, armor_price, fishrod_price, hoe_price, waterPPU_price;
    Sprite[] spec_orgol;
    Sprite[] special;

    TalkManager talkManager;

    void Start()
    {
        Inventory = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
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
        fishes1 = Resources.LoadAll<Sprite>("Sprites/fish/난이도1"); // 1마리
        fishes2 = Resources.LoadAll<Sprite>("Sprites/fish/난이도2"); // 2마리
        fishes3 = Resources.LoadAll<Sprite>("Sprites/fish/난이도3"); // 2마리
        fishes4 = Resources.LoadAll<Sprite>("Sprites/fish/난이도4"); // 2마리
        fishes5 = Resources.LoadAll<Sprite>("Sprites/fish/난이도5"); // 2마리
        fishes6 = Resources.LoadAll<Sprite>("Sprites/fish/난이도6"); // 2마리
        fishes7 = Resources.LoadAll<Sprite>("Sprites/fish/난이도7"); // 4마리
        fishes8 = Resources.LoadAll<Sprite>("Sprites/fish/난이도8"); // 2마리
        fishes9 = Resources.LoadAll<Sprite>("Sprites/fish/난이도9"); // 2마리
        fishes10 = Resources.LoadAll<Sprite>("Sprites/fish/난이도10"); // 1마리

        spec_orgol = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        special = Resources.LoadAll<Sprite>("Sprites/Final");

        talkManager = GameObject.Find("TalkManager").GetComponent<TalkManager>();
        PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
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
        store = storePart.transform.GetChild(0).transform.GetChild(0).gameObject;
        userInfo.setGold(50000000);
        upgrade = upgradePart.transform.GetChild(0).transform.GetChild(0).gameObject;
        for(int i = 0; i < store.transform.childCount; i++) // 구매 버튼 리스너등록
        {
            Button btt = store.transform.GetChild(i).transform.GetChild(5).GetComponent<Button>();
            btt.onClick.AddListener(IntoInven);
        }
        for (int i = 0; i < upgrade.transform.childCount; i++) // 구매 버튼 리스너등록
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
            Text power = Inventory.transform.GetChild(9).transform.GetChild(5).GetComponent<Text>();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
                power.text = "공격력 : " + userInfo.getItem_Weapon().GetWeaponPower().ToString();
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
            Text Armor = Inventory.transform.GetChild(9).transform.GetChild(6).GetComponent<Text>();
            int usergold = userInfo.getGold();
            if (userInfo.getItem_Armor().GetArmorName() == null && usergold > armor_price)
            {
                usergold -= armor_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "70,000G";
                armor_price = 70000;
                userInfo.getItem_Armor().SetArmorName("stonetop");
                userInfo.getItem_Armor().SetArmorPower(3);
                Armor.text = "방어력 : " + userInfo.getItem_Armor().GetArmorPower().ToString();
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Armor().GetArmorName().Equals("stonetop") && usergold > armor_price)
            {
                usergold -= armor_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "150,000G";
                armor_price = 150000;
                userInfo.getItem_Armor().SetArmorName("silvertop");
                userInfo.getItem_Armor().SetArmorPower(7);
                Armor.text = "방어력 : " + userInfo.getItem_Armor().GetArmorPower().ToString();
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Armor().GetArmorName().Equals("silvertop") && usergold > armor_price)
            {
                usergold -= armor_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "300,000G";
                armor_price = 300000;
                userInfo.getItem_Armor().SetArmorName("iridiumtop");
                userInfo.getItem_Armor().SetArmorPower(12);
                Armor.text = "방어력 : " + userInfo.getItem_Armor().GetArmorPower().ToString();
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Armor().GetArmorName().Equals("iridiumtop") && usergold > armor_price)
            {
                usergold -= armor_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "0G";
                armor_price = 0;
                userInfo.getItem_Armor().SetArmorName("diatop");
                userInfo.getItem_Armor().SetArmorPower(20);
                Armor.text = "방어력 : " + userInfo.getItem_Armor().GetArmorPower().ToString();
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
                usergold -= fishrod_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "30,000G";
                fishrod_price = 30000;
                UIFishing.sprite = tools[2] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Guri_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(2);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Guri_FishingRod") && usergold > fishrod_price)
            {
                usergold -= fishrod_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "50,000G";
                fishrod_price = 50000;
                UIFishing.sprite = tools[8] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Sliver_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(3);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Sliver_FishingRod") && usergold > fishrod_price)
            {
                usergold -= fishrod_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "80,000G";
                fishrod_price = 80000;
                UIFishing.sprite = tools[5] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Iridium_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(5);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Iridium_FishingRod") && usergold > fishrod_price)
            {
                usergold -= fishrod_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "0G";
                fishrod_price = 0;
                UIFishing.sprite = tools[0] as Sprite;
                userInfo.getItem_FishingRod().SetFishingRodName("Dia_FishingRod");
                userInfo.getItem_FishingRod().SetFishingRodEfficiency(8);
                btt.interactable = false;
                upgrade_obj.SetActive(true);
            }
        }
        else if (Upgrade_Button.name.Equals("Homi"))
        {
            Text price = upgrade.transform.GetChild(3).transform.GetChild(2).GetComponent<Text>();
            Button btt = upgrade.transform.GetChild(3).transform.GetChild(5).GetComponent<Button>();
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            Image UIHoe = PlayerUI.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).GetComponent<Image>();
            int usergold = userInfo.getGold();
            if (userInfo.getItem_Hoe().GetHoeName().Equals("Stone_Hoe") && usergold > hoe_price)
            {
                usergold -= hoe_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "30,000G";
                hoe_price = 30000;
                UIHoe.sprite = tools[4] as Sprite;
                userInfo.getItem_Hoe().SetHoeName("Guri_Hoe");
                userInfo.getItem_Hoe().SetHoeSpeed(8);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Hoe().GetHoeName().Equals("Guri_Hoe") && usergold > hoe_price)
            {
                usergold -= hoe_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "50,000G";
                hoe_price = 50000;
                UIHoe.sprite = tools[10] as Sprite;
                userInfo.getItem_Hoe().SetHoeName("Sliver_Hoe");
                userInfo.getItem_Hoe().SetHoeSpeed(6);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Hoe().GetHoeName().Equals("Sliver_Hoe") && usergold > hoe_price)
            {
                usergold -= hoe_price;
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "80,000G";
                hoe_price = 80000;
                UIHoe.sprite = tools[7] as Sprite;
                userInfo.getItem_Hoe().SetHoeName("Iridium_Hoe");
                userInfo.getItem_Hoe().SetHoeSpeed(4);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_Hoe().GetHoeName().Equals("Iridium_Hoe") && usergold > hoe_price)
            {
                usergold -= hoe_price; 
                userInfo.setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "0G";
                hoe_price = 0;
                UIHoe.sprite = tools[1] as Sprite;
                userInfo.getItem_Hoe().SetHoeName("Dia_Hoe");
                userInfo.getItem_Hoe().SetHoeSpeed(2);
                btt.interactable = false;
                upgrade_obj.SetActive(true);
            }
        }
        else if (Upgrade_Button.name.Equals("Water"))
        {
            Text price = upgrade.transform.GetChild(4).transform.GetChild(2).GetComponent<Text>();
            Button btt = upgrade.transform.GetChild(4).transform.GetChild(5).GetComponent<Button>();
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            Image UIWater = PlayerUI.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).GetComponent<Image>();
            int usergold = userInfo.getGold();
            if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Stone_Water") && usergold > waterPPU_price)
            {
                usergold -= waterPPU_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "30,000G";
                waterPPU_price = 30000;
                UIWater.sprite = tools[15] as Sprite;
                userInfo.getItem_WaterPPU().SetWaterPPUName("Guri_Water");
                userInfo.getItem_WaterPPU().SetWaterPPUFilled(150);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Guri_Water") && usergold > waterPPU_price)
            {
                usergold -= waterPPU_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "50,000G";
                waterPPU_price = 50000;
                UIWater.sprite = tools[18] as Sprite;
                userInfo.getItem_WaterPPU().SetWaterPPUName("Silver_Water");
                userInfo.getItem_WaterPPU().SetWaterPPUFilled(200);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Silver_Water") && usergold > waterPPU_price)
            {
                usergold -= waterPPU_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "80,000G";
                waterPPU_price = 80000;
                UIWater.sprite = tools[17] as Sprite;
                userInfo.getItem_WaterPPU().SetWaterPPUName("Iridium_Water");
                userInfo.getItem_WaterPPU().SetWaterPPUFilled(250);
                upgrade_obj.SetActive(true);
            }
            else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Iridium_Water") && usergold > waterPPU_price)
            {
                usergold -= waterPPU_price; userInfo.
                setGold(usergold);
                UIGold.text = userInfo.getGold().ToString();
                price.text = "0G";
                waterPPU_price = 0;
                UIWater.sprite = tools[16] as Sprite;
                userInfo.getItem_WaterPPU().SetWaterPPUName("Dia_Water");
                userInfo.getItem_WaterPPU().SetWaterPPUFilled(300);
                btt.interactable = false;
                upgrade_obj.SetActive(true);
            }
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
            userInfo.FishItemkey.Add("악마물고기");
            userInfo.FishItem.Add("악마물고기", 1);
            userInfo.FishItemkey.Add("천사물고기");
            userInfo.FishItem.Add("천사물고기", 1);
            isfrist = true;
        }*/
        if (isfirst)
        {
            return;
        }
        isfirst = true;
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
            if (userInfo.FruitItemkey[i].Equals("Blueberry")) { Name.text = "블루베리"; Price.text = "520G"; Detail.text = "아주 달콤한 고급 블루베리이다."; image.sprite = fruit_afters[0]; }
            else if (userInfo.FruitItemkey[i].Equals("carrot")) { Name.text = "당근"; Price.text = "110G"; Detail.text = "햇볕에서 맛있게 자란 싱싱한 당근이다."; image.sprite = fruit_afters[1]; }
            else if (userInfo.FruitItemkey[i].Equals("DARK")) { Name.text = "악마의 과일"; Price.text = "2,666G"; Detail.text = "먹으면 큰일이 날 것 같은 악마의 과일이다."; image.sprite = fruit_afters[2]; }
            else if (userInfo.FruitItemkey[i].Equals("dhrtntn1")) { Name.text = "옥수수"; Price.text = "290G"; Detail.text = "달콤하고 고소한 옥수수이다."; image.sprite = fruit_afters[3]; }
            else if (userInfo.FruitItemkey[i].Equals("dkqhzkeh1")) { Name.text = "아보카도"; Price.text = "570G"; Detail.text = "후숙이 잘 된 부드러운 아보카도이다."; image.sprite = fruit_afters[4]; }
            else if (userInfo.FruitItemkey[i].Equals("Grape")) { Name.text = "포도"; Price.text = "280G"; Detail.text = "보랏빝으로 잘 익은 맛있는 포도이다."; image.sprite = fruit_afters[5]; }
            else if (userInfo.FruitItemkey[i].Equals("lemon1")) { Name.text = "레몬"; Price.text = "800G"; Detail.text = "새콤달콤하게 잘 익은 노란 레몬이다."; image.sprite = fruit_afters[6]; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { Name.text = "천사의 과일"; Price.text = "2,777G"; Detail.text = "신성한 힘이 느껴지는 천사의 과일이다."; image.sprite = fruit_afters[7]; }
            else if (userInfo.FruitItemkey[i].Equals("melon")) { Name.text = "멜론"; Price.text = "600G"; Detail.text = "연두빛으로 잘 익은 달콤한 메론이다."; image.sprite = fruit_afters[8]; }
            else if (userInfo.FruitItemkey[i].Equals("mil1")) { Name.text = "밀"; Price.text = "50G"; Detail.text = "맛있는 걸 잔뜩 만들 수 있을 것 같은 밀이다."; image.sprite = fruit_afters[9]; }
            else if (userInfo.FruitItemkey[i].Equals("pineapple1")) { Name.text = "파인애플"; Price.text = "1,000G"; Detail.text = "상콤달콤 잘 익은 파인애플이다."; image.sprite = fruit_afters[10]; }
            else if (userInfo.FruitItemkey[i].Equals("Potato")) { Name.text = "감자"; Price.text = "195G"; Detail.text = "포슬포슬하게 잘 익을 것 같은 감자이다."; image.sprite = fruit_afters[11]; }
            else if (userInfo.FruitItemkey[i].Equals("Pumpkin")) { Name.text = "호박"; Price.text = "740G"; Detail.text = "몸에 좋은 주황빛 호박이다."; image.sprite = fruit_afters[12]; }
            else if (userInfo.FruitItemkey[i].Equals("rkwl1")) { Name.text = "가지"; Price.text = "480G"; Detail.text = "몸에 아주 좋은 가지이다."; image.sprite = fruit_afters[13]; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { Name.text = "별빛"; Price.text = "3,939G"; Detail.text = "스태리팜의 기운이 담겨있는 별빛 과일이다."; image.sprite = fruit_afters[14]; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { Name.text = "딸기"; Price.text = "770G"; Detail.text = "사랑이 느껴지는 빨간 딸기이다."; image.sprite = fruit_afters[15]; }
            else if (userInfo.FruitItemkey[i].Equals("tnsan1")) { Name.text = "순무"; Price.text = "390G"; Detail.text = "싱싱하고 아삭아삭한 순무이다."; image.sprite = fruit_afters[16]; }
            else if (userInfo.FruitItemkey[i].Equals("Tomato")) { Name.text = "토마토"; Price.text = "450G"; Detail.text = "새빨갛게 잘 익은 맛있는 토마토이다."; image.sprite = fruit_afters[17]; }
            else if (userInfo.FruitItemkey[i].Equals("watermelon")) { Name.text = "수박"; Price.text = "1,200G"; Detail.text = "아주 시원하게 잘 익은 수박이다."; image.sprite = fruit_afters[18]; }
            save_i++;
            save_j++;
        }
        for(int i = 0; i<userInfo.FishItemkey.Count; i++, save_i++, save_j++)
        {
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
            if (userInfo.FishItemkey[i].Equals("평범한물고기")) { Name.text = "평범한 물고기"; Price.text = "250G"; Detail.text = "어디에서나 잡을 수 있을 것 같은 평범한 물고기다."; image.sprite = fishes1[0]; }
            else if (userInfo.FishItemkey[i].Equals("빨강물고기")) { Name.text = "빨강 물고기"; Price.text = "300G"; Detail.text = "붉은빛이 감도는 귀여운 빨강 물고기다."; image.sprite = fishes2[0]; }
            else if (userInfo.FishItemkey[i].Equals("주황물고기")) { Name.text = "주황 물고기"; Price.text = "300G"; Detail.text = "주황빛이 감도는 부드러운 주황 물고기다."; image.sprite = fishes2[1]; }
            else if (userInfo.FishItemkey[i].Equals("노랑물고기")) { Name.text = "노랑 물고기"; Price.text = "400G"; Detail.text = "노란빛이 감도는 상큼한 노랑 물고기다."; image.sprite = fishes3[0]; }
            else if (userInfo.FishItemkey[i].Equals("초록물고기")) { Name.text = "초록 물고기"; Price.text = "400G"; Detail.text = "초록빛이 감도는 건강한 초록 물고기다."; image.sprite = fishes3[1]; }
            else if (userInfo.FishItemkey[i].Equals("남색물고기")) { Name.text = "남색 물고기"; Price.text = "550G"; Detail.text = "남색빛이 감도는 까칠한 남색 물고기다."; image.sprite = fishes4[0]; }
            else if (userInfo.FishItemkey[i].Equals("하늘색물고기")) { Name.text = "하늘색 물고기"; Price.text = "550G"; Detail.text = "하늘빛이 감도는 순수한 하늘색 물고기다."; image.sprite = fishes4[1]; }
            else if (userInfo.FishItemkey[i].Equals("보라물고기")) { Name.text = "보라 물고기"; Price.text = "550G"; Detail.text = "누군갈 떠올리게 하는 듯한 보랏빛 물고기다."; image.sprite = fishes5[0]; }
            else if (userInfo.FishItemkey[i].Equals("의사물고기")) { Name.text = "의사 물고기"; Price.text = "800G"; Detail.text = "물고기들을 치료해줄 것 같은 의사 물고기다."; image.sprite = fishes5[1]; }
            else if (userInfo.FishItemkey[i].Equals("농부물고기")) { Name.text = "농부 물고기"; Price.text = "800G"; Detail.text = "농사를 잘 지을 것 같은 농부 물고기다."; image.sprite = fishes6[0]; }
            else if (userInfo.FishItemkey[i].Equals("무지개물고기")) { Name.text = "무지개 물고기"; Price.text = "1,500G"; Detail.text = "모든 색깔의 기운을 담은 무지개 물고기다."; image.sprite = fishes6[1]; }
            else if (userInfo.FishItemkey[i].Equals("공주물고기")) { Name.text = "공주 물고기"; Price.text = "3,000G"; Detail.text = "물고기 왕국의 막내 딸내미인 공주 물고기다."; image.sprite = fishes7[0]; }
            else if (userInfo.FishItemkey[i].Equals("군인물고기")) { Name.text = "군인 물고기"; Price.text = "3,000G"; Detail.text = "국방의 기운이 느껴지는 군인 물고기다."; image.sprite = fishes7[1]; }
            else if (userInfo.FishItemkey[i].Equals("신부물고기")) { Name.text = "신부 물고기"; Price.text = "3,000G"; Detail.text = "곧 결혼을 앞둔듯한 아름다운 신부 물고기다."; image.sprite = fishes7[2]; }
            else if (userInfo.FishItemkey[i].Equals("신사물고기")) { Name.text = "신사 물고기"; Price.text = "3,000G"; Detail.text = "곧 결혼을 앞둔듯한 젠틀한 신사 물고기다."; image.sprite = fishes7[3]; }
            else if (userInfo.FishItemkey[i].Equals("악마물고기")) { Name.text = "악마 물고기"; Price.text = "5,000G"; Detail.text = "어쩐지 나쁜 기운이 느껴지는 악마 물고기다."; image.sprite = fishes8[0]; }
            else if (userInfo.FishItemkey[i].Equals("천사물고기")) { Name.text = "천사 물고기"; Price.text = "5,000G"; Detail.text = "순수하고 하얀 기운이 가득 담긴 천사 물고기다."; image.sprite = fishes8[1]; }
            else if (userInfo.FishItemkey[i].Equals("스태리팜물고기")) { Name.text = "스태리팜 물고기"; Price.text = "7,000G"; Detail.text = "별빛의 기운이 담긴 스태리팜 물고기다."; image.sprite = fishes9[1]; }
            else if (userInfo.FishItemkey[i].Equals("공대생물고기")) { Name.text = "공대생 물고기"; Price.text = "7,000G"; Detail.text = "개발자의 기운이 담긴 공대생 물고기다."; image.sprite = fishes9[0]; }
            else if (userInfo.FishItemkey[i].Equals("할머니의사랑물고기")) { Name.text = "할머니의사랑 물고기"; Price.text = "100,000G"; Detail.text = "할머니의 사랑이 잔뜩 느껴지는 물고기다."; image.sprite = fishes10[0]; }
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
        select_buy_item = select_buy.text;
        Buy_obj.SetActive(true);
    }

    public void buy_Okay()
    {
        buy_count = int.Parse(input2.text);
        if(select_buy_item.Equals("오르골")) { select_buy_item = "Orgol"; select_buy_item_price = 100000; user_Inven(); }
        else if(select_buy_item.Equals("밀 씨앗")) { select_buy_item = "milSeed"; select_buy_item_price = 30; user_Inven(); }
        else if (select_buy_item.Equals("감자 씨앗")) { select_buy_item = "potatoSeed"; select_buy_item_price = 45; user_Inven(); }
        else if (select_buy_item.Equals("당근 씨앗")) { select_buy_item = "carrotSeed"; select_buy_item_price = 60; user_Inven(); }
        else if (select_buy_item.Equals("옥수수 씨앗")) { select_buy_item = "dhrtntnSeed"; select_buy_item_price = 100; user_Inven(); }
        else if (select_buy_item.Equals("아보카도 씨앗")) { select_buy_item = "dkqhzkehSeed"; select_buy_item_price = 250; user_Inven(); }
        else if (select_buy_item.Equals("포도 씨앗")) { select_buy_item = "GrapeSeed"; select_buy_item_price = 150; user_Inven(); }
        else if (select_buy_item.Equals("레몬 씨앗")) { select_buy_item = "lemonSeed"; select_buy_item_price = 500; user_Inven(); }
        else if (select_buy_item.Equals("블루베리 씨앗")) { select_buy_item = "blueberrySeed"; select_buy_item_price = 350; user_Inven(); }
        else if (select_buy_item.Equals("멜론 씨앗")) { select_buy_item = "melonSeed"; select_buy_item_price = 220; user_Inven(); }
        else if (select_buy_item.Equals("파인애플 씨앗")) { select_buy_item = "pineappleSeed"; select_buy_item_price = 450; user_Inven(); }
        else if (select_buy_item.Equals("호박 씨앗")) { select_buy_item = "pumpkinSeed"; select_buy_item_price = 320; user_Inven(); }
        else if (select_buy_item.Equals("가지 씨앗")) { select_buy_item = "rkwlSeed"; select_buy_item_price = 80; user_Inven(); }
        else if (select_buy_item.Equals("딸기 씨앗")) { select_buy_item = "strawberrySeed"; select_buy_item_price = 420; user_Inven(); }
        else if (select_buy_item.Equals("순무 씨앗")) { select_buy_item = "tnsanSeed"; select_buy_item_price = 170; user_Inven(); }
        else if (select_buy_item.Equals("토마토 씨앗")) { select_buy_item = "tomatoSeed"; select_buy_item_price = 200; user_Inven(); }
        else if (select_buy_item.Equals("수박 씨앗")) { select_buy_item = "watermelonSeed"; select_buy_item_price = 480; user_Inven(); }
        else if (select_buy_item.Equals("악마의 과일 씨앗")) { select_buy_item = "darkSeed"; select_buy_item_price = 666; user_Inven(); }
        else if (select_buy_item.Equals("천사의 과일 씨앗")) { select_buy_item = "lightSeed"; select_buy_item_price = 777; user_Inven(); }
        else if (select_buy_item.Equals("별빛 과일 씨앗")) { select_buy_item = "starrySeed"; select_buy_item_price = 999; user_Inven(); }
    }
    
    void user_Inven()
    {
        int userGold = userInfo.getGold();
        if (userGold > select_buy_item_price * buy_count && buy_count != 0)
        {
            userInfo.setGold(userGold - select_buy_item_price * buy_count);
            Text UIGold = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
            UIGold.text = userInfo.getGold().ToString();

            if (select_buy_item.Equals("Orgol"))
            {
                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    if (userInfo.StoryItemkey[i].Equals(select_buy_item))
                    {
                        story_count = userInfo.StoryItem[select_buy_item];
                        isSamekey = true;
                    }
                }
                story_count = story_count + buy_count;
                if (!isSamekey)
                {
                    userInfo.StoryItemkey.Add(select_buy_item);
                    userInfo.StoryItem.Add(select_buy_item, story_count);
                }
                userInfo.StoryItem[select_buy_item] = story_count;
                isSamekey = false;
                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;

                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;
                    Image seedimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { seedimg.sprite = seeds[10]; }
                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Storytext = text.GetComponent<Text>();
                    Storytext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                    story_count = 0;
                    Buy_obj.SetActive(false);
                }
                return;
            }

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
                GameObject Image = bottonobj.transform.GetChild(0).gameObject;
                Image seedimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                if (userInfo.SeedItemkey[i].Equals("milSeed")) { seedimg.sprite = seeds[9]; }
                else if (userInfo.SeedItemkey[i].Equals("potatoSeed")) { seedimg.sprite = seeds[12]; }
                else if (userInfo.SeedItemkey[i].Equals("carrotSeed")) { seedimg.sprite = seeds[1]; }
                else if (userInfo.SeedItemkey[i].Equals("dhrtntnSeed")) { seedimg.sprite = seeds[3]; }
                else if (userInfo.SeedItemkey[i].Equals("dkqhzkehSeed")) { seedimg.sprite = seeds[4]; }
                else if (userInfo.SeedItemkey[i].Equals("GrapeSeed")) { seedimg.sprite = seeds[5]; }
                else if (userInfo.SeedItemkey[i].Equals("lemonSeed")) { seedimg.sprite = seeds[6]; }
                else if (userInfo.SeedItemkey[i].Equals("blueberrySeed")) { seedimg.sprite = seeds[0]; }
                else if (userInfo.SeedItemkey[i].Equals("melonSeed")) { seedimg.sprite = seeds[8]; }
                else if (userInfo.SeedItemkey[i].Equals("pineappleSeed")) { seedimg.sprite = seeds[11]; }
                else if (userInfo.SeedItemkey[i].Equals("pumpkinSeed")) { seedimg.sprite = seeds[13]; }
                else if (userInfo.SeedItemkey[i].Equals("rkwlSeed")) { seedimg.sprite = seeds[14]; }
                else if (userInfo.SeedItemkey[i].Equals("strawberrySeed")) { seedimg.sprite = seeds[16]; }
                else if (userInfo.SeedItemkey[i].Equals("tnsanSeed")) { seedimg.sprite = seeds[17]; }
                else if (userInfo.SeedItemkey[i].Equals("tomatoSeed")) { seedimg.sprite = seeds[18]; }
                else if (userInfo.SeedItemkey[i].Equals("watermelonSeed")) { seedimg.sprite = seeds[19]; }
                else if (userInfo.SeedItemkey[i].Equals("darkSeed")) { seedimg.sprite = seeds[2]; }
                else if (userInfo.SeedItemkey[i].Equals("lightSeed")) { seedimg.sprite = seeds[7]; }
                else if (userInfo.SeedItemkey[i].Equals("starrySeed")) { seedimg.sprite = seeds[15]; }
                Image.SetActive(true);
                GameObject text = bottonobj.transform.GetChild(1).gameObject;
                Text Seedtext = text.GetComponent<Text>(); // 과일 개수
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
        if (select_delete_item.Equals("블루베리")) { Delete_Item_Fruit("Blueberry", 520); }
        else if (select_delete_item.Equals("당근")) { Delete_Item_Fruit("carrot", 110); }
        else if (select_delete_item.Equals("악마의 과일")) { Delete_Item_Fruit("DARK", 2666); }
        else if (select_delete_item.Equals("옥수수")) { Delete_Item_Fruit("dhrtntn1", 290); }
        else if (select_delete_item.Equals("아보카도")) { Delete_Item_Fruit("dkqhzkeh1", 570); }
        else if (select_delete_item.Equals("포도")) { Delete_Item_Fruit("Grape", 280); }
        else if (select_delete_item.Equals("레몬")) { Delete_Item_Fruit("lemon1", 800); }
        else if (select_delete_item.Equals("천사의 과일")) { Delete_Item_Fruit("LIGHT",2777); }
        else if (select_delete_item.Equals("멜론")) { Delete_Item_Fruit("melon",600); }
        else if (select_delete_item.Equals("밀")) { Delete_Item_Fruit("mil1",50); }
        else if (select_delete_item.Equals("파인애플")) { Delete_Item_Fruit("pineapple1",1000); }
        else if (select_delete_item.Equals("감자")) { Delete_Item_Fruit("Potato",195); }
        else if (select_delete_item.Equals("호박")) { Delete_Item_Fruit("Pumpkin",740); }
        else if (select_delete_item.Equals("가지")) { Delete_Item_Fruit("rkwl1",480); }
        else if (select_delete_item.Equals("별빛")) { Delete_Item_Fruit("starry",3939); }
        else if (select_delete_item.Equals("딸기")) { Delete_Item_Fruit("Strawberry",770); }
        else if (select_delete_item.Equals("순무")) { Delete_Item_Fruit("tnsan1",390); }
        else if (select_delete_item.Equals("토마토")) { Delete_Item_Fruit("Tomato",450); }
        else if (select_delete_item.Equals("수박")) { Delete_Item_Fruit("watermelon",1200); }

        if (select_delete_item.Equals("평범한 물고기")) { 
            Delete_Item_Fish("평범한물고기", 50);

            userInfo.grandmaFish++;
            if (userInfo.grandmaFish == 1)
            {
                talkManager.talking.Add("seller", new string[] {
            "...너는 참 너희 할머니를 많이 닮은 것 같아.:0",
            "이 물고기를 내게 줬다는 건, 나한테도 변화가 필요하다는 거겠지.:0",
            "이제는 나도, 너를 용서할 때가 된 것 같아... 자, 이걸 받아.:0",
            "[보라색 리본이 달린 할머니의 밀짚모자를 받았습니다.]:0",
            "그리고, 하나 더 유용한 걸 알려줄게.\n슬라임 던전 아주 깊은 곳에 있는 몬스터를 잡으면 누군가의 혼이 깃든 '무언가'가 나온대.:0",
            "네게 아주 필요할지도 몰라.\n아무튼, 앞으로도 우리 가게 많이 와줘. 잘 지내자.:0"});

   
                //인벤토리에 밀짚모자 넣기
                userInfo.StoryItemkey.Add("할머니의 밀짚모자");
                userInfo.StoryItem.Add("할머니의 밀짚모자", 1);

                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;

                    Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
                    else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { keyimg.sprite = special[0]; }
                    else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { keyimg.sprite = special[1]; }
                    else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { keyimg.sprite = special[2]; }
                    else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { keyimg.sprite = special[3]; }
                    else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { keyimg.sprite = special[4]; }
                    else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { keyimg.sprite = special[5]; }
                    else if (userInfo.StoryItemkey[i].Equals("곰인형")) { keyimg.sprite = special[6]; }


                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Hattext = text.GetComponent<Text>();
                    Hattext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                }

             
            }

        }
        else if (select_delete_item.Equals("빨강 물고기")) {
            Delete_Item_Fish("빨강물고기", 130);

            userInfo.grandmaFish++;
            if (userInfo.grandmaFish == 1)
            {
                talkManager.talking.Add("seller", new string[] {
            "...너는 참 너희 할머니를 많이 닮은 것 같아.:0",
            "이 물고기를 내게 줬다는 건, 나한테도 변화가 필요하다는 거겠지.:0",
            "이제는 나도, 너를 용서할 때가 된 것 같아... 자, 이걸 받아.:0",
            "[보라색 리본이 달린 할머니의 밀짚모자를 받았습니다.]:0",
            "그리고, 하나 더 유용한 걸 알려줄게.\n슬라임 던전 아주 깊은 곳에 있는 몬스터를 잡으면 누군가의 혼이 깃든 '무언가'가 나온대.:0",
            "네게 아주 필요할지도 몰라.\n아무튼, 앞으로도 우리 가게 많이 와줘. 잘 지내자.:0"});


                //인벤토리에 밀짚모자 넣기
                userInfo.StoryItemkey.Add("할머니의 밀짚모자");
                userInfo.StoryItem.Add("할머니의 밀짚모자", 1);

                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;

                    Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
                    else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { keyimg.sprite = special[0]; }
                    else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { keyimg.sprite = special[1]; }
                    else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { keyimg.sprite = special[2]; }
                    else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { keyimg.sprite = special[3]; }
                    else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { keyimg.sprite = special[4]; }
                    else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { keyimg.sprite = special[5]; }
                    else if (userInfo.StoryItemkey[i].Equals("곰인형")) { keyimg.sprite = special[6]; }


                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Hattext = text.GetComponent<Text>();
                    Hattext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                }

          
            }


        }
        else if (select_delete_item.Equals("주황 물고기")) {
            Delete_Item_Fish("주황물고기", 150);

            userInfo.grandmaFish++;
            if (userInfo.grandmaFish == 1)
            {
                talkManager.talking.Add("seller", new string[] {
            "...너는 참 너희 할머니를 많이 닮은 것 같아.:0",
            "이 물고기를 내게 줬다는 건, 나한테도 변화가 필요하다는 거겠지.:0",
            "이제는 나도, 너를 용서할 때가 된 것 같아... 자, 이걸 받아.:0",
            "[보라색 리본이 달린 할머니의 밀짚모자를 받았습니다.]:0",
            "그리고, 하나 더 유용한 걸 알려줄게.\n슬라임 던전 아주 깊은 곳에 있는 몬스터를 잡으면 누군가의 혼이 깃든 '무언가'가 나온대.:0",
            "네게 아주 필요할지도 몰라.\n아무튼, 앞으로도 우리 가게 많이 와줘. 잘 지내자.:0"});

           

                //인벤토리에 밀짚모자 넣기
                userInfo.StoryItemkey.Add("할머니의 밀짚모자");
                userInfo.StoryItem.Add("할머니의 밀짚모자", 1);

                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;

                    Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
                    else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { keyimg.sprite = special[0]; }
                    else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { keyimg.sprite = special[1]; }
                    else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { keyimg.sprite = special[2]; }
                    else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { keyimg.sprite = special[3]; }
                    else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { keyimg.sprite = special[4]; }
                    else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { keyimg.sprite = special[5]; }
                    else if (userInfo.StoryItemkey[i].Equals("곰인형")) { keyimg.sprite = special[6]; }


                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Hattext = text.GetComponent<Text>();
                    Hattext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                }

            }

        }
        else if (select_delete_item.Equals("노랑 물고기")) {
            Delete_Item_Fish("노랑물고기", 200);

            userInfo.grandmaFish++;
            if (userInfo.grandmaFish == 1)
            {
                talkManager.talking.Add("seller", new string[] {
            "...너는 참 너희 할머니를 많이 닮은 것 같아.:0",
            "이 물고기를 내게 줬다는 건, 나한테도 변화가 필요하다는 거겠지.:0",
            "이제는 나도, 너를 용서할 때가 된 것 같아... 자, 이걸 받아.:0",
            "[보라색 리본이 달린 할머니의 밀짚모자를 받았습니다.]:0",
            "그리고, 하나 더 유용한 걸 알려줄게.\n슬라임 던전 아주 깊은 곳에 있는 몬스터를 잡으면 누군가의 혼이 깃든 '무언가'가 나온대.:0",
            "네게 아주 필요할지도 몰라.\n아무튼, 앞으로도 우리 가게 많이 와줘. 잘 지내자.:0"});


                //인벤토리에 밀짚모자 넣기
                userInfo.StoryItemkey.Add("할머니의 밀짚모자");
                userInfo.StoryItem.Add("할머니의 밀짚모자", 1);

                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;

                    Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
                    else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { keyimg.sprite = special[0]; }
                    else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { keyimg.sprite = special[1]; }
                    else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { keyimg.sprite = special[2]; }
                    else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { keyimg.sprite = special[3]; }
                    else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { keyimg.sprite = special[4]; }
                    else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { keyimg.sprite = special[5]; }
                    else if (userInfo.StoryItemkey[i].Equals("곰인형")) { keyimg.sprite = special[6]; }


                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Hattext = text.GetComponent<Text>();
                    Hattext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                }

             
            }


        }
        else if (select_delete_item.Equals("초록 물고기")) { Delete_Item_Fish("초록물고기", 230); 
        }
        else if (select_delete_item.Equals("남색 물고기")) { Delete_Item_Fish("남색물고기", 300); }
        else if (select_delete_item.Equals("하늘색 물고기")) { Delete_Item_Fish("하늘색물고기", 250); }
        else if (select_delete_item.Equals("보라 물고기")) { Delete_Item_Fish("보라물고기", 320); }
        else if (select_delete_item.Equals("의사 물고기")) { Delete_Item_Fish("의사물고기", 450); }
        else if (select_delete_item.Equals("농부 물고기")) { Delete_Item_Fish("농부물고기", 530); }
        else if (select_delete_item.Equals("무지개 물고기")) { Delete_Item_Fish("무지개물고기", 620); }
        else if (select_delete_item.Equals("공주 물고기")) { Delete_Item_Fish("공주물고기", 800); }
        else if (select_delete_item.Equals("군인 물고기")) { Delete_Item_Fish("군인물고기", 750); }
        else if (select_delete_item.Equals("신부 물고기")) { Delete_Item_Fish("신부물고기", 1234); }
        else if (select_delete_item.Equals("신사 물고기")) { Delete_Item_Fish("신사물고기", 1234); }
        else if (select_delete_item.Equals("악마 물고기")) { Delete_Item_Fish("악마물고기", 2666); }
        else if (select_delete_item.Equals("천사 물고기")) { Delete_Item_Fish("천사물고기", 2777); }
        else if (select_delete_item.Equals("스태리팜 물고기")) { Delete_Item_Fish("스태리팜물고기", 5959); }
        else if (select_delete_item.Equals("공대생 물고기")) { Delete_Item_Fish("공대생물고기", 3999); }
        else if (select_delete_item.Equals("할머니의사랑 물고기"))
        {
            Delete_Item_Fish("할머니의사랑물고기", 10000);

            userInfo.grandmaFish++;
            if (userInfo.grandmaFish == 1)
            {
                talkManager.talking.Add("seller", new string[] {
            "...너는 참 너희 할머니를 많이 닮은 것 같아.:0",
            "이 물고기를 내게 줬다는 건, 나한테도 변화가 필요하다는 거겠지.:0",
            "이제는 나도, 너를 용서할 때가 된 것 같아... 자, 이걸 받아.:0",
            "[보라색 리본이 달린 할머니의 밀짚모자를 받았습니다.]:0",
            "그리고, 하나 더 유용한 걸 알려줄게.\n슬라임 던전 아주 깊은 곳에 있는 몬스터를 잡으면 누군가의 혼이 깃든 '무언가'가 나온대.:0",
            "네게 아주 필요할지도 몰라.\n아무튼, 앞으로도 우리 가게 많이 와줘. 잘 지내자.:0"});


                //인벤토리에 밀짚모자 넣기
                userInfo.StoryItemkey.Add("할머니의 밀짚모자");
                userInfo.StoryItem.Add("할머니의 밀짚모자", 1);

                for (int i = 0; i < userInfo.StoryItemkey.Count; i++)
                {
                    GameObject bottonobj = menuControl.InventoryStory.transform.GetChild(i).gameObject;
                    bottonobj.SetActive(true);
                    Image bottonimg = bottonobj.GetComponent<Image>();
                    GameObject Image = bottonobj.transform.GetChild(0).gameObject;

                    Image keyimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
                    if (userInfo.StoryItemkey[i].Equals("Orgol")) { keyimg.sprite = spec_orgol[10]; }
                    else if (userInfo.StoryItemkey[i].Equals("하늘색 열쇠")) { keyimg.sprite = special[0]; }
                    else if (userInfo.StoryItemkey[i].Equals("최종 열쇠")) { keyimg.sprite = special[1]; }
                    else if (userInfo.StoryItemkey[i].Equals("초록색 열쇠")) { keyimg.sprite = special[2]; }
                    else if (userInfo.StoryItemkey[i].Equals("할머니의 밀짚모자")) { keyimg.sprite = special[3]; }
                    else if (userInfo.StoryItemkey[i].Equals("분홍색 열쇠")) { keyimg.sprite = special[4]; }
                    else if (userInfo.StoryItemkey[i].Equals("보라색 열쇠")) { keyimg.sprite = special[5]; }
                    else if (userInfo.StoryItemkey[i].Equals("곰인형")) { keyimg.sprite = special[6]; }


                    Image.SetActive(true);
                    GameObject text = bottonobj.transform.GetChild(1).gameObject;
                    Text Hattext = text.GetComponent<Text>();
                    Hattext.text = userInfo.StoryItem[userInfo.StoryItemkey[i]].ToString();
                    text.SetActive(true);
                }

            }
        
        }
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
                bottonimg.sprite = invens[1] as Sprite; // 인벤 선택
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
            Text Fruittext = text.GetComponent<Text>(); // 과일 개수
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
                bottonimg.sprite = invens[1] as Sprite; // 인벤 선택
            }
            GameObject Image = bottonobj.transform.GetChild(0).gameObject;
            Image Fishimg = bottonobj.transform.GetChild(0).GetComponent<Image>();
            if (userInfo.FishItemkey[i].Equals("평범한물고기")) { Fishimg.sprite = fishes1[0]; }
            else if (userInfo.FishItemkey[i].Equals("빨강물고기")) { Fishimg.sprite = fishes2[0]; }
            else if (userInfo.FishItemkey[i].Equals("주황물고기")) { Fishimg.sprite = fishes2[1]; }
            else if (userInfo.FishItemkey[i].Equals("노랑물고기")) { Fishimg.sprite = fishes3[0]; }
            else if (userInfo.FishItemkey[i].Equals("초록물고기")) { Fishimg.sprite = fishes3[1]; }
            else if (userInfo.FishItemkey[i].Equals("남색물고기")) { Fishimg.sprite = fishes4[0]; }
            else if (userInfo.FishItemkey[i].Equals("하늘색물고기")) { Fishimg.sprite = fishes4[1]; }
            else if (userInfo.FishItemkey[i].Equals("보라물고기")) { Fishimg.sprite = fishes5[0]; }
            else if (userInfo.FishItemkey[i].Equals("의사물고기")) { Fishimg.sprite = fishes5[1]; }
            else if (userInfo.FishItemkey[i].Equals("농부물고기")) { Fishimg.sprite = fishes6[0]; }
            else if (userInfo.FishItemkey[i].Equals("무지개물고기")) { Fishimg.sprite = fishes6[1]; }
            else if (userInfo.FishItemkey[i].Equals("공주물고기")) { Fishimg.sprite = fishes7[0]; }
            else if (userInfo.FishItemkey[i].Equals("군인물고기")) { Fishimg.sprite = fishes7[1]; }
            else if (userInfo.FishItemkey[i].Equals("신부물고기")) { Fishimg.sprite = fishes7[2]; }
            else if (userInfo.FishItemkey[i].Equals("신사물고기")) { Fishimg.sprite = fishes7[3]; }
            else if (userInfo.FishItemkey[i].Equals("악마물고기")) { Fishimg.sprite = fishes8[0]; }
            else if (userInfo.FishItemkey[i].Equals("천사물고기")) { Fishimg.sprite = fishes8[1]; }
            else if (userInfo.FishItemkey[i].Equals("스태리팜물고기")) { Fishimg.sprite = fishes9[1]; }
            else if (userInfo.FishItemkey[i].Equals("공대생물고기")) { Fishimg.sprite = fishes9[0]; }
            else if (userInfo.FishItemkey[i].Equals("할머니의사랑물고기")) { Fishimg.sprite = fishes10[0]; }
            Image.SetActive(true);
            GameObject text = bottonobj.transform.GetChild(1).gameObject;
            Text Fishtext = text.GetComponent<Text>(); // 과일 개수
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
                for (int i = 0; i < Parent.transform.childCount; i++) // 모든 오브젝트 파괴
                {
                    Destroy(Parent.GetChild(i).gameObject);
                }
            isfirst = false;
                OpenSale(); // 다시 구성
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
                for (int i = 0; i < Parent.transform.childCount; i++) // 모든 오브젝트 파괴
                {
                    Destroy(Parent.GetChild(i).gameObject);
                }
            isfirst = false;
            OpenSale(); // 다시 구성
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
        if (sale_count > 0)
        {
            sale_count--;
            input.text = sale_count.ToString();
        }
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
        if (buy_count > 0)
        {
            buy_count--;
            input2.text = buy_count.ToString();
        }
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
