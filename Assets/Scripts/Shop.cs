using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;
    private int _upgradeCountBoomerangDmg = 0;
    private int _upgradeCountBoomerangAmount = 0;
    private int _upgradeCountBoomerangDistance = 0;

    [SerializeField] private TextMeshProUGUI boomerangDamageUpgradeText;
    [SerializeField] private TextMeshProUGUI boomerangAmountUpgradeText;
    [SerializeField] private TextMeshProUGUI boomerangDistanceUpgradeText;

    // Start is called before the first frame update
    void Start()
    {
        BoomerangProjectile.AddDistance(5);
        BoomerangProjectile.AddDamage(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyDamage()
    {
        ++_upgradeCountBoomerangDmg;
        BoomerangProjectile.AddDamage(1);
        boomerangDamageUpgradeText.text = _upgradeCountBoomerangDmg.ToString();
        DisableShop();
    }

    public void BuyAmount()
    {
        ++_upgradeCountBoomerangAmount;
        PlayerController.AddBoomerangAmount();
        boomerangAmountUpgradeText.text = _upgradeCountBoomerangAmount.ToString();
        DisableShop();
    }

    public void BuyDistance()
    {
        ++_upgradeCountBoomerangDistance;
        BoomerangProjectile.AddDistance(2);
        boomerangDistanceUpgradeText.text = _upgradeCountBoomerangDistance.ToString();
        DisableShop();
    }

    public void EnableShop()
    {
        _canvas.SetActive(true);
    }

    public void DisableShop()
    {
        _canvas.SetActive(false);
    }
}