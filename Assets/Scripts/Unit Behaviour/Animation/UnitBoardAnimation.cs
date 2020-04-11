﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class UnitBoardAnimation : UnitGestureAnimation {

    #region Variables
    #endregion

    #region Unity Methods
    private new void Awake() {
        base.Awake();
        InitEventSubscribers();
    }

    protected override void BoardUpdate() {
        base.BoardUpdate();
        PerformRandomGesture();
        UpdateMovementState();
    }
    #endregion

    #region Initialisation
    private void InitEventSubscribers() {
        BoardMan board = BoardMan.Instance;
        board.UnitTeleportEvent += HandleUnitTeleportEvent;
        board.EvolutionEvent += HandleEvolutionEvent;
        StoreMan store = StoreMan.Instance;
        store.UnitBoughtEvent += HandleUnitBoughtEvent;
    }
    #endregion

    private void UpdateMovementState() {
        UnitMovement.MoveType moveType = (unit.GetUnitBehaviour<UnitMovement>() as UnitMovement).CurrentMoveType;
        if (moveType == UnitMovement.MoveType.RUN) {
            //TODO :)
        }
    }

    #region Event Handlers
    private void HandleUnitBoughtEvent(Unit unit) {
        if (IsThisUnit(unit)) TryPerformAnimation(EXCITED, true);
    }

    private void HandleUnitSoldEvent(Unit unit) {
    }

    private void HandleEvolutionEvent(List<Tile> tiles, Unit unit) {
        if (IsThisUnit(unit)) TryPerformAnimation(SHAKE, true);
    }

    private void HandleUnitTeleportEvent(Unit unit, Tile fromTile) {
        if (IsThisUnit(unit)) {
            if (fromTile.IsBoardTile() && unit.GetTile().IsBoardTile()) {
                anim.ResetTrigger("Stop Running");
                anim.SetTrigger("Start Running");
            } else TryPerformAnimation(SHAKE, true);
        }
    }
    #endregion
}