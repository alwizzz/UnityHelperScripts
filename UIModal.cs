using UnityEngine;
using System.Linq;

public abstract class UIModal<T> : StaticReference<T>
{
    protected GameObject handler;

    protected override void BaseAwake(T tInstance)
    {
        base.BaseAwake(tInstance);
        handler = FindIgnoreCase("Handler").gameObject;
        if(handler == null) 
        {
            print("ERROR: handler cant be found");
            return;
        }
        Hide();
    }

    public virtual void Hide()
    {
        if (handler == null)
        {
            print("ERROR: handler cant be found");
            return;
        }
        handler.SetActive(false);
    }

    public virtual void Show()
    {
        if (handler == null)
        {
            print("ERROR: handler cant be found");
            return;
        }
        handler.SetActive(true);
    }

    // Helper to enable doing Find() in case insensitive
    protected Transform FindIgnoreCase(string name)
    {
        return (
            from t in GetComponentsInChildren<Transform>(true)
            where t.name.Equals(name, System.StringComparison.OrdinalIgnoreCase)
            select t
        ).FirstOrDefault();
    }


}
