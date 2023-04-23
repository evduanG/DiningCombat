using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerAnimationChannel : MonoBehaviour
{

    Animator m_Anim;
    public event Action ThrowPoint;
    public event Action OnRunFast; 

    private void Awake()
    {
        m_Anim = GetComponent<Animator>();
        ThrowPoint += () => StartCoroutine(StopAnimationToThrow());
    }

    private IEnumerator StopAnimationToThrow()
    {
        yield return null;
        yield return null;
        m_Anim.SetBool("isThrow", false);
        m_Anim.SetBool("isThrow2", false);
    }

    public void EnterThrowPoint()
    {
        Debug.Log("Enter throw point");
        ThrowPoint?.Invoke();
    }

    public void SetPlayerAnimationToRunFast(bool i_IsActive)
    {
        m_Anim.SetBool("isRunFast", i_IsActive); 
    }


    public event Action onThrowPoint;
    //public event Action OnRunFast; 
    [SerializeField] private GameObject pickUpPoint;


    public void SetPlayerAnimationToRunFast()
    {
        m_Anim.SetBool("isRunFast", true);

    }

    public void RunFast()
    {
        OnRunFast?.Invoke();
    }

    public void SetPlayerAnimationToRun(bool i_IsActive)
    {
        m_Anim.SetBool("isRun", i_IsActive);
    }

    public void SetPlayerAnimationToThrow(bool i_IsActive)
    {
        m_Anim.SetBool("isThrow", i_IsActive);
    }

    public void SetPlayerAnimationToRunBack(bool i_IsActive)
    {
        m_Anim.SetBool("isRunBack", i_IsActive);
    }

    public void SetPlayerAnimationToIdleFall(bool i_IsActive)
    {
        m_Anim.SetBool("isIdleFall", i_IsActive);
    }

    public void SetPlayerAnimationToJump(bool i_IsActive)
    {
        m_Anim.SetBool("isJump", i_IsActive);
    }

    public void SetPlayerAnimationToThrow2(bool i_IsActive)
    {
        m_Anim.SetBool("isThrow2", i_IsActive);
    }

    public void SetPlayerAnimationToWin(bool i_IsActive)
    {
        m_Anim.SetBool("isWin", i_IsActive);
    }
    public void SetPlayerAnimationToRun()
    {
        m_Anim.SetBool("isRun", true);
    }

    public void SetPlayerAnimationToThrow()
    {
        m_Anim.SetBool("isThrow", true);
    }

    public void SetPlayerAnimationToRunBack()
    {
        m_Anim.SetBool("isRunBack", true);
    }

    public void SetPlayerAnimationToIdleFall()
    {
        m_Anim.SetBool("isIdleFall", true);
    }

    public void SetPlayerAnimationToJump()
    {
        m_Anim.SetBool("isJump", true);
    }

    public void SetPlayerAnimationToThrow2()
    {
        m_Anim.SetBool("isThrow2", true);
    }

    public void SetPlayerAnimationToWin()
    {
        m_Anim.SetBool("isWin", true);
    }
}
