using System;
using UnityEngine;

[Serializable] // 데이터이다. (직렬화가능하다)
public class Character
{
    public string name { get; private set; }
    public string description { get; private set; }
    public int level { get; private set; }
    public int gold { get; private set; }

    public float curAttack { get; private set; }
    public float curDefense { get; private set; }
    public float curHealth { get; private set; }
    public float curCritical { get; private set; }

    public Character(string _name, string _description, int _level, int _gold)
    {
        name = _name;
        description = _description;
        level = _level;
        gold = _gold;

        //초기 스탯
        curAttack = 5;
        curDefense = 10;
        curHealth = 50;
        curCritical = 0;
    }
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Character characters;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // public void SetCharacterData(string _name, string _description, int _level, int _gold)
    // {
    //     characters = new Character(_name, _description, _level, _gold);
    // }
}