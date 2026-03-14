using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
