using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FirstMenuHandle : MonoBehaviour
{
    UserInfo userInfo;
    // Start is called before the first frame update
    public Sprite[] fruit_afters, invens, seeds, swords, tools;
    void Start()
    {
        fruit_afters = Resources.LoadAll<Sprite>("Sprites/Fruit/after");
        seeds = Resources.LoadAll<Sprite>("Sprites/Fruit/Seed");
        invens = Resources.LoadAll<Sprite>("Sprites/Inven");
        swords = Resources.LoadAll<Sprite>("Sprites/sword");
        tools = Resources.LoadAll<Sprite>("Sprites/Tool");
    }

    // Update is called once per frame

    public void GameLoad() // 저장 데이터 불러오기
    {
        MenuControl menu = GameObject.Find("MenuManager").GetComponent<MenuControl>();
        menu.issave = true;
        
        //user Item 저장
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

        if (gender.Equals("man")) // 남자
        {
            GameObject user_man = GameObject.Find("Player").transform.GetChild(1).gameObject;
            PlayerController player = user_man.GetComponent<PlayerController>();
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
        else // 여자
        {
            GameObject user_woman = GameObject.Find("Player").transform.GetChild(0).gameObject;
            PlayerController player = user_woman.GetComponent<PlayerController>();
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
        //////유저 상태 UI 등록
        Text HPUI = PlayerUI.transform.GetChild(2).transform.GetChild(0).GetComponent<Text>();
        Text DayUI = PlayerUI.transform.GetChild(3).transform.GetChild(0).GetComponent<Text>();
        Text GoldUI = PlayerUI.transform.GetChild(4).transform.GetChild(0).GetComponent<Text>();
        Text LEVELUI = PlayerUI.transform.GetChild(5).transform.GetChild(0).GetComponent<Text>();
        HPUI.text = userInfo.getHp() + " / " + userInfo.getMaxHp();
        if(userInfo.getCheckDay() < 31) { DayUI.text = "봄, " + userInfo.getDay() + "일"; }
        else if (userInfo.getCheckDay() < 61) { DayUI.text = "여름, " + userInfo.getDay() + "일"; }
        else if (userInfo.getCheckDay() < 91) { DayUI.text = "가을, " + userInfo.getDay() + "일"; }
        else if (userInfo.getCheckDay() < 121) { DayUI.text = "겨울, " + userInfo.getDay() + "일"; }
        GoldUI.text = userInfo.getGold().ToString();
        LEVELUI.text = "Lv. " + userInfo.getLevel();
        ///////무기 UI 등록
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

        /////////방어 상태창 등록 
        if (PlayerPrefs.HasKey("Armor_Name"))
        {
            string Armor_name = PlayerPrefs.GetString("Armor_Name");
            int Armor_Power = PlayerPrefs.GetInt("Armor_Power");
            userInfo.getItem_Armor().SetArmorName(Armor_name);
            userInfo.getItem_Armor().SetArmorPower(Armor_Power);
            Text Armortext = Inventory.transform.GetChild(9).transform.GetChild(6).GetComponent<Text>();
            Armortext.text = "방어력 : " + userInfo.getItem_Armor().GetArmorPower();
        }

        ////////호미 UI 등록
        GameObject PlayerUI_Hoe = PlayerUI.transform.GetChild(0).transform.GetChild(1).transform.GetChild(0).gameObject;
        Image Hoe_img = PlayerUI_Hoe.GetComponent<Image>();
        if (userInfo.getItem_Hoe().GetHoeName().Equals("Stone_Hoe")) { Hoe_img.sprite = tools[13] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Guri_Hoe")) { Hoe_img.sprite = tools[4] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Silver_Hoe")) { Hoe_img.sprite = tools[10] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Iridium_Hoe")) { Hoe_img.sprite = tools[7] as Sprite; }
        else if (userInfo.getItem_Hoe().GetHoeName().Equals("Dia_Hoe")) { Hoe_img.sprite = tools[1] as Sprite; }
        PlayerUI_Hoe.SetActive(true);

        ////////낚시대 UI 등록
        GameObject PlayerUI_Fish = PlayerUI.transform.GetChild(0).transform.GetChild(2).transform.GetChild(0).gameObject;
        Image Fish_img = PlayerUI_Fish.GetComponent<Image>();
        if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Stone_FishingRod")) { Fish_img.sprite = tools[11] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Guri_FishingRod")) { Fish_img.sprite = tools[2] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Silver_FishingRod")) { Fish_img.sprite = tools[8] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Iridium_FishingRod")) { Fish_img.sprite = tools[5] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Dia_FishingRod")) { Fish_img.sprite = tools[0] as Sprite; }
        PlayerUI_Fish.SetActive(true);

        ////////물뿌리개 UI 등록
        GameObject PlayerUI_Water = PlayerUI.transform.GetChild(0).transform.GetChild(3).transform.GetChild(0).gameObject;
        Image Water_img = PlayerUI_Water.GetComponent<Image>();
        if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Stone_Water")) { Water_img.sprite = tools[14] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Guri_Water")) { Water_img.sprite = tools[15] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Silver_Water")) { Water_img.sprite = tools[18] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Iridium_Water")) { Water_img.sprite = tools[17] as Sprite; }
        else if (userInfo.getItem_WaterPPU().GetWaterPPUName().Equals("Dia_Water")) { Water_img.sprite = tools[16] as Sprite; }
        else if (userInfo.getItem_FishingRod().GetFishingRodName().Equals("Dia_FishingRod")) { Fish_img.sprite = tools[0] as Sprite; }
        PlayerUI_Water.SetActive(true);

        ///////// 인벤 UI 다 채우기 사진부터
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






        PlayerUI.SetActive(true);
        string scene = PlayerPrefs.GetString("Scene");
        SceneManager.LoadScene(scene);
    }
    
    public void GameStart() // 캐릭터 성별 선택창으로 이동
    {
        SceneManager.LoadScene("InputInfo (2)");
    }

    public void GameExit() // 게임 종료
    {
        Application.Quit();
    }


}
