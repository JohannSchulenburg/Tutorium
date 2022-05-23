using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationFix : MonoBehaviour
{
    public Transform pawn;
    void Update()
    {
        gameObject.transform.position = new Vector3(pawn.position.x, pawn.position.y, -10);
        gameObject.transform.rotation = Quaternion.Euler(0,0,0);
    }
}
