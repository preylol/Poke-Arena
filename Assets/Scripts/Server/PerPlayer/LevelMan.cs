using UnityEngine;

public class LevelMan : PlayerManager {

    public int Level { get; private set; }
    public int Exp { get; private set; }

    private void Start() {
        // TODO
        Level = 0;
        Exp = 0;
    }

}