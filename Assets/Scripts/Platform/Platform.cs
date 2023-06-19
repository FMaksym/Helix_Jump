using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bouceForce;
    [SerializeField] private float _bounceRadius;

    public void Brake()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach (var segment in platformSegments)
        {
            segment.Bounce(_bouceForce, transform.position, _bounceRadius);
        }
        WaitAndDestroy(3);
    }

    public void Destroyer()
    {
        if (gameObject.tag == "Platform Element")
        {
            WaitAndDestroy(10);
            Destroy(gameObject);
        }
    }

    IEnumerator WaitAndDestroy(float time) 
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
