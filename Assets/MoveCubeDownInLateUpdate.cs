using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeDownInLateUpdate : MonoBehaviour
{
    void LateUpdate() => transform.Translate(-0.0f, -2, 0);
    
}
