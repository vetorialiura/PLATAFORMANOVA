using UnityEngine;

public class GalaxySpiral : MonoBehaviour
{
    public ParticleSystem ps;
    public int arms = 4;         // Número de braços da galáxia
    public float spinSpeed = 1f; // Velocidade de rotação das partículas
    public float twist = 1.5f;   // Torção do braço (quanto maior, mais espiral)

    ParticleSystem.Particle[] particles;

    void LateUpdate()
    {
        if (!ps) ps = GetComponent<ParticleSystem>();
        if (particles == null || particles.Length != ps.main.maxParticles)
            particles = new ParticleSystem.Particle[ps.main.maxParticles];

        int count = ps.GetParticles(particles);

        float t = Time.time * spinSpeed;

        for (int i = 0; i < count; i++)
        {
            // Parâmetro de progressão ao longo do braço espiral
            float norm = (float)i / count;
            float angle = norm * arms * Mathf.PI * 2f + norm * twist * Mathf.PI * 2f + t;

            float radius = Mathf.Lerp(0.2f, 5f, norm);

            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            particles[i].position = new Vector3(x, y, 0);
        }

        ps.SetParticles(particles, count);
    }
}