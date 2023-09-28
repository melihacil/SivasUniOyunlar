using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject oneHundredPointstarget;
    [SerializeField]
    private GameObject fiftyPointstarget;
    [SerializeField]
    private GameObject twentyFivePointstarget;
    [SerializeField]
    private Transform centerPoint; // Çemberlerin merkez noktasý
    [SerializeField]
    private float innerRadiusRedundant; // Ýç çemberin yarýçapý
    [SerializeField]
    private float outerRadiusRedundant; // Dýþ çemberin yarýçapý
    [SerializeField]
    private float spawnInterval; // Nesne oluþturma aralýðý (saniye)

    private float spawnTimer; // Nesne oluþturma zamanlayýcýsý
    private bool m_Spawnable = true;


    [SerializeField] float m_SpawnAngleRedundant;
    [SerializeField] Vector2 m_xAxis;
    [SerializeField] Vector2 m_zAxis;

    [SerializeField] private LayerMask m_ScoreLayer;
    private void Update()
    {

        if (m_Spawnable)
        {
            spawnTimer += Time.deltaTime;

            // Belirli bir zaman aralýðýnda nesne oluþturma
            if (spawnTimer >= spawnInterval)
            {
                SpawnObject();
                spawnTimer = 0f;
            }
        }
    }
    private GameObject RandomTarget(float value)
    {
        switch (value)
        {
            case 1f:
                return twentyFivePointstarget;
            case 2f:
                return fiftyPointstarget;
            case 3f:
                return oneHundredPointstarget;
            default:
                return null;
        }
    }


    // From a circle to a cone shaped area
    private void SpawnObject()
    {


      

        // Nesneyi oluþturma

        //LayerMask mask = LayerMask.GetMask("Default");

        //mask.value = 0;
        
        for (;;) {
            // Rastgele bir nokta seçme
            Vector2 randomPoint = Random.insideUnitCircle.normalized;
            // This will give you a circle
            //Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

            Vector3 clampedSpawnPosition = new Vector3(Random.Range(m_xAxis.x, m_xAxis.y), 0.2f, Random.Range(m_zAxis.x, m_zAxis.y));

            Collider[] results = Physics.OverlapSphere(clampedSpawnPosition, 2f, m_ScoreLayer.value);
            if (results.Length == 0)
            {
                Instantiate(RandomTarget(Random.Range(1, 4)), clampedSpawnPosition, Quaternion.identity);
                break;
            }
        }

    }




    private void SpawnObjectOld()
    {


        // Rastgele bir nokta seçme
        Vector2 randomPoint = Random.insideUnitCircle.normalized;
        // This will give you a circle
        //Vector3 spawnPosition = new Vector3(randomPoint.x, 0f, randomPoint.y) * Random.Range(innerRadius, outerRadius);

        // Nesneyi oluþturma
        //Instantiate(RandomTarget(Random.Range(1, 4)), centerPoint.position + spawnPosition, Quaternion.identity);
    }

    public void EndSpawner()
    {
        m_Spawnable = false;
    }

}
