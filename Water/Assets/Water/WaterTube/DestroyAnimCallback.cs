using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAnimCallback : MonoBehaviour
{
    private void AnimationCallback_Destroy()
    {
        Destroy(gameObject);
    }
}
