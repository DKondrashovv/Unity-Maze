using UnityEngine;
public class FireballHero : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 1;
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        /*PlayerCharacter player = other.GetComponent<PlayerCharacter>();//заменить на wanderingAI
        if (player != null)
        {
            player.Hurt(damage);
        }*/
        
        {
         ReactiveTarget target = other.GetComponent<ReactiveTarget>();
        if(target!=null)
        {
         target.ReactToHit();
        }
        }
        Destroy(this.gameObject);
    }
}