using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Weapon
{
    string name = null;
    int power = 0;

    public string GetWeaponName()
    {
        return this.name;
    }
    public void SetWeaponName(string name)
    {
        this.name = name;
    }
    public int GetWeaponPower()
    {
        return this.power;
    }
    public void SetWeaponPower(int power)
    {
        this.power = power;
    }
}

public class Item_Armor
{
    string name = null;
    int armor = 0;

    public string GetArmorName()
    {
        return this.name;
    }
    public void SetArmorName(string name)
    {
        this.name = name;
    }
    public int GetArmorPower()
    {
        return this.armor;
    }
    public void SetArmorPower(int armor)
    {
        this.armor = armor;
    }
}

public class Item_Hoe
{
    string name = null;
    float speed = 0;

    public string GetHoeName()
    {
        return this.name;
    }
    public void SetHoeName(string name)
    {
        this.name = name;
    }
    public float GetHoeSpeed()
    {
        return speed;
    }
    public void SetHoeSpeed(float speed)
    {
        this.speed = speed;
    }
}

public class Item_FishingRod
{
    string name = null;
    float efficiency = 0; // 효율성

    public string GetFishingRodName()
    {
        return this.name;
    }
    public void SetFishingRodName(string name)
    {
        this.name = name;
    }
    public float GetFishingRodEfficiency()
    {
        return efficiency;
    }
    public void SetFishingRodEfficiency(float efficiency)
    {
        this.efficiency = efficiency;
    }
}

public class Item_WaterPPU
{
    string name = null;
    int filled = 0;

    public string GetWaterPPUName()
    {
        return this.name;
    }
    public void SetWaterPPUName(string name)
    {
        this.name = name;
    }
    public int GetWaterPPUFilled()
    {
        return this.filled;
    }
    public void SetWaterPPUFilled(int filled)
    {
        this.filled = filled;
    }
}

public class Item_Pick
{
    string name = null;
    string kinds = null;

    public string GetPickName()
    {
        return this.name;
    }
    public void SetPickName(string name)
    {
        this.name = name;
    }
    public string GetPickKinds()
    {
        return kinds;
    }
    public void SetPickKinds(string kinds)
    {
        this.kinds = kinds;
    }
}

public class UserInfo : MonoBehaviour
{
    private int Day; // 날짜
    private int Gold; // 돈
    private int Hp; // 체력
    private int MaxHp; // 체력
    private int Exp; // 경험치
    private int Level; // 레벨
    private string Name; // 이름
    private string FarmName; // 농장 이름
    public string Gender; // 성별
    public bool isTrue, isHoe, isWaterPPU, isFishingRod, isSword, isPick; // 남자, 여자 선택, 호미인지, 물뿌리개인지, 낚시대인지, 검인지, 곡괭이인지
    public bool isPinkKey, isGreenKey, isBlueKey, isPurpleKey, isFinalKey;
    public int storycounter; // 스토리 카운터
    public int userWhere; // 어디서 왔는지
    private int CheckDay; // 계속 증가
    Item_Weapon weapon; // 무기
    Item_Armor armor; // 방어구
    Item_FishingRod fishingRod; // 낚시대
    Item_Hoe hoe; // 호미? 괭이
    Item_WaterPPU waterPPU; // 물뿌리개
    Item_Pick pick;
    GameObject PlayerUI, InvenInfo;
    public Dictionary<string, int> SeedItem;
    public Dictionary<string, int> FruitItem;
    public Dictionary<string, int> FishItem;
    public Dictionary<string, int> StoryItem;
    public List<string> SeedItemkey;
    public List<string> FruitItemkey;
    public List<string> FishItemkey;
    public List<string> StoryItemkey;

    public int grandmaFish = 0; // 할머니의 사랑 물고기를 얻었는지 체크
    public bool npcSay; // 상점 주인이랑 대화하는지 
    public bool npcFinish = false; // 대화완료 체크.

