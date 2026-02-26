using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    [SerializeField] private AudioClip _brickClip;
    [SerializeField] private int _maxHealth = 3;
    private AudioSource _source;
    private SpriteRenderer _sprite;
    private int _health;

    private void Start()
   {
    _sprite = GetComponent<SpriteRenderer>();
    _source = GetComponent<AudioSource>();
    _health = _maxHealth;
    UpdateAlpha();
   }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        
            _source.PlayOneShot(_brickClip);
            _health--;

        if (_health <= 0) 
        {
            GameBehavior.Instance.Score +=1;
            Destroy(gameObject);
        }
        else
         {
             UpdateAlpha();   
         }
    }
     private void UpdateAlpha()
    {
        float alpha = (float)_health / _maxHealth;
        Color c = _sprite.color;
        c.a = alpha;
        _sprite.color = c;
    }
    

}