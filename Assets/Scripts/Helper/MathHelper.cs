using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathHelper
{
    public static Quaternion GenerateRandomDirectionRotation(Quaternion baseRotation, float deviationAngle)
    {
        // create a random angle around target direction
        Quaternion randomRotation = Quaternion.Euler(
            Random.Range(-deviationAngle, deviationAngle),
            Random.Range(-deviationAngle, deviationAngle),
            Random.Range(-deviationAngle, deviationAngle)
        );

        // Create quaternion from that direction
        return baseRotation * randomRotation;
    }
}
