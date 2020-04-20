﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bolt;

[BoltGlobalBehaviour(BoltNetworkModes.Server)]
public class BattleMan : Bolt.GlobalEventListener {

    #region Singleton
    public static BattleMan Instance { get; private set; }
    #endregion

    public BattleTile[,] BattleBoard { get; private set; }

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        InitEventSubscribers();
        InitBattleBoard();
    }

    private void InitEventSubscribers() {
        RoundMan round = RoundMan.Instance;
        round.StartOfPhaseEvent += HandleStartOfPhaseEvent;
    }

    private void InitBattleBoard() {
        int w = BoardMan.BOARD_WIDTH, h = BoardMan.BOARD_HEIGHT;
        BattleBoard = new BattleTile[w, h];
        for (int x = 0; x < w; x++) {
            for (int y = 0; y < h / 2; y++) {
                Tile tile = BoardMan.Instance.Board[x, y];
                if (tile == null) continue;
                BattleBoard[x, y] = new BattleTile(x, y);
                BattleBoard[(w - 1) - x, y] = new BattleTile(x, y);
            }
        }
    }

    private void UpdateFriendlyUnits() {
        int w = BoardMan.BOARD_WIDTH, h = BoardMan.BOARD_HEIGHT;
        for (int x = 0; x < w; x++) {
            for (int y = 0; y < h / 2; y++) {
                Tile tile = BoardMan.Instance.Board[x, y];
                if (tile.IsTileFilled()) BattleBoard[x, y].FillTile(tile.GetUnit());
            }
        }
    }

    private void HandleStartOfPhaseEvent(RoundMan.Phase phase) {
        switch (phase) {
            case RoundMan.Phase.BATTLE:
                UpdateFriendlyUnits();
                break;
            case RoundMan.Phase.OVERTIME:
                break;
            case RoundMan.Phase.END:
                break;
            default:
                break;
        }
    }

}
