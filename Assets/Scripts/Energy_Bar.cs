using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Energy_Bar : MonoBehaviour
{
    public Slider energy_Bar;

    public float maxEnergy = 100;
    public float currentEnergy;

    public WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    public Coroutine regen;
    public Coroutine recharge;

    public static Energy_Bar instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentEnergy = maxEnergy;
        energy_Bar.maxValue = maxEnergy;
        energy_Bar.value = maxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseEnergy(float amount)
    {
      if(currentEnergy - amount >= 5f)
      {
            currentEnergy -= amount;
            energy_Bar.value = currentEnergy;

            if (regen != null)
                StopCoroutine(regen);

            regen = StartCoroutine(RegenEnergy());
      }
      else
      {
            currentEnergy -= amount;
            energy_Bar.value = currentEnergy;

            if (recharge != null)
                StopCoroutine(recharge);

            recharge = StartCoroutine(RechargeEnergy());
            Debug.Log("Not enough energy");
       }
      
    }

    public IEnumerator RegenEnergy()
    {
            
            yield return new WaitForSeconds(1.5f);
           
        while (currentEnergy > 5f)
        {
                currentEnergy += maxEnergy / 25f;
                energy_Bar.value = currentEnergy;
                yield return regenTick;
        }
        regen = null;
    }
    public IEnumerator RechargeEnergy()
    {
            
            yield return new WaitForSeconds(3f);
            
            while (currentEnergy < 5)
            {
                Debug.Log("Recharging!");
                currentEnergy += maxEnergy / 100f;
                energy_Bar.value = currentEnergy;
                yield return regenTick;

            }
        regen = null;   
    }
     
}
