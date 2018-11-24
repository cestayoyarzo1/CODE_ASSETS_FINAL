using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct Stats
{
    public string Name;
    public string Class;
    public int Level;
    public float MaxHP;
    public float Health;
}


public class StatsController : MonoBehaviour
{
    [SerializeField]
    string name, classType;
    [SerializeField]
    int level, maxHP, health;

    Stats stats;
    Text nameTag;
    void Start ()
    {
        stats.Name = name;
        stats.Class = classType;
        stats.Level = level;
        stats.MaxHP = maxHP;
        stats.Health = maxHP;
        nameTag = GetComponentInChildren<Text>();
        nameTag.text = name + " (lvl " + level.ToString() + ")";
    }
	
	void Update ()
    {
		
	}

    public Stats GetStats()
    {
        return stats;
    }

    public void UpdateHealth(float health)
    {
        stats.Health = health;
    }

}
