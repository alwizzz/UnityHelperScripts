using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticCoroutine : StaticReference<StaticCoroutine>
{
    private void Awake()
    {
        BaseAwake(this);
    }

    private void OnDestroy()
    {
        BaseOnDestroy();
    }

    public static Coroutine StartStaticCoroutine(IEnumerator coroutine)
    {
        return instance.StartCoroutine(coroutine);
    }
}
