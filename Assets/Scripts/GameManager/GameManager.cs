using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public static GameManager gameManager { get; private set; }
    GameObject player;

    public void Awake()
    {
        gameManager = this;
    }

    public void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void KillPlayer()
    {
        StartCoroutine(KillPlayerCo());
    }

    private IEnumerator KillPlayerCo()
    {
        //player.KillPlayer();
        yield return new WaitForSeconds(10f);

    }

    

}