    public UserInfo()
    {
        this.weapon = new Item_Weapon();
        this.armor = new Item_Armor();
        this.fishingRod = new Item_FishingRod();
        this.hoe = new Item_Hoe();
        this.waterPPU = new Item_WaterPPU();
        this.pick = new Item_Pick();
        SeedItem = new Dictionary<string, int>();
        FruitItem = new Dictionary<string, int>();
        FishItem = new Dictionary<string, int>();
        StoryItem = new Dictionary<string, int>();
        SeedItemkey = new List<string>();
        FruitItemkey = new List<string>();
        FishItemkey = new List<string>();
        StoryItemkey = new List<string>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public int getDay()
    {
        return Day;
    }
    public int getCheckDay()
    {
        return CheckDay;
    }
    public int getGold()
    {
        return Gold;
    }
    public int getHp()
    {
        return Hp;
    }
    public int getMaxHp()
    {
        return MaxHp;
    }
    public int getLevel()
    {
        return Level;
    }
    public int getExp()
    {
        return Exp;
    }
    public string getGender()
    {
        return Gender;
    }
    public string getName()
    {
        return Name;
    }
    public string getFarmName()
    {
        return FarmName;
    }
    public Item_Weapon getItem_Weapon()
    {
        return this.weapon;
    }
    public Item_Armor getItem_Armor()
    {
        return this.armor;
    }
    public Item_Hoe getItem_Hoe()
    {
        return this.hoe;
    }
    public Item_FishingRod getItem_FishingRod()
    {
        return this.fishingRod;
    }
    public Item_WaterPPU getItem_WaterPPU()
    {
        return this.waterPPU;
    }
    public Item_Pick getItem_Pick()
    {
        return this.pick;
    }


    public void setDay(int Day)
    {
        this.Day = Day;
    }
    public void setCheckDay(int CheckDay)
    {
        this.CheckDay = CheckDay;
    }
    public void setGold(int Gold)
    {
        this.Gold = Gold;
    }
    public void setUIGold()
    {
        Input_PlayerUI();
        Text Goldtext = PlayerUI.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        Goldtext.text = getGold().ToString();
    }
    public void setLevel(int Level)
    {
        this.Level = Level;
    }
    public void setUILevel()
    {
        Input_PlayerUI();
        Text Leveltext = PlayerUI.transform.GetChild(5).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        Leveltext.text = "Lv, " + getLevel() ;
    }
    public void setExp(int Exp)
    {
        this.Exp = Exp;
    }
    public void setExpInfo()
    {
        Input_InvenInfo();
        Text Exptext = InvenInfo.transform.GetChild(9).transform.GetChild(4).GetComponent<Text>();
        Exptext.text = "경험치 : " + getExp();
    }
    public void setHp(int Hp)
    {
        this.Hp = Hp;
    }
    public void setUIHp()
    {
        Input_PlayerUI();
        Text Hptext = PlayerUI.transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.GetComponent<Text>();
        Hptext.text = this.Hp + " / " + this.MaxHp;
    }
    public void setMaxHp(int MaxHp)
    {
        this.MaxHp = MaxHp;
    }
    public void setName(string Name)
    {
        this.Name = Name;
    }
    public void setNameInfo()
    {
        Input_InvenInfo();
        Text Nametext = InvenInfo.transform.GetChild(9).transform.GetChild(2).GetComponent<Text>();
        Nametext.text = "이름 : " + getName();
    }
    public void setFarmName(string FarmName)
    {
        this.FarmName = FarmName;
    }
    public void setFarmNameInfo()
    {
        Input_InvenInfo();
        Text FarmNametext = InvenInfo.transform.GetChild(9).transform.GetChild(3).GetComponent<Text>();
        FarmNametext.text = "농장 이름 : " + getFarmName();
    }
    public void setWeapon_powerInfo()
    {
        Input_InvenInfo();
        Text Weapontext = InvenInfo.transform.GetChild(9).transform.GetChild(5).GetComponent<Text>();
        Weapontext.text = "공격력 : " + getItem_Weapon().GetWeaponPower().ToString();
    }
    public void setArmor_powerInfo()
    {
        Input_InvenInfo();
        Text Armortext = InvenInfo.transform.GetChild(9).transform.GetChild(6).GetComponent<Text>();
        Armortext.text = "방어력 : " + getItem_Armor().GetArmorPower().ToString();
    }
    void Input_PlayerUI()
    {
        if(PlayerUI == null) { PlayerUI = GameObject.Find("PlayerUI").gameObject; }
    }
    void Input_InvenInfo()
    {
        if (InvenInfo == null) { InvenInfo = GameObject.Find("Canvas").transform.GetChild(4).gameObject; }
    }
}