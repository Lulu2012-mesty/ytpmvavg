using System.Text;
using AudioAnalyzer;

namespace VegasScriptGenerator
{
    public static class VegasScriptBuilder
    {
        public static string GenerateScript(AudioFeatures[] features, string audioFilePath)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine("using ScriptPortal.Vegas;");
            sb.AppendLine("public class EntryPoint {");
            sb.AppendLine("  public void FromVegas(Vegas vegas) {");

            // Add audio track
            sb.AppendLine($"    var audioTrack = new AudioTrack();");
            sb.AppendLine($"    vegas.Project.Tracks.Add(audioTrack);");
            sb.AppendLine($"    var audioEvent = new AudioEvent(Timecode.FromSeconds(0), Timecode.FromSeconds({features.Length}), \"{audioFilePath.Replace("\\", "\\\\")}\");");
            sb.AppendLine($"    audioTrack.Events.Add(audioEvent);");

            // Example: Add markers for each amplitude peak
            foreach (var f in features)
            {
                if (f.Amplitude > 0.5) // threshold for demonstration
                    sb.AppendLine($"    vegas.Project.Markers.Add(new Marker(Timecode.FromSeconds({f.Time}), \"Peak\"));");
            }

            sb.AppendLine("  }");
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}