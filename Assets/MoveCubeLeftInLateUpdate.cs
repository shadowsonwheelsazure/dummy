using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCubeLeftInLateUpdate : MonoBehaviour
{
    void LateUpdate() => transform.Translate(-2.0f, 0.0f, 0);
}
