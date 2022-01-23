using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TransformData
{
    public string     m_name;
    public Vector3    m_position;
    public Quaternion m_rotation;
    public Vector3    m_scale;

    public TransformData () {}

    public TransformData (Transform data, string name)
    {
        m_name     = name;
        m_position = data.position;
        m_rotation = data.rotation;
        m_scale    = data.localScale;
    }
}
