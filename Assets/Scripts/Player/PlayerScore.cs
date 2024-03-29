﻿using DiningCombat.FoodObject;
using System;
using UnityEngine;
namespace DiningCombat.UI
{
    public class PlayerScore : MonoBehaviour
    {
        public event Action<float> OnPlayerScorePointChanged;
        public event Action<int> OnPlayerKillsChanged;
        private float m_ScorePoint;
        private int m_Kills;

        public float ScorePoint
        {
            get => m_ScorePoint;
            private set
            {
                m_ScorePoint = value;
                OnPlayerScorePointChanged?.Invoke(m_ScorePoint);
            }
        }
        public int Kills
        {
            get => m_Kills;
            private set
            {
                m_Kills = value;
                OnPlayerKillsChanged?.Invoke(m_Kills);
            }
        }

        public void HitPlayer(Collision collision, float hitPoint, int kill)
        {
            if (DidIHurtMyself(collision))
            {
                Debug.Log("you stupid son of a bitch? You hurt yourself");
            }
            else
            {
                ScorePoint += hitPoint;
                Kills += kill;
            }
        }

        public void UpdatePlayerScore(IThrownState.HitPointEventArgs i_HitPointEvent)
        {
            ScorePoint += i_HitPointEvent.m_Damage;
            Kills += i_HitPointEvent.m_Kills;
        }
        private bool DidIHurtMyself(Collision collision)
        {
            return gameObject.Equals(collision.gameObject);
        }
    }
}