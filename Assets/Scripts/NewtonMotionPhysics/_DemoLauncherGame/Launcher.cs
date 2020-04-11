using UnityEngine;

public class Launcher : MonoBehaviour
{
    public ObjectBody ball;
    public float maxVelocity;
    public AudioClip[] music;
    private AudioSource audioSource;
    private float startVel;
    private float velIncRate;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        velIncRate = maxVelocity * Time.deltaTime / music[0].length;
    }

    void OnMouseDown()
    {
        startVel = 0f;
        audioSource.clip = music[0];
        audioSource.Play();
        InvokeRepeating("IncreasingSpeed", 0.5f, Time.deltaTime);
    }

    void OnMouseUp()
    {
        CancelInvoke("IncreasingSpeed");
        audioSource.clip = music[1];
        audioSource.Play();
        ObjectBody football = Instantiate(ball) as ObjectBody;
        football.transform.parent = GameObject.Find("BallParent").transform;
        football.objectVelocity = football.objectVelocity.normalized * startVel;
    }

    void IncreasingSpeed()
    {
        if (startVel < maxVelocity)
        {
            startVel += velIncRate;
        }
    }
}
