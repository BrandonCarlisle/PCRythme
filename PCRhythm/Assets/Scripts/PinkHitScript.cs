﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkHitScript : MonoBehaviour
{
    void Start()
    {
        InputManager.onPinkPressed += hitCheck;
    }

    void Update()
    {
    }

    void hitCheck()
    {
        Debug.Log("pink called");
        Vector3 offset2 = new Vector3(0.5f, 0, 0);
        Vector3 offset3 = new Vector3(-0.5f, 0, 0);

        Ray ray = new Ray(transform.position, -transform.forward);
        Ray ray2 = new Ray(transform.position + offset2, -transform.forward);
        Ray ray3 = new Ray(transform.position + offset3, -transform.forward);

        RaycastHit hit;
        RaycastHit hit2;
        RaycastHit hit3;

        if (Physics.Raycast(ray, out hit, 100))
            colliderCheck(hit, 0);
        else if (Physics.Raycast(ray2, out hit2, 100))
            colliderCheck(hit2, 1);
        else if (Physics.Raycast(ray3, out hit3, 100))
            colliderCheck(hit3, 2);

    }

    void colliderCheck(RaycastHit hit, int offset)
    {
        if (hit.collider.tag.Equals("SingleNotePink"))
        {
            GameObject hitSingleNote = hit.transform.gameObject;
            try
            {
                NoteControl noteControl = hitSingleNote.GetComponent(typeof(NoteControl)) as NoteControl;
                noteControl.Hit();
            }
            catch (Exception ex) {
                Debug.Log(ex.Message);
            }
        }
    }


    void OnDisable()
    {
        InputManager.onPinkPressed -= hitCheck;
    }
}
