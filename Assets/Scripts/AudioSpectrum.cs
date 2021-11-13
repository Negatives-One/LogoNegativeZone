using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    private float[] m_audioSpectum;

    public static float spectrumValue { get; private set; }

    private void Start()
    {
        m_audioSpectum = new float[128];
    }

    private void Update()
    {
        AudioListener.GetSpectrumData(m_audioSpectum, 0, FFTWindow.BlackmanHarris);

        if(m_audioSpectum != null && m_audioSpectum.Length > 0)
        {
            spectrumValue = m_audioSpectum[0] * 100;
        }
    }
}
