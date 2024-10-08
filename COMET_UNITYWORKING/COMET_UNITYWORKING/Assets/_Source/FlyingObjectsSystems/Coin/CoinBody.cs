using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBody : MonoBehaviour
{
    [SerializeField] private LayerMask triggerLayerPlayer;
    [SerializeField] private LayerMask triggerLayerKillWall;
    public ObjectPool objectPool { private get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayerPlayer & (1 << collision.gameObject.layer)) != 0)
        {
            objectPool.ReturnObject(this.gameObject);
        }
        if ((triggerLayerKillWall & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("RETURN");
            objectPool.ReturnObject(this.gameObject);
        }
    }
}
