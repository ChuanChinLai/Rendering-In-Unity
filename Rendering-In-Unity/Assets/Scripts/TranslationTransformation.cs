using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationTransformation : Transformation
{
    public Vector3 vec3;

    public override Vector3 Apply(Vector3 point)
    {
        return point + vec3;
    }
}
