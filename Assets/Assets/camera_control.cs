using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_control : MonoBehaviour
{
    public Transform target;
    public Vector3 offsetPos;
    public float movespeed = 5;
    public float turnspeed = 10;
    public float smoothspeed = 0.5f;

    Quaternion targetRotation;
    Vector3 targetPos;
    bool smoothRotating = false;


    

    // Update is called once per frame
    void Update()
    {
        MoveWithTarget();
        LookTarget();
        if (Input.GetKeyDown(KeyCode.G) && !smoothRotating)
        {
            StartCoroutine("rotateAroundTarget", 45);
        }
        if (Input.GetKeyDown(KeyCode.H) && !smoothRotating)
        {
            StartCoroutine("rotateAroundTarget", -45);
        }
    }
    void MoveWithTarget()
    {
        targetPos = target.position + offsetPos;
        transform.position = Vector3.Lerp(transform.position, targetPos, movespeed * Time.deltaTime);
    }
    void LookTarget()
    {
        targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnspeed * Time.deltaTime);
    }

    IEnumerator RotateAroundTarget(float angle)
    {
        Vector3 vel = Vector3.zero;
        Vector3 targetOffsetPos = Quaternion.Euler(0, angle, 0) * offsetPos;
        float dist = Vector3.Distance(offsetPos, targetOffsetPos);
        while (dist > 0.02f)
        {
            offsetPos = Vector3.SmoothDamp(offsetPos, targetOffsetPos, ref vel, smoothspeed);
            dist = Vector3.Distance(offsetPos, targetOffsetPos);
            yield return null;

        }
        smoothRotating = false;
        offsetPos = targetOffsetPos;

    }
}

