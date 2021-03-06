using UnityEngine;
using Bolt;
using System.Collections.Generic;

public class StoreUnit : EntityBehaviour<IStoreUnitState> {

    public StoreUnit variant;
    public BoardUnit boardUnit;

    private List<UnitComponent> UnitBehaviours;

    public override void Attached() {
        state.AddCallback("Position", UpdatePosition);
        state.AddCallback("Rotation", UpdateRotation);
        state.AddCallback("Active", ChangeActiveState);
        if (BoltNetwork.IsClient) {
            InitUnitClientBehaviours();
        }
    }

    private void InitUnitClientBehaviours() {
        UnitBehaviours = new List<UnitComponent> {
            gameObject.AddComponent<StoreUnitAnimation>(),
            gameObject.AddComponent<StoreUnitSpawnShaderEffect>()
        };
    }

    private void UpdatePosition() { transform.position = state.Position; }
    private void UpdateRotation() { transform.rotation = state.Rotation; }
    private void ChangeActiveState() { SetActive(state.Active); }

    public void SetActive(bool state) {
        for (int childIdx = 0; childIdx < transform.childCount; childIdx++)
            transform.GetChild(childIdx).gameObject.SetActive(state);
    }

    public void ResetUnitPosition() {
        var position = Vector3.left * 100;
        var rotation = Quaternion.identity;
        var active = false;

        if (entity.IsOwner) {
            state.Position = position;
            state.Rotation = rotation;
            state.Active = true; // Without this it goes false -> false, not triggering callback, since nothing changed
            state.Active = active;
        } else {
            transform.parent = null;
            transform.position = position;
            transform.rotation = rotation;
            SetActive(active);
        }
    }
}