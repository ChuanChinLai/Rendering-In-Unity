using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTransformation : Transformation
{
    public Vector3 vec3 = Vector3.one;

    public override Vector3 Apply(Vector3 point)
    {
        point.x *= vec3.x;
        point.y *= vec3.y;
        point.z *= vec3.z;

        return point;
    }
}
