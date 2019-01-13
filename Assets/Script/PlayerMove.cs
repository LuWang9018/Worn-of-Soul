﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : TacticMove {

	// Use this for initialization
	void Start () {
        Init();
	}

    // Update is called once per frame
    void Update() {
        Debug.DrawRay(transform.position, transform.forward);
        if (!turn)
        {
            return;
        }

        if (!moving)
        {
            FindSelectableTiles();
            CheckMouse();
        }
        else
        {
            Move();
        }
	}
    void CheckMouse()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                if(hit.collider.tag == "Tile")
                {
                    TileScript t = hit.collider.GetComponent<TileScript>();
                    if (t.selectable)
                    {
                        MoveToTile(t);
                    }
                } 
            }
        }
    }
}
