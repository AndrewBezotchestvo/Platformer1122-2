using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxHp = 100;
    private float _hp;
    private float _coins;

    void Start()
    {
        _coins = 0;
        _hp = _maxHp;
    }

    public float GetHp()
    {
        return _hp;
    }
    public float GetCoins()
    {
        return _coins;
    }
    
    public void AddCoin()
    {
        _coins++;
    }

    public void GetDamage(float damage)
    {
        _hp -= damage;
    }

}
