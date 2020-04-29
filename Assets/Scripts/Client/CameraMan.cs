using UnityEngine;
using Bolt;

public class CameraMan : GlobalEventListener {

    public Vector3 CamOffset;
    public Vector3 CamRotationEulers;
    
    public override void OnEvent(PlayerSpawnedEvent evnt) {
        BoltLog.Info("PLAYERRRRR" + evnt.PlayerNetID);
        var playerEntity = BoltNetwork.FindEntity(evnt.PlayerNetID);
        transform.SetParent(playerEntity.transform.parent);
        transform.localPosition = CamOffset;
        transform.localRotation = Quaternion.Euler(CamRotationEulers);
    }

}