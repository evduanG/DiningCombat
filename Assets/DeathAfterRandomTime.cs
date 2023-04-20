using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;
public class DeathAfterRandomTime : MonoBehaviour
{
    [SerializeField] float m_LivingTime;

    public bool isAlive { get; internal set; }

    public event Action <bool> CubeDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        m_LivingTime = Random.Range(3f, 7f);
        StartCoroutine(killerCube());
    }
    private void OnDestroy()
    {
        CubeDestroyed?.Invoke(isAlive);
    }
    IEnumerator killerCube()
    {
        yield return new WaitForSeconds(m_LivingTime);
        Destroy(gameObject);
    }
}
