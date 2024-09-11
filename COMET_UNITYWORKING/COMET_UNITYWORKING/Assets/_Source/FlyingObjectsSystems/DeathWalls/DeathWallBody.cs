using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWallBody : MonoBehaviour
{
    [SerializeField] public LayerMask triggerLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayer & (1 << collision.gameObject.layer)) != 0)
        {

        }
    }
}
