using NAudio.Wave;
using System.Collections.Generic;

namespace AudioAnalyzer
{
    public class AudioFeatures
    {
        public double Time { get; set; }
        public float Amplitude { get; set; }
        // Add more features as needed (pitch, beat, etc.)
    }

    public static class AudioAnalyzer
    {
        public static AudioFeatures[] AnalyzeAudio(string audioPath)
        {
            List<AudioFeatures> features = new List<AudioFeatures>();
            using (var reader = new AudioFileReader(audioPath))
            {
                float[] buffer = new float[reader.WaveFormat.SampleRate];
                int samplesRead;
                double time = 0;
                while ((samplesRead = reader.Read(buffer, 0, buffer.Length)) > 0)
                {
                    float amp = 0;
                    for (int i = 0; i < samplesRead; i++)
                        amp += Math.Abs(buffer[i]);
                    amp /= samplesRead;

                    features.Add(new AudioFeatures { Time = time, Amplitude = amp });
                    time += 1.0;
                }
            }
            return features.ToArray();
        }
    }
}