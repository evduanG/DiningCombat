﻿using Assets.Scripts.Player.PlayrAbstraction.ActionHand;
using DiningCombat.Player.Manger;
using UnityEngine;

namespace DiningCombat.Player.Offline.State
{
    internal class StatePoweringOffline : StatePowering
    {
        public StatePoweringOffline(PlayerHand i_PickUpItem, OfflinePlayerStateMachine i_Machine) 
            : base(i_PickUpItem, i_Machine)
        {
        }

        protected override bool IsPassStage()
        {
            if (this.IsBufferTime)
            {
                Debug.Log("IsBufferTime " + Input.GetKeyUp(KeyCode.E));
                return Input.GetKeyUp(KeyCode.E);
            }

            return false;
        }
    }
}
