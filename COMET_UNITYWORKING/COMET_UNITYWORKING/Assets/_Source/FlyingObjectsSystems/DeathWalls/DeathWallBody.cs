using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWallBody : MonoBehaviour
{
    [SerializeField] public LayerMask triggerLayerPlayer;
    [SerializeField] public LayerMask triggerLayerKillWall;
    public ObjectPool objectPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((triggerLayerPlayer & (1 << collision.gameObject.layer)) != 0)
        {
            SceneManager.LoadScene(0);
        }
        if ((triggerLayerKillWall & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("RETURN");
            objectPool.ReturnObject(this.gameObject);
        }
        Debug.Log("RETURN");
    }
}
