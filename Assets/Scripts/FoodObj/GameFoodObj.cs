﻿using DiningCombat;
using System;
using UnityEngine;
using UnityEngine.VFX;
using Assets.Scripts.Player;
using static UnityEngine.ParticleSystem;
using Assets.Scripts.Player.PickUpItem;

public class GameFoodObj : MonoBehaviour
{
    // ================================================
    // constant Variable 
    private const bool k_Enter = true, k_Exit = false;
    private const string k_ClassName = nameof(GameFoodObj);
    // ================================================
    // Delegate
    /// <summary>to notify the thrower that he hit</summary>
    public event EventHandler HitPlayer;

    /// <summary>to notify Game-Manager that this GameFoodObj destroyed</summary>
    public event EventHandler Destruction;

    // ================================================
    // Fields 
    private bool m_IsThrow;
    private Rigidbody m_Rigidbody;

    [SerializeField]
    private ParticleSystem m_Effect;
    // ================================================
    // ----------------Serialize Field-----------------

    // ================================================
    // properties
    public bool IsThrow 
    {
        get => m_IsThrow;
        private set
        {
            tag = GameGlobal.TagNames.k_ThrowFoodObj;
            m_IsThrow = value;
        }
    }

    // ================================================
    // auxiliary methods programmings

    // ================================================
    // Unity Game Engine
    protected virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //m_Effect.Stop();
    }

    // ================================================
    //  methods
    /// <summary>
    /// this method can call one time for obj 
    /// </summary>
    /// <param name="i_ForceMulti"> the Force to add</param>
    /// <param name="i_ThrowDirection"></param>
    public void ThrowFood(float i_ForceMulti, Vector3 i_ThrowDirection)
    {
        IsThrow = true;
        transform.parent = null;
        m_Rigidbody.useGravity = true;
        m_Rigidbody.AddForce(i_ThrowDirection * i_ForceMulti);
    }

    internal void SetPickUpItem(IThrowingGameObj i_PickUpItem)
    {
        GameObject pickUpItem = i_PickUpItem.gameObject;
        this.transform.position = pickUpItem.transform.position;
        this.transform.SetParent(pickUpItem.transform, false);
        this.transform.localPosition = pickUpItem.transform.localPosition;

        if (i_PickUpItem is HandPickUp)
        {
            Debug.Log("pickUpItem is HandPickUp");
            m_Rigidbody.useGravity = false;
        }
    }
    /// <summary>
    /// collision After Throwing Handler will:
    /// 1. will tell the throw player if it hit the player
    /// 2. will perform the effect
    /// 3. will destroy the object
    /// </summary>
    /// <param name="i_Collision"></param>
    private void collisionAfterThrowingHandler(Collision i_Collision)
    {
        if (isPlayer(i_Collision))
        {
            OnHitPlayer(EventArgs.Empty);
            PlayerHp playerHit = i_Collision.gameObject.GetComponent<PlayerHp>();

            if (playerHit != null)
            {
                playerHit.HitYou(1f);
            }
        }

        performTheEffect();
        destruction();
    }

    private bool performTheEffect()
    {
        ParticleSystem effect = Instantiate(m_Effect, transform.position, transform.rotation);
        effect.Play();
        Destroy(effect, 1.5f);
        return true;
    }


    // ================================================
    // auxiliary methods

    /// <summary>
    /// a query to test if Collision tag as Player
    /// </summary>
    /// <param name="i_Collision"></param>
    /// <returns></returns>
    private bool isPlayer(Collision i_Collision)
    {
        return i_Collision.gameObject.CompareTag(GameGlobal.TagNames.k_Player);
    }


    // ================================================
    // Delegates Invoke 

    // ================================================
    // ----------------Unity--------------------------- 

    /// <summary>
    /// this Delegates 
    /// </summary>
    /// <param name="i_Collision"></param>
    protected virtual void OnCollisionEnter(Collision i_Collision)
    {
        if (IsThrow)
        {
            collisionAfterThrowingHandler(i_Collision);
        }
    }

    // ----------------GameFoodObj---------------------
    protected virtual void OnHitPlayer(EventArgs e)
    {
        HitPlayer?.Invoke(this, e);
    }

    private void destruction()
    {
        OnDestruction(EventArgs.Empty);
        Destroy(this.gameObject, 1);
    }

    protected virtual void OnDestruction(EventArgs e)
    {
        Destruction?.Invoke(this, e);
    }

    internal void CleanUpDelegatesPlayer()
    {
        //HitPlayer
    }
}


//if (isPlayer(i_Collision) && !IsThrow)
//{
//    notifyPlayerPickUp(i_Collision, k_Enter);
//}
//else

/// <summary>
/// this wiil notify the Player thet he cant PickUp this
/// </summary>
/// <param name="i_Collision"></param>
//protected virtual void OnCollisionExit(Collision i_Collision)
//{
//    if (isPlayer(i_Collision) && !IsThrow)
//    {
//        notifyPlayerPickUp(i_Collision, k_Exit);
//    }
//}



/// <summary>
/// this func notify the PickUpItem (Player)
/// interface IStatePlayerHand - cant or can Pick-Up this item
/// </summary>
/// <param name="i_Collision"></param>
/// <param name="i_IsEnter">
/// <true>true->Enter-Collision-Food-Obj</true>
/// <false>false->ExitCollisionFoodObj</false></param>
//private void notifyPlayerPickUp(Collision i_Collision, bool i_IsEnter)
//{
//    if (parseCollision(i_Collision, out HandPickUp o_Pick))
//    {
//        if (i_IsEnter)
//        {
//            o_Pick.StatePlayer.EnterCollisionFoodObj(this.gameObject);
//        }
//        else
//        {
//            o_Pick.StatePlayer.ExitCollisionFoodObj();
//        }
//    }
//}


/// <summary>
/// this func parsing form Collision PickUpItem 
/// </summary>
/// <param name="i_Collision"></param>
/// <param name="o_Pic"></param>
/// <returns>if parsing success </returns>
//private bool parseCollision(Collision i_Collision, out HandPickUp o_Pic)
//{
//    o_Pic = i_Collision.gameObject
//        .GetComponentInChildren(typeof(HandPickUp)) as HandPickUp;

//    return (o_Pic != null);
//}
