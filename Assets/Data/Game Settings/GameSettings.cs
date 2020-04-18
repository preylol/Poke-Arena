using UnityEngine;
using System.Collections.Generic;
using System;

[Serializable, CreateAssetMenu(fileName = "GameSettings", menuName = "Poke-Arena/Game Settings")]
public class GameSettings : ScriptableObject {

    public List<string> Rarities;
    public int maxLevel = 10;

    // 2d array of all drop chances, sorted by [rarity, level] and out of 100
    public Array2D DropChances;

    // List of Prefabs of all Units of Evolution Chain 1
    public List<GameObject> BaseUnitPrefabs;

}