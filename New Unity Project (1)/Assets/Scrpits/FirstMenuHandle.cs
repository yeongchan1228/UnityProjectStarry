using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FirstMenuHandle : MonoBehaviour
{
    UserInfo userInfo;
    PlayerController player;
    // Start is called before the first frame update
    public Sprite[] fruit_afters, invens, seeds, swords, tools, seeds2, fruit_befores;
    private Sprite[] fishes1, fishes2, fishes3, fishes4, fishes5, fishes6, fishes7, fishes8, fishes9, fishes10;
    Sprite[] spec_orgol;
    Sprite[] special;

    void Start()
    {
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        seeds = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        seeds2 = Resources.LoadAll<Sprite>("Sprites/Seed");
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
        fruit_befores = Resources.LoadAll<Sprite>("Sprites/Fruit/before");
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
        spec_orgol = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        special = Resources.LoadAll<Sprite>("Sprites/Final");
    }

    // Update is called once per frame

    public void GameLoad() // ���� ������ �ҷ�����
    {
        MenuControl menu = GameObject.Find("MenuManager").GetComponent<MenuControl>();
        menu.issave = true;
        
        //user Item ����
        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        int Day = PlayerPrefs.GetInt("Day");
        int CheckDay = PlayerPrefs.GetInt("CheckDay");
        int Gold = PlayerPrefs.GetInt("Gold");
        int Hp = PlayerPrefs.GetInt("Hp");
        int MaxHp = PlayerPrefs.GetInt("MaxHp");
        int Level = PlayerPrefs.GetInt("Level");
        int Exp = PlayerPrefs.GetInt("Exp");
        string Name = PlayerPrefs.GetString("Name");
        string FarmName = PlayerPrefs.GetString("FarmName");
        string gender = PlayerPrefs.GetString("Gender");
        string Weapon_name = PlayerPrefs.GetString("Weapon_Name");
        int Weapon_Power = PlayerPrefs.GetInt("Weapon_Power");
        string Hoe_name = PlayerPrefs.GetString("Hoe_Name");
        float Hoe_Speed = PlayerPrefs.GetFloat("Hoe_Speed");
        string FishingRod_name = PlayerPrefs.GetString("FishingRod_Name");
        float FishingRod_Efficiency = PlayerPrefs.GetFloat("FishingRod_Efficiency");
        string WaterPPU_name = PlayerPrefs.GetString("WaterPPU_Name");
        int WaterPPU_Filled = PlayerPrefs.GetInt("WaterPPU_Filled");

        if (gender.Equals("man")) // ����
        {
            GameObject user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
            player = user_man.GetComponent<PlayerController>();
            userInfo = user_man.GetComponent<UserInfo>();
            userInfo.isTrue = true;
            user_man.SetActive(true);
            player.SetStartXY(x, y);
            userInfo.setDay(Day);
            userInfo.setCheckDay(CheckDay);
            userInfo.setGold(Gold);
            userInfo.setHp(Hp);
            userInfo.setMaxHp(MaxHp);
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            userInfo.setName(Name);
            userInfo.setFarmName(FarmName);
        }
        else // ����
        {
            GameObject user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
            player = user_woman.GetComponent<PlayerController>();
            userInfo = user_woman.GetComponent<UserInfo>();
            userInfo.isTrue = true;
            user_woman.SetActive(true);
            player.SetStartXY(x, y);
            userInfo.setDay(Day);
            userInfo.setCheckDay(CheckDay);
            userInfo.setGold(Gold);
            userInfo.setHp(Hp);
            userInfo.setMaxHp(MaxHp);
            userInfo.setLevel(Level);
            userInfo.setExp(Exp);
            userInfo.setName(Name);
            userInfo.setFarmName(FarmName);
        }
        userInfo.getItem_Weapon().SetWeaponName(Weapon_name);
        userInfo.getItem_Weapon().SetWeaponPower(Weapon_Power);
        userInfo.getItem_Hoe().SetHoeName(Hoe_name);
        userInfo.getItem_Hoe().SetHoeSpeed(Hoe_Speed);
        userInfo.getItem_FishingRod().SetFishingRodName(FishingRod_name);
        userInfo.getItem_FishingRod().SetFishingRodEfficiency(FishingRod_Efficiency);
        userInfo.getItem_WaterPPU().SetWaterPPUName(WaterPPU_name);
        userInfo.getItem_WaterPPU().SetWaterPPUFilled(WaterPPU_Filled);
        userInfo.storycounter++;
        GameObject PlayerUI = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
        GameObject Inventory = GameObject.Find("Canvas").transform.GetChild(4).gameObject;
        //////���� ���� UI ���
        Text HPUI = PlayerUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        Text DayUI = PlayerUI.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        Text GoldUI = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
        Text LEVELUI = PlayerUI.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>();
        HPUI.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
        if(userInfo.getCheckDay() < 31) { DayUI.text = "��, " + userInfo.getDay() + "��"; }
        else if (userInfo.getCheckDay() < 61) { DayUI.text = "����, " + userInfo.getDay() + "��"; }
        else if (userInfo.getCheckDay() < 91) { DayUI.text = "����, " + userInfo.getDay() + "��"; }
        else if (userInfo.getCheckDay() < 121) { DayUI.text = "�ܿ�, " + userInfo.getDay() + "��"; }
        GoldUI.text = userInfo.getGold().ToString();
        LEVELUI.text = "Lv. " + userInfo.getLevel();
        ///////���� UI ���
        GameObject PlayerUI_Weapon = PlayerUI.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject;
        Image Weapon_img = PlayerUI_Weapon.GetComponent<Image>();
        if (userInfo.getItem_Weapon().GetWeaponName().Equals("rustysword")) { Weapon_img.sprite = swords[6] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("woodsword")) { Weapon_img.sprite = swords[9] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("steelsword")) { Weapon_img.sprite = swords[8] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("silversword")) { Weapon_img.sprite = swords[7] as Sprite; ; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("cutlass")) { Weapon_img.sprite = swords[0] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("darksword")) { Weapon_img.sprite = swords[1] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("obsidian")) { Weapon_img.sprite = swords[5] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("holysword")) { Weapon_img.sprite = swords[3] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("lavasword")) { Weapon_img.sprite = swords[4] as Sprite; }
        else if (userInfo.getItem_Weapon().GetWeaponName().Equals("galaxysword")) { Weapon_img.sprite = swords[2] as Sprite; }
        PlayerUI_Weapon.SetActive(true);

        /////////��� ����â ��� 
        if (PlayerPrefs.HasKey("Armor_Name"))
        {
            string Armor_name = PlayerPrefs.GetString("Armor_Name");
            int Armor_Power = PlayerPrefs.GetInt("Armor_Power");
            userInfo.getItem_Armor().SetArmorName(Armor_name);
            userInfo.getItem_Armor().SetArmorPower(Armor_Power);
            Text Armortext = Inventory.transform.GetChild(9).transform.GetChild(6).GetComponent<Text>();
            Armortext.text = "���� : " + userInfo.getItem_Armor().GetArmorPower();
        }

        ////////ȣ�� UI ���
        GameObject PlayerUI_Hoe = PlayerUI.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject;
        Image Hoe_img = PlayerUI_Hoe.GetComponent<Image>();
        if (userInfo.getItem_Hoe().GetHoeName().Equals("Stone_Hoe")) { Hoe_img.sprite = tools[13] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Guri_Hoe")) { Hoe_img.sprite = tools[4] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Silver_Hoe")) { Hoe_img.sprite = tools[10] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Iridium_Hoe")) { Hoe_img.sprite = tools[7] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Dia_Hoe")) { Hoe_img.sprite = tools[1] as Sprite; }
        PlayerUI_Hoe.SetActive(true);

        ////////���ô� UI ���
        GameObject PlayerUI_Fish = PlayerUI.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).gameObject;
        Image Fish_img = PlayerUI_Fish.GetComponent<Image>();
        if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Stone_FishingRod")) { Fish_img.sprite = tools[11] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Guri_FishingRod")) { Fish_img.sprite = tools[2] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Silver_FishingRod")) { Fish_img.sprite = tools[8] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Iridium_FishingRod")) { Fish_img.sprite = tools[5] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Dia_FishingRod")) { Fish_img.sprite = tools[0] as Sprite; }
        PlayerUI_Fish.SetActive(true);

        ////////���Ѹ��� UI ���
        GameObject PlayerUI_Water = PlayerUI.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).gameObject;
        Image Water_img = PlayerUI_Water.GetComponent<Image>();
        if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Stone_Water")) { Water_img.sprite = tools[14] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Guri_Water")) { Water_img.sprite = tools[15] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Silver_Water")) { Water_img.sprite = tools[18] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Iridium_Water")) { Water_img.sprite = tools[17] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Dia_Water")) { Water_img.sprite = tools[16] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Dia_FishingRod")) { Fish_img.sprite = tools[0] as Sprite; }
        PlayerUI_Water.SetActive(true);

        ///////// �κ� UI �� ä��� ��������
        if (userInfo.getGender().Equals("man"))
        {
            GameObject maninfo = Inventory.transform.GetChild(9).transform.GetChild(0).gameObject;
            GameObject womaninfo = Inventory.transform.GetChild(9).transform.GetChild(1).gameObject;
            maninfo.SetActive(true);
            womaninfo.SetActive(false);
        }
        else
        {
            GameObject maninfo = Inventory.transform.GetChild(9).transform.GetChild(0).gameObject;
            GameObject womaninfo = Inventory.transform.GetChild(9).transform.GetChild(1).gameObject;
            maninfo.SetActive(false);
            womaninfo.SetActive(true);
        }
        userInfo.setExpInfo();
        userInfo.setNameInfo();
        userInfo.setFarmNameInfo();
        userInfo.setWeapon_powerInfo();
        userInfo.setArmor_powerInfo();


        ////////�κ��丮 ���� ä���
        Image Seedimg = Inventory.transform.GetChild(1).GetComponent<Image>();
        Image Fishimg = Inventory.transform.GetChild(3).GetComponent<Image>();
        Image Fruitimg = Inventory.transform.GetChild(2).GetComponent<Image>();
        Image Storyimg = Inventory.transform.GetChild(11).GetComponent<Image>();
        Seedimg.sprite = invens[2] as Sprite;
        Fishimg.sprite = invens[3] as Sprite;
        Fruitimg.sprite = invens[3] as Sprite;
        Storyimg.sprite = invens[3] as Sprite;
        menu.isSeed = true;
        menu.isFish = false;
        menu.isFruit = false;
        menu.isStory = false;
        int seeditemcount = PlayerPrefs.GetInt("SeedItemCount");
        int fishitemcount = PlayerPrefs.GetInt("FishItemCount");
        int fruititemcount = PlayerPrefs.GetInt("FruitItemCount");
        int storyitemcount = PlayerPrefs.GetInt("StoryItemCount");

        ///////���� �� ���� �޾ƿ���
        for (int i = 0; i < seeditemcount; i++)
        {
            userInfo.SeedItemkey.Add(PlayerPrefs.GetString("SeedItem" + i));
            userInfo.SeedItem.Add(PlayerPrefs.GetString("SeedItemKey" + i), PlayerPrefs.GetInt("SeedItemValue"+i));
        }

        ///////���� �� �κ��� �ֱ�
        GameObject InventorySeed = Inventory.transform.GetChild(6).gameObject;
        for (int i = 0; i < seeditemcount; i++)
        {
            GameObject Seedimg_On = InventorySeed.transform.GetChild(i).transform.GetChild(0).gameObject;
            Image seedimg = InventorySeed.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
            GameObject Seedcount_On = InventorySeed.transform.GetChild(i).transform.GetChild(1).gameObject;
            Text seedtext = InventorySeed.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>();
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
            seedtext.text = userInfo.SeedItem[userInfo.SeedItemkey[i]].ToString();
            Seedimg_On.SetActive(true);
            Seedcount_On.SetActive(true);
        }


        ///////���� ���� �޾ƿ���
        for (int i = 0; i < fruititemcount; i++)
        {
            userInfo.FruitItemkey.Add(PlayerPrefs.GetString("FruitItem" + i));
            userInfo.FruitItem.Add(PlayerPrefs.GetString("FruitItemKey" + i), PlayerPrefs.GetInt("FruitItemValue" + i));
        }

        ////////���� �κ��� �ֱ�
        GameObject InventoryFruit = Inventory.transform.GetChild(7).gameObject;
        for (int i = 0; i < fruititemcount; i++)
        {
            GameObject Fruitimg_On = InventoryFruit.transform.GetChild(i).transform.GetChild(0).gameObject;
            Image fruitimg = InventoryFruit.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
            GameObject Fruitcount_On = InventoryFruit.transform.GetChild(i).transform.GetChild(1).gameObject;
            Text fruittext = InventoryFruit.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>();
            if (userInfo.FruitItemkey[i].Equals("Blueberry")) { fruitimg.sprite = fruit_afters[0]; }
            else if (userInfo.FruitItemkey[i].Equals("carrot")) { fruitimg.sprite = fruit_afters[1]; }
            else if (userInfo.FruitItemkey[i].Equals("DARK")) { fruitimg.sprite = fruit_afters[2]; }
            else if (userInfo.FruitItemkey[i].Equals("dhrtntn1")) { fruitimg.sprite = fruit_afters[3]; }
            else if (userInfo.FruitItemkey[i].Equals("dkqhzkeh1")) { fruitimg.sprite = fruit_afters[4]; }
            else if (userInfo.FruitItemkey[i].Equals("Grape")) { fruitimg.sprite = fruit_afters[5]; }
            else if (userInfo.FruitItemkey[i].Equals("lemon1")) { fruitimg.sprite = fruit_afters[6]; }
            else if (userInfo.FruitItemkey[i].Equals("LIGHT")) { fruitimg.sprite = fruit_afters[7]; }
            else if (userInfo.FruitItemkey[i].Equals("melon")) { fruitimg.sprite = fruit_afters[8]; }
            else if (userInfo.FruitItemkey[i].Equals("mil1")) { fruitimg.sprite = fruit_afters[9]; }
            else if (userInfo.FruitItemkey[i].Equals("pineapple1")) { fruitimg.sprite = fruit_afters[10]; }
            else if (userInfo.FruitItemkey[i].Equals("Potato")) { fruitimg.sprite = fruit_afters[11]; }
            else if (userInfo.FruitItemkey[i].Equals("Pumpkin")) { fruitimg.sprite = fruit_afters[12]; }
            else if (userInfo.FruitItemkey[i].Equals("rkwl1")) { fruitimg.sprite = fruit_afters[13]; }
            else if (userInfo.FruitItemkey[i].Equals("starry")) { fruitimg.sprite = fruit_afters[14]; }
            else if (userInfo.FruitItemkey[i].Equals("Strawberry")) { fruitimg.sprite = fruit_afters[15]; }
            else if (userInfo.FruitItemkey[i].Equals("tnsan1")) { fruitimg.sprite = fruit_afters[16]; }
            else if (userInfo.FruitItemkey[i].Equals("Tomato")) { fruitimg.sprite = fruit_afters[17]; }
            else if (userInfo.FruitItemkey[i].Equals("watermelon")) { fruitimg.sprite = fruit_afters[18]; }
            fruittext.text = userInfo.FruitItem[userInfo.FruitItemkey[i]].ToString();
            Fruitimg_On.SetActive(true);
            Fruitcount_On.SetActive(true);
        }


        ///////����� ���� �޾ƿ���
        for (int i = 0; i < fishitemcount; i++)
        {
            userInfo.FishItemkey.Add(PlayerPrefs.GetString("FishItem" + i));
            userInfo.FishItem.Add(PlayerPrefs.GetString("FishItemKey" + i), PlayerPrefs.GetInt("FishItemValue" + i));
        }

        ////////����� �κ��� �ֱ�
        GameObject InventoryFish = Inventory.transform.GetChild(8).gameObject;
        for (int i = 0; i < fishitemcount; i++)
        {
            GameObject Fishimg_On = InventoryFish.transform.GetChild(i).transform.GetChild(0).gameObject;
            Image fishimg = InventoryFish.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
            GameObject Fishcount_On = InventoryFish.transform.GetChild(i).transform.GetChild(1).gameObject;
            Text fishtext = InventoryFish.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>();
            if (userInfo.FishItemkey[i].Equals("����ѹ����")) { fishimg.sprite = fishes1[0]; }
            else if (userInfo.FishItemkey[i].Equals("���������")) { fishimg.sprite = fishes2[0]; }
            else if (userInfo.FishItemkey[i].Equals("��Ȳ�����")) { fishimg.sprite = fishes2[1]; }
            else if (userInfo.FishItemkey[i].Equals("��������")) { fishimg.sprite = fishes3[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ʷϹ����")) { fishimg.sprite = fishes3[1]; }
            else if (userInfo.FishItemkey[i].Equals("���������")) { fishimg.sprite = fishes4[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ϴû������")) { fishimg.sprite = fishes4[1]; }
            else if (userInfo.FishItemkey[i].Equals("���󹰰��")) { fishimg.sprite = fishes5[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ǻ繰���")) { fishimg.sprite = fishes5[1]; }
            else if (userInfo.FishItemkey[i].Equals("��ι����")) { fishimg.sprite = fishes6[0]; }
            else if (userInfo.FishItemkey[i].Equals("�����������")) { fishimg.sprite = fishes6[1]; }
            else if (userInfo.FishItemkey[i].Equals("���ֹ����")) { fishimg.sprite = fishes7[0]; }
            else if (userInfo.FishItemkey[i].Equals("���ι����")) { fishimg.sprite = fishes7[1]; }
            else if (userInfo.FishItemkey[i].Equals("�źι����")) { fishimg.sprite = fishes7[2]; }
            else if (userInfo.FishItemkey[i].Equals("�Ż繰���")) { fishimg.sprite = fishes7[3]; }
            else if (userInfo.FishItemkey[i].Equals("�Ǹ������")) { fishimg.sprite = fishes8[0]; }
            else if (userInfo.FishItemkey[i].Equals("õ�繰���")) { fishimg.sprite = fishes8[1]; }
            else if (userInfo.FishItemkey[i].Equals("���¸��ʹ����")) { fishimg.sprite = fishes9[1]; }
            else if (userInfo.FishItemkey[i].Equals("����������")) { fishimg.sprite = fishes9[0]; }
            else if (userInfo.FishItemkey[i].Equals("�ҸӴ��ǻ�������")) { fishimg.sprite = fishes10[0]; }
            fishtext.text = userInfo.FishItem[userInfo.FishItemkey[i]].ToString();
            Fishimg_On.SetActive(true);
            Fishcount_On.SetActive(true);
        }

        ///////���丮 ���� �޾ƿ���
        for (int i = 0; i < storyitemcount; i++)
        {
            userInfo.StoryItemkey.Add(PlayerPrefs.GetString("StoryItem" + i));
            userInfo.StoryItem.Add(PlayerPrefs.GetString("StoryItemKey" + i), PlayerPrefs.GetInt("StoryItemValue" + i));
        }

        ////////���丮 �κ��� �ֱ�
        GameObject InventoryStory = Inventory.transform.GetChild(12).gameObject;
        for (int i = 0; i < storyitemcount; i++)
        {
            GameObject Storyimg_On = InventoryStory.transform.GetChild(i).transform.GetChild(0).gameObject;
            Image storyimg = InventoryStory.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
            GameObject Storycount_On = InventoryStory.transform.GetChild(i).transform.GetChild(1).gameObject;
            Text storytext = InventoryStory.transform.GetChild(i).transform.GetChild(1).GetComponent<Text>();
            if (userInfo.StoryItemkey[i].Equals("Orgol")) { storyimg.sprite = spec_orgol[10]; }
            else if (userInfo.StoryItemkey[i].Equals("�ϴû� ����")) { storyimg.sprite = special[0]; }
            else if (userInfo.StoryItemkey[i].Equals("���� ����")) { storyimg.sprite = special[1]; }
            else if (userInfo.StoryItemkey[i].Equals("�ʷϻ� ����")) { storyimg.sprite = special[2]; }
            else if (userInfo.StoryItemkey[i].Equals("�ҸӴ��� ��¤����")) { storyimg.sprite = special[3]; }
            else if (userInfo.StoryItemkey[i].Equals("��ȫ�� ����")) { storyimg.sprite = special[4]; }
            else if (userInfo.StoryItemkey[i].Equals("����� ����")) { storyimg.sprite = special[5]; }
            else if (userInfo.StoryItemkey[i].Equals("������")) { storyimg.sprite = special[6]; }
            storytext.text = userInfo.FishItem[userInfo.FishItemkey[i]].ToString();
            Storyimg_On.SetActive(true);
            Storycount_On.SetActive(true);
        }

        ///////��� ���� �� �ޱ�
        int savefieldcount = PlayerPrefs.GetInt("Saved_FieldCount");
        for(int i = 0; i < savefieldcount; i++)
        {
            player.SeedField_name.Add(GameObject.Find(PlayerPrefs.GetString("Saved_Field_Object" + i)));
            player.SeedField.Add(player.SeedField_name[i].name, new List<string> { PlayerPrefs.GetString("Saved_Field_value1_" + i), PlayerPrefs.GetString("Saved_Field_value2_" + i),
            PlayerPrefs.GetString("Saved_Field_value3_" + i),PlayerPrefs.GetString("Saved_Field_value4_" + i),PlayerPrefs.GetString("Saved_Field_value5_" + i)});
            string sprite_name = PlayerPrefs.GetString("Saved_Field_Object_sprite" + i);
            SpriteRenderer SpriteR = player.SeedField_name[i].GetComponent<SpriteRenderer>();
            if(sprite_name.Equals(seeds2[0])) { SpriteR.sprite = seeds2[0] as Sprite; }
            else if (sprite_name.Equals(seeds2[1])) { SpriteR.sprite = seeds2[1] as Sprite; }
            else if (sprite_name.Equals(seeds2[2])) { SpriteR.sprite = seeds2[2] as Sprite; }
            else if (sprite_name.Equals(seeds2[3])) { SpriteR.sprite = seeds2[3] as Sprite; }
            else if (sprite_name.Equals(seeds2[4])) { SpriteR.sprite = seeds2[4] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[0])) { SpriteR.sprite = fruit_befores[0] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[1])) { SpriteR.sprite = fruit_befores[1] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[2])) { SpriteR.sprite = fruit_befores[2] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[3])) { SpriteR.sprite = fruit_befores[3] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[4])) { SpriteR.sprite = fruit_befores[4] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[5])) { SpriteR.sprite = fruit_befores[5] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[6])) { SpriteR.sprite = fruit_befores[6] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[7])) { SpriteR.sprite = fruit_befores[7] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[8])) { SpriteR.sprite = fruit_befores[8] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[9])) { SpriteR.sprite = fruit_befores[9] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[10])) { SpriteR.sprite = fruit_befores[10] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[11])) { SpriteR.sprite = fruit_befores[11] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[12])) { SpriteR.sprite = fruit_befores[12] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[13])) { SpriteR.sprite = fruit_befores[13] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[14])) { SpriteR.sprite = fruit_befores[14] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[15])) { SpriteR.sprite = fruit_befores[15] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[16])) { SpriteR.sprite = fruit_befores[16] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[17])) { SpriteR.sprite = fruit_befores[17] as Sprite; }
            else if (sprite_name.Equals(fruit_befores[18])) { SpriteR.sprite = fruit_befores[18] as Sprite; }
        }




        PlayerUI.SetActive(true);
        string scene = PlayerPrefs.GetString("Scene");
        SceneManager.LoadScene(scene);
    }
    
    public void GameStart() // ĳ���� ���� ����â���� �̵�
    {
        SceneManager.LoadScene("InputInfo (2)");
    }

    public void GameExit() // ���� ����
    {
        Application.Quit();
    }


}
