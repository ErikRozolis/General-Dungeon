using System;

[Serializable]
public class GameSlot
{
    public string SaveName;
    public PlayerData PlayerData;
    public bool NewGame;

    public GameSlot(string saveName)
    {
        SaveName = saveName;
        NewGame = true;
        PlayerData = new PlayerData();
        PlayerData.PlayerName = saveName;


        PlayerData.Stats = new Stats();

        PlayerData.Stats.Level = 1;
        PlayerData.Stats.Experience = 0;


        PlayerData.Stats.BaseStats = new BaseStats();

        PlayerData.Stats.BaseStats.Damage = 1;
        PlayerData.Stats.BaseStats.Defense = 0;
        PlayerData.Stats.BaseStats.MaxHealth = 10;

        PlayerData.Stats.CurrentHealth = PlayerData.Stats.BaseStats.MaxHealth;


        PlayerData.Stats.Equipment = new Equipment();

        PlayerData.Stats.Equipment.Armor = new Armor();
        PlayerData.Stats.Equipment.Armor.Defense = 0;
        PlayerData.Stats.Equipment.Armor.Name = "Naked";

        PlayerData.Stats.Equipment.Weapon = new Weapon();
        PlayerData.Stats.Equipment.Weapon.Damage = 0;
        PlayerData.Stats.Equipment.Weapon.Name = "Fist";
    }
}
