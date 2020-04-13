﻿using UnityEngine;

[CreateAssetMenu(fileName = "New Unit Properties", menuName = "Unit Properties")]
public class UnitProperties : ScriptableObject {

    public int health;
    public int health_per_evolution;

    public int atkDmg;
    public int atkDmg_per_evolution;

    public float atkSpeed;
    public float atkSpeed_per_evolution;

    public float moveSpeed;
    public float moveSpeed_per_evolution;

    public PoolMan.QUALITY quality;
}