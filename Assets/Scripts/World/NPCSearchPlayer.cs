using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSearchPlayer : MonoBehaviour
{
    NPCFighter npcFighter;

    [Range(0f,5f)]
    public float searchRythm;
    public float walkSpeed;

    bool isPlayerFound = false;


    // Start is called before the first frame update
    void Start()
    {
        npcFighter = GetComponent<NPCFighter>();
        if (npcFighter != null ) 
        {
            if ( !npcFighter.GetDefeated() )
            {
                InvokeRepeating("SearchPlayer", 0.001f, searchRythm);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerFound)
        {
            FollowPlayer();
        }
    }

    //funktion mit raycast um spieler zu finden distanz 5 unity einheiten
    void SearchPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Player found");
                isPlayerFound = true;
            }
        }
    }

    //funktion mit raycast um spieler zu finden distanz 5 unity einheiten
    //wenn gefunden zum spieler laufen
    //falls spieler nichtmehr im umkreis ist wieder suchen

    void FollowPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                Debug.Log("Player in Target");
                transform.position = Vector3.MoveTowards(transform.position, hit.collider.gameObject.transform.position, walkSpeed * Time.deltaTime);
                transform.LookAt(hit.collider.gameObject.transform);
            }
            else
            {
                Debug.Log("Player not in Target");
                isPlayerFound = false;
            }
        }
    }
}
