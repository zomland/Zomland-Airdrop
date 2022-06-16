using System;
using System.Collections;
using System.Collections.Generic;
using Base;
using Base.Pattern;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Base
{
    public class ObjectSpawner : BaseMono
    {
        #region Basic setting

        public string key;
        public Transform sceneParent;

        public SpawnMode spawnMode;

        // Show/Hide Debug Logs (I hate spammed logs)
        public bool ShowDebugMessages;

        #endregion

        #region Timer setting

        // TODO: Configure first spawn to work with some trigger too
        [Tooltip("Time since script activation to spawn first object")]
        public float firstSpawnTime;

        // Fixed Configuration
        [Tooltip("Time between spawns. (after first spawn)")]
        public float fixedDelayBetweenSpawns;

        // Random Configuration
        public float minDelayBetweenSpawns;
        public float maxDelayBetweenSpawns;

        // Progressive Configuration
        [Tooltip("Time between spawns. (after first spawn)")]
        public float startingDelayBetweenSpawns;

        [Tooltip("")] public float delayModifier;

        [Tooltip("Since we use a countdown timer remember to use a value minor than the Starting Delay but greater than 0")]
        public float progressiveDelayLimit;

        #endregion

        #region Wave Setting
        
        public float timeBetweenWave;
        public int amountOfWave;

        #endregion

        #region Manual Fixed Time setting

        private bool _isStartTimer = false;

        #endregion

        #region Advance Spawner Setting

        public SpawnAt spawnAt;

        public bool isShowGizmos;

        #region Grid Setting

        public int gridWidth, gridHeight;
        public Transform gridRoot;
        public float cellSize;
        public int amountPreSpawn;

        private GridBase gridBase;

        private int _selectedGridIndex;
        private int _totalSpawn;

        #endregion

        #region Random Transform setting

        public List<Transform> targetList;

        #endregion

        #endregion

        #region Rotation Setting

        private Transform _rotateTransform;
        public SpawnRotation spawnRotation;

        public float customRotationX;
        public float customRotationY;
        public float customRotationZ;

        #endregion

        #region UltimateSpawner Events

        public event Action Spawned;

        #endregion

        #region Timer

        private float interval;

        private float timeLeft;

        private delegate void TimerElapsed();

        private event TimerElapsed Elapsed;

        void SetupTimer()
        {
            timeLeft = interval = firstSpawnTime;

            Elapsed += Spawn;
            Elapsed += ElapsedBehaviour;
        }

        void ElapsedBehaviour()
        {
            switch (spawnMode)
            {
                case SpawnMode.FixedTime:
                    interval = fixedDelayBetweenSpawns;
                    break;
                case SpawnMode.ManualFixedTime:
                    interval = fixedDelayBetweenSpawns;
                    break;
                // case SpawnMode.ProgressiveTime:
                //     interval = ProgressiveTimer();
                //     break;
                // case SpawnMode.RandomTime:
                //     interval = RandomTimer();
                //     break;
                default:
#if UNITY_EDITOR
                    UltimateLog("Elapsed was called but timer is not configured");
#endif

                    break;
            }
        }

        float RandomTimer()
        {
            // Generate random number between gap
            float randomDelayBetweenSpawns = UnityEngine.Random.Range(minDelayBetweenSpawns, maxDelayBetweenSpawns);

#if UNITY_EDITOR
            UltimateLog(string.Format("The next spawn will happen in {0} seconds", randomDelayBetweenSpawns));
#endif

            return randomDelayBetweenSpawns;
        }

        float ProgressiveTimer()
        {
            float progressiveDelay;

            // Just in case it's reaches a number less than 0
            if (progressiveDelayLimit < 0) progressiveDelayLimit = 0;

            if (interval <= progressiveDelayLimit)
            {
                progressiveDelay = progressiveDelayLimit;

#if UNITY_EDITOR
                UltimateLog(string.Format("The spawn delay has reached it's limit of {0} seconds", progressiveDelay));
#endif

                return progressiveDelay;
            }

            // Reduce the delay
            progressiveDelay = interval - delayModifier;

#if UNITY_EDITOR
            UltimateLog(string.Format("The next spawn will happen in {0} seconds", progressiveDelay));
#endif

            return progressiveDelay;
        }

        #endregion

#if UNITY_EDITOR
        /// <summary>
        /// Used to send a debug message
        /// </summary>
        /// <param name="message">The log you want to send</param>
        /// <param name="logType">You can use "NORMAL", "WARNING", "ERROR" </param>
        public void UltimateLog(string message, string logType = "NORMAL")
        {
            // If is not editor or we don't want to show logs
            if (!Application.isEditor || !ShowDebugMessages) return;

            // Create color
            Color ultimateSpawnerTagColor;

            // Setup a color variation for each skin
            ultimateSpawnerTagColor = EditorGUIUtility.isProSkin ? new Color(8, 129, 221) : new Color(5, 81, 139);

            // Header to indicate that the log came from UltimateSpawner
            string header = "UltimateSpawner: ";

            if (logType == "NORMAL")
                Debug.Log(
                    string.Format("<color=#{0:X2}{1:X2}{2:X2}><b>{3}</b></color>{4}", (byte)(ultimateSpawnerTagColor.r), (byte)(ultimateSpawnerTagColor.g),
                        (byte)(ultimateSpawnerTagColor.b), header, message), gameObject);

            if (logType == "WARNING")
                Debug.LogWarning(
                    string.Format("<color=#{0:X2}{1:X2}{2:X2}><b>{3}</b></color>{4}", (byte)(ultimateSpawnerTagColor.r), (byte)(ultimateSpawnerTagColor.g),
                        (byte)(ultimateSpawnerTagColor.b), header, message), gameObject);

            if (logType == "ERROR")
                Debug.LogError(
                    string.Format("<color=#{0:X2}{1:X2}{2:X2}><b>{3}</b></color>{4}", (byte)(ultimateSpawnerTagColor.r), (byte)(ultimateSpawnerTagColor.g),
                        (byte)(ultimateSpawnerTagColor.b), header, message), gameObject);
        }
#endif

        private void Awake()
        {
            if (spawnAt == SpawnAt.Grid)
            {
                ObjectPooler.ResetPool(key);
                ObjectPooler.InitObjectPool(key);
                gridBase = new GridBase(gridWidth, gridHeight, cellSize);

                if (amountPreSpawn > 0)
                {
                    for (int i = 0; i < amountPreSpawn; ++i)
                    {
                        Spawn();
                    }

                    interval = fixedDelayBetweenSpawns;
                }
            }
            else if (spawnAt == SpawnAt.RandomGrid)
            {
                ObjectPooler.ResetPool(key);
                ObjectPooler.InitObjectPool(key);
                gridBase = new GridBase(gridWidth, gridHeight, cellSize);

                for (int i = 0; i < gridBase.GridList.Capacity; ++i)
                {
                    gridBase.Add(0);
                }

                if (amountPreSpawn > 0)
                {
                    for (int i = 0; i < amountPreSpawn; ++i)
                    {
                        Spawn();
                    }

                    interval = fixedDelayBetweenSpawns;
                }
            }
            
            if (firstSpawnTime == 0)
            {
                _isStartTimer = true;
                interval = fixedDelayBetweenSpawns;
            }

            if (spawnMode == SpawnMode.FixedTime || spawnMode == SpawnMode.ManualFixedTime) 
                SetupTimer();
            else if (spawnMode == SpawnMode.Wave)
            {
                timeLeft = firstSpawnTime;
                interval = timeBetweenWave;
            }
        }

        private void Update()
        {
            if (spawnMode == SpawnMode.FixedTime /*|| spawnMode == SpawnMode.ProgressiveTime || spawnMode == SpawnMode.RandomTime*/)
            {
                timeLeft -= Time.deltaTime;
                if (timeLeft < 0)
                {
                    timeLeft = interval;
                    Elapsed?.Invoke();
                }
            }
            else if (spawnMode == SpawnMode.Wave)
            {
                if (_isStartTimer)
                {
                    timeLeft -= Time.deltaTime;
                    if (timeLeft <= 0)
                    {
                        timeLeft = interval;
                        _isStartTimer = false;
                        SpawnWave();
                    }
                }
            }
            else if (spawnMode == SpawnMode.ManualFixedTime)
            {
                if (_isStartTimer)
                {
                    timeLeft -= Time.deltaTime;
                    if (timeLeft <= 0)
                    {
                        timeLeft = interval;
                        Elapsed?.Invoke();
                        _isStartTimer = false;
                    }
                }
            }
        }

        private void OnDrawGizmos()
        {
            if ((spawnAt == SpawnAt.Grid || spawnAt == SpawnAt.RandomGrid) && isShowGizmos)
            {
                if (gridBase == null || (gridWidth != gridBase.Width || gridHeight != gridBase.Height || Math.Abs(cellSize - gridBase.CellSize) > 0))
                {
                    gridBase = new GridBase(gridWidth, gridHeight, cellSize);
                }

                for (int i = 0; i < gridWidth; ++i)
                {
                    for (int j = 0; j < gridHeight; ++j)
                    {
                        Vector3 position = gridBase.GetWorldPosition(i, j);
                        Gizmos.DrawIcon(gridRoot.TransformPoint(new Vector3(position.x, 0, position.y)), "BaseObjectSpawner/spawner_icon.png", true);
                    }
                }
            }
        }

        private Vector3 GetSpawnPosition()
        {
            if (spawnAt == SpawnAt.Grid)
            {
                if (gridBase == null)
                {
                    gridBase = new GridBase(gridWidth, gridHeight, cellSize);
                }

                Vector3 position = gridBase.GetWorldPosition((int)gridBase.Get(_selectedGridIndex).x, (int)gridBase.Get(_selectedGridIndex).y);

                return gridRoot.TransformPoint(new Vector3(position.x, 0, position.y));
            }

            if (spawnAt == SpawnAt.RandomGrid)
            {
                if (gridBase == null)
                {
                    gridBase = new GridBase(gridWidth, gridHeight, cellSize);
                }

                _selectedGridIndex = gridBase.GridList.FindRandomIndex(item => item == 0);
                gridBase.Add(_selectedGridIndex, 1);
                Vector3 position = gridBase.GetWorldPosition((int)gridBase.Get(_selectedGridIndex).x, (int)gridBase.Get(_selectedGridIndex).y);

                return gridRoot.TransformPoint(new Vector3(position.x, 0, position.y));
            }

            if (spawnAt == SpawnAt.RandomTransform)
            {
                return targetList[_selectedGridIndex].transform.position;
            }

            return Vector3.zero;
        }

        private Vector3 GetSpawnRotation()
        {
            switch (spawnRotation)
            {
                case SpawnRotation.Identity:
                    return Vector3.zero;
                case SpawnRotation.ObjectOwnRotation:
                    return Vector3.zero;
                case SpawnRotation.Custom:
                    return new Vector3(customRotationX, customRotationY, customRotationZ);
                    break;
            }

            return _rotateTransform.eulerAngles;
        }

        public void Spawn()
        {
            Transform obj = null;
            if ((spawnAt == SpawnAt.Grid || spawnAt == SpawnAt.RandomGrid) && _totalSpawn < gridBase.GridList.Capacity)
            {
                obj = ObjectPooler.Get(key, GetSpawnPosition(), GetSpawnRotation());
                obj.gameObject.SetActive(true);

                // This component used to regenerate the object after delay time
                obj.gameObject.AddComponent<ObjectSpawnCs>().SetSpawner(this);

                _selectedGridIndex += 1;
                _totalSpawn += 1;

                if (_selectedGridIndex == gridBase.GridList.Capacity)
                {
                    _selectedGridIndex = 0;
                }

#if UNITY_EDITOR
                UltimateLog(string.Format("Spawn object {0} at {1} with angle {2}", obj.name, obj.position.ToString(), obj.eulerAngles.ToString()));
#endif

                if (Spawned != null)
                {
                    Spawned.Invoke();
                }
            }
            else if (spawnAt == SpawnAt.RandomTransform)
            {
                _selectedGridIndex = Random.Range(0, targetList.Count);
                obj = ObjectPooler.Get(key, GetSpawnPosition(), GetSpawnRotation(), sceneParent);
                obj.gameObject.SetActive(true);
                _selectedGridIndex = 0;
            }
        }

        private void SpawnWave()
        {
            if (spawnMode == SpawnMode.Wave)
            {
                for (int i = 0; i < amountOfWave; ++i)
                {
                    Transform obj = ObjectPooler.Get(key, GetSpawnPosition(), GetSpawnRotation());
                    obj.gameObject.SetActive(true);

                    _selectedGridIndex += 1;
                }
                
                if (Spawned != null)
                {
                    Spawned.Invoke();
                }

                _selectedGridIndex = 0;
            }
        }

        public void SetStartTimer(bool isStart)
        {
            timeLeft = interval;
            _isStartTimer = isStart;
            _totalSpawn = 0;
        }
    }
}
