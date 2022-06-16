using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpawnMode {
    FixedTime,
    Wave,
    ManualFixedTime
}

public enum SpawnAt {Position, Transform, Grid, RandomGrid, RandomTransform}
public enum SpawnRotation {
    Identity,
    Spawner,
    Custom,
    ObjectOwnRotation,
}

