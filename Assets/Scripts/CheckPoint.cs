using UnityEngine;
using System.Collections;


[RequireComponent(typeof (BoxCollider2D))]
public class CheckPoint : MonoBehaviour 
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

        }
    }
}
