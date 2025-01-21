using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CustomerController : MonoBehaviour
{
    /// TODO: 
    /// Spawn Customers at a certain rate per timeframe -- Depend on maybe level? (difficulty)
    /// Customer will generate order
    /// Customer will move into game view
    /// On completion, customer
    /// Keep track of customer list --> Slot number (slot 1, 2, 3)
    /// When customer comes in, slide from right
    /// When customer leaves, slides to left off screen
    /// Don't worry about changing appearance rn, just have one sprite
    /// </summary>

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [field: SerializeField]
    public List<Customer> customers { get; }

    [SerializeField]
    private CookingUIEventChannel cookingUIEventChannel;

    [field: SerializeField]
    public int Difficulty { get; set; }
    private double nextSpawnTime = 0.0;
    public float baseDelay = 25f; // Base delay in seconds for difficulty = 1.
    public float randomOffset = 10f; // Maximum random offset added or subtracted from the delay.;
    [SerializeField]
    private List<Transform> CustomerSpots;

    void Start()
    {
        
    }

    private void Update()
    {
        // Check if it's time to create a new customer.
        if (Time.time >= nextSpawnTime)
        {
            CreateCustomer();
            ScheduleNextCustomer();
        }
    }

    private void OnEnable()
    {
        cookingUIEventChannel.OnSubmitOrder += RemoveCustomer;
    }

    private void OnDisable()
    {
        cookingUIEventChannel.OnSubmitOrder -= RemoveCustomer;
    }

    private void ScheduleNextCustomer()
    {
        // Calculate the delay based on difficulty and randomness.
        float adjustedDelay = Mathf.Max(0.1f, baseDelay / Difficulty); // Ensure delay is never below 0.1 seconds.
        float randomDelay = adjustedDelay + Random.Range(-randomOffset, randomOffset);

        // Schedule the next spawn time.
        nextSpawnTime = Time.time + randomDelay;
    }

    public bool CreateCustomer()
    {
        Customer c = new Customer(/*random stuff for each customer*/);
        for (int i = 0; i < customers.Count; i++)
        {
            if (customers[i] == null)
            {
                customers.Insert(i, c);
                customers[i].transform.position = CustomerSpots[i].position;
                return true;
            }
        }
        
        return false;
    }

    public void RemoveCustomer(Order order)
    {
        Customer c = order.Customer;
        for (int i = 0; i < customers.Count; i++) 
        {
            if (customers[i].Equals(c))
            {
                customers.RemoveAt(i);
                Destroy(customers[i]);
            }
        }
    }
}
