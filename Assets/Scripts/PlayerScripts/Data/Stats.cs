using System;

[Serializable]
public class Stats
{
    //Progress Stats
    public int Level = 1;
    public int Experience = 0;
    public int CurrentHealth = 10;
    public BaseStats BaseStats;
    public Equipment Equipment;
    public int TotalDamage()
    {
        int dmg = BaseStats.Damage + Equipment.Weapon.Damage;
        return dmg;
    }
}