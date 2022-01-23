using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveableMonoBehaviour : MonoBehaviour
{
    public virtual void SetData (TransformData data)
    {
	    transform.SetPositionAndRotation(data.m_position, data.m_rotation);
        transform.localScale = data.m_scale;
	}

    public virtual TransformData GetData ()
    {
	    TransformData data = new TransformData(transform, gameObject.name);
        return data;
	}
}
