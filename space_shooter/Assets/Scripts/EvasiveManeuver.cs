using UnityEngine;
using System.Collections;

public class EvasiveManeuver : MonoBehaviour
{

    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundary boundary;

    private float targetManeuver;
    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine (Evade ());
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds (Random.Range (startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range (1, dodge) * -Mathf.Sign (transform.position.x);
            yield return new WaitForSeconds (Random.Range (maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds (Random.Range (maneuverWait.x, maneuverWait.y));
        }
    }

    void FixedUpdate ()
    {
        float newManeuver = Mathf.MoveTowards (rb.velocity.x,
																							 targetManeuver,
																							 Time.deltaTime * smoothing);
        rb.velocity = new Vector3 (newManeuver, 0.0f, rb.velocity.z);
        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            rb.position.z
        );

        rb.rotation = Quaternion.Euler (rb.rotation.x, rb.rotation.y, rb.velocity.x * -tilt);
    }
}
