using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public Transform player;
    private bool hasCollider;
    public Transform woodPlatform;
    public GameObject woodObject;
    public KeyCode PlatformcolliderDisappear;
    private bool holdingS;

    void Update()
    {

        if (Input.GetKeyDown(PlatformcolliderDisappear))
        {
            Destroy(GetComponent<BoxCollider2D>());
            holdingS = true;
            hasCollider = false;
        }
        else if (Input.GetKeyUp(PlatformcolliderDisappear))
        {
            holdingS = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate () {

        if (player.position.y - 0.7 <= woodPlatform.position.y + 0.5)
        {
            if (hasCollider)
            {
                Destroy(GetComponent<BoxCollider2D>());
                hasCollider = false;
            }
            
        }
        else if (player.position.y - 0.9 >= woodPlatform.position.y + 0.5)
        {
            if (!hasCollider && !holdingS)
            {
                BoxCollider2D collider = woodObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
                hasCollider = true;
            }
        }
	}
}
