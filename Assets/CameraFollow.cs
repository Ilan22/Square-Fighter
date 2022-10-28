using UnityEngine;

public class CameraFollow : MonoBehaviour{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = .25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    private static float shakeDuration = 0f;

    private static float shakeAmount = 0.7f;

    private float vel;
    private Vector3 vel2 = Vector3.zero;
    Vector3 originalPos;

    public Transform player;

    void Awake(){
        originalPos = transform.localPosition;
    }

    void FixedUpdate(){
        originalPos = transform.localPosition;

        if (shakeDuration > 0){
            Vector3 newPos = originalPos + Random.insideUnitSphere * shakeAmount;

            transform.localPosition = Vector3.SmoothDamp(originalPos, newPos, ref vel2, 0.05f);

            shakeDuration -= Time.deltaTime;
            shakeAmount = Mathf.SmoothDamp(shakeAmount, 0, ref vel, 0.7f);

            move();
        }
        else{
            move();
        }
    }

    private void move(){
        Vector3 targetPosition = target.position + offset / 2;
        transform.localPosition = Vector3.SmoothDamp(transform.localPosition, targetPosition, ref velocity, smoothTime);
    }

    public void ShakeOnce(float lenght, float strength){
        shakeDuration = lenght;
        shakeAmount = strength;
    }
}
