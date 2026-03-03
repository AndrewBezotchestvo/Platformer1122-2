using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _maxHp = 100;
    private float _hp;
    private float _coins;

    void Start()
    {
        _coins = 0;
        _hp = _maxHp;

        _hp = PlayerPrefs.GetFloat("HP", _hp);
        _coins = PlayerPrefs.GetFloat("Coins", _coins);
        PlayerPrefs.SetInt("Level", SceneManager.GetActiveScene().buildIndex);
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
        PlayerPrefs.SetFloat("Coins", _coins);
    }

    public void GetDamage(float damage)
    {
        _hp -= damage;
        PlayerPrefs.SetFloat("HP", _hp);
    }

    private void OnDisable()
    {
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        _hp = PlayerPrefs.GetFloat("HP", _hp);
        _coins = PlayerPrefs.GetFloat("Coins", _coins);
    }
}
