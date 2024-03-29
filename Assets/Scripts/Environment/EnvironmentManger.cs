using DiningCombat.AI;
using DiningCombat.DataObject;
using DiningCombat.Manger;
using DiningCombat.NPC;
using DiningCombat.Util;
using System;
using UnityEngine;

namespace DiningCombat.Environment
{
    public class EnvironmentManger : MonoBehaviour
    {
        private bool m_IsEnding;
        private GraphDC m_WaterGraph;
        [SerializeField]
        private SpawnDataSO m_SpawnData;
        [SerializeField]
        private DiningCombat.Environment.Room m_RoomDimension;
        [SerializeField]
        private GameObject m_WaterPrefab;
        [SerializeField]
        private TimeBuffer m_WaterTimer;
        [SerializeField]
        private GameObject m_WaterObject;
        [SerializeField]
        private TimeBuffer m_NpcTimer;
        public bool IsInit { get; private set; }

        private void Awake()
        {
            m_WaterGraph = new GraphDC((int)m_RoomDimension.Higet, (int)m_RoomDimension.Width, m_RoomDimension.m_Center, new Action<Vector3>(SpawnWater));
            m_WaterGraph.OnEnding += WaterGraph_OnEnding;

            IsInit = true;
            m_IsEnding = false;
        }
        private void Start()
        {
            GameOverLogic.Instance.GameOverOccured += GameOverLogic_GameOverOccured;
        }

        private void GameOverLogic_GameOverOccured()
        {
            m_IsEnding = true;
        }

        private void WaterGraph_OnEnding()
        {
            m_IsEnding = true;
        }

        private void SpawnWater(Vector3 i_Pos)
        {
            GameObject water = Instantiate(m_WaterPrefab, i_Pos, Quaternion.identity);
            water.transform.parent = m_WaterObject.transform;
        }

        void Update()
        {
            if (m_IsEnding)
            {
                return;
            }

            if (m_WaterTimer.IsBufferOver())
            {
                m_WaterGraph.Activate();
                m_WaterTimer.Clear();
            }

            if (m_NpcTimer.IsBufferOver())
            {
                m_NpcTimer.Clear();
                FollowWP chicken = ChickenPool.Instance.Get();
                chicken.transform.position = m_RoomDimension.GetRendonPos();
                chicken.gameObject.SetActive(true);
            }
        }
    }
}