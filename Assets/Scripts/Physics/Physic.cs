using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Physic : MonoBehaviour
{
    private Vector2 _velocity;
    private float TimeScale = 1f;
    
    public float MinImpulseX = 0.07f;
    public float MaxImpulseX = 0.07f;
    public float MinImpulseY = 0.08f;
    public float MaxImpulseY = 0.13f;

    public void Start()
    {
        SetPointWhereToFly(Vector3.one);
    }
    void Update()
    {
        var position = transform.position;
        Vector2 tempPosition = position;
        Vector3 newPosition =  _velocity * (Time.deltaTime * 0.07f * TimeScale);
        //position = Vector2.MoveTowards(position, newPosition, 0.07f);
        transform.position += newPosition;

        _velocity.y = ApplyGravity(_velocity.y);
    }
    
    public void SetPointWhereToFly(Vector3 pointPosition)
    {
        pointPosition = Vector3.forward;
        Vector2 _moveDirection = pointPosition - transform.position;

        float impulseX = Random.Range(1, 2);
        float impulseY = Random.Range(1, 2);

        _velocity = new Vector2(_moveDirection.x * impulseX, _moveDirection.y * impulseY);
    }
    
    private float ApplyGravity(float number)
    {

        number -= 0.7f * Time.deltaTime * TimeScale;

        return number;
    }
}
