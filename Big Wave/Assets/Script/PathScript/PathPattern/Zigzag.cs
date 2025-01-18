using UnityEngine;

public class Zigzag : PathBase
{
    // �������钷��
    
    [SerializeField] private float length = 50;
    [SerializeField]  GameObject target;
    public float speed = 10;
    public override void OnEnter(PathBase roadBases_Entry)
    {
        
    }
    public override void OnUpdate()
    {
        // ���������l�����Ԃ���v�Z
        var value = Mathf.PingPong(Time.time * speed, length) - length / 2; ;

        target.transform.Translate(Vector3.right * value * Time.deltaTime);
        
    }
    public override void OnExit(PathBase roadBases_Exit)
    {
      
    }
}