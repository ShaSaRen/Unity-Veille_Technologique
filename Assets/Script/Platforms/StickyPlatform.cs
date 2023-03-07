using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    //Il ne faut pas oublier d'ajouter un BoxCollider2D en mode "isTrigger" pour savoir si on rentre bien dans la zone pour être attacher à la platforme
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
