﻿using UnityEngine;
using TMPro;

public class PlayerInfoUpdater : MonoBehaviour {

    private FinanceMan finance;
    private LevelMan level;

    [SerializeField] private TextMeshProUGUI
        coinText = null,
        levelText = null,
        expText = null
        ;

    private void Start() {
        finance = FinanceMan.Instance;
        level = LevelMan.Instance;
    }

    private void Update() {
        coinText.text = finance.Coins.ToString();
        int lvl = level.Level;
        levelText.text = "Level: " + (lvl + 1);
        expText.text = "EXP: " + level.Exp + "/" + level.MAX_EXP[lvl];
    }
}