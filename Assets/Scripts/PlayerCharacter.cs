using UnityEngine;
public class PlayerCharacter : MonoBehaviour
{
   [SerializeField] private int _health;
    void Start()
    {
        _health = 5;
    }

    public void Hurt(int damage)
    {
        _health -= damage;
        Debug.Log("Health: " + _health);
    }
    void Update()
    {
        if (_health <= 0)
        {
            Destroy(this.gameObject);

        }
    }

}
