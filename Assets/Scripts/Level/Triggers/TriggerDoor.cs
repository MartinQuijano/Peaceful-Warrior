using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public DoorController[] doors;
    public bool isOpener;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().GetFrozen();
            foreach(DoorController door in doors)
                door.SetOpen(isOpener);
            Destroy(this);
        }
    }

}
