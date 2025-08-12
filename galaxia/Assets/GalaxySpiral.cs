using UnityEngine;

public class GalaxySpiral : MonoBehaviour
{
    public ParticleSystem ps;
    public int arms = 3;         // N�mero de bra�os da gal�xia
    public float spinSpeed = 1f; // Velocidade de rota��o das part�culas
    public float twist = 2f;   // Tor��o do bra�o (quanto maior, mais espiral)

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
            // Par�metro de progress�o ao longo do bra�o espiral
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