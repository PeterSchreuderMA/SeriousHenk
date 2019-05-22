using UnityEngine;

public class Target : MonoBehaviour
{
    public float entityHealthMax = 100f;
    public float entityHealthCurrent = 50f;

    public void TakeDamage(float _amount)
    {
        entityHealthCurrent -= _amount;
        entityHealthCurrent = Mathf.Clamp(entityHealthCurrent, 0f, entityHealthMax);

        if (entityHealthCurrent == 0f)
        {
            EntityDie();
        }
    }

    void EntityDie()
    {
        Destroy(gameObject);
        print("Killed entity");
    }

}
