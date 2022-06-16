using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class ObjectSpawnCs : BaseMono
    {
        private ObjectSpawner _thisSpawner;

        private void OnApplicationQuit()
        {
            _thisSpawner = null;
        }

        public void SetSpawner(ObjectSpawner spawner)
        {
            _thisSpawner = spawner;
        }

        public void OnInteract()
        {
            Active = false;
            DelayAction(_thisSpawner.fixedDelayBetweenSpawns, () => Active = true).Forget();
        }
    }
}

