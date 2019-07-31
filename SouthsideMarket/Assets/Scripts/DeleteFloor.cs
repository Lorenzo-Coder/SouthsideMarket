using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteFloor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Grocery"))
        {
            Destroy(collision.gameObject);
        }
    }
}
