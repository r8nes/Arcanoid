using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBlock : MonoBehaviour
{
#if UNITY_EDITOR
    public BlockData BlockData;
#endif
}
