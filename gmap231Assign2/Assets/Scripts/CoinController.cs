using UnityEngine;
using System.Collections;

public class CoinController : MonoBehaviour
{
    public float bounceSpeed = 1f;
    public float bounceDelta = 0.25f;
    private float originY;

    private void Start()
    {
        originY = transform.position.y;
        GameEvents.current.onCoinPickup += HandleCoinPickup;
    }
    private void OnDisable()
    {
        GameEvents.current.onCoinPickup -= HandleCoinPickup;
    }

    private void HandleCoinPickup(int _id)
    {
        if (_id == gameObject.GetInstanceID()) {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        // rotate coin in y axis (x here beause coin model rotated 90 on z)
        transform.Rotate(30 * Time.deltaTime, 0f, 0f);

        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * bounceSpeed) * bounceDelta + originY;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }
}