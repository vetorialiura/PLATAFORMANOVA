using UnityEngine;

public class GalaxyVortex : MonoBehaviour
{
    public ParticleSystem ps;
    public int arms = 4;           // Número de braços
    public float spiralTwist = 2f; // Quanto mais alto, mais espiral
    public float spinSpeed = 2f;   // Velocidade de rotação
    public float coreSize = 0.5f;  // Tamanho do núcleo
    public float galaxyRadius = 3f;// Raio máximo da galáxia

    ParticleSystem.Particle[] particles;

    void LateUpdate()
    {
        if (!ps) ps = GetComponent<ParticleSystem>();
        if (particles == null || particles.Length != ps.main.maxParticles)
            particles = new ParticleSystem.Particle[ps.main.maxParticles];

        int count = ps.GetParticles(particles);
        float time = Time.time * spinSpeed;

        for (int i = 0; i < count; i++)
        {
            float t = (float)i / count;
            float angle = t * arms * Mathf.PI * 2f + t * spiralTwist * Mathf.PI * 2f + time;
            float radius = Mathf.Lerp(coreSize, galaxyRadius, Mathf.Pow(t, 0.7f));

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            particles[i].position = new Vector3(x, y, 0);
        }

        ps.SetParticles(particles, count);
    }
}