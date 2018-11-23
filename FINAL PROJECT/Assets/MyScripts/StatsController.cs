using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Stats
{
    public string Name;
    public string Class;
    public int Level;
    public int MaxHP;
}


public class StatsController : MonoBehaviour
{
    [SerializeField]
    string name, classType;
    [SerializeField]
    int level, maxHP;

    Stats stats;
    void Start ()
    {
        stats.Name = name;
        stats.Class = classType;
        stats.Level = level;
        stats.MaxHP = maxHP;

    }
	
	void Update ()
    {
		
	}

    public Stats GetStats()
    {
        return stats;
    }
}
