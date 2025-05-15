using System;
using System.Windows.Forms;
using NAudio.Wave;
using System.IO;
using VegasScriptGenerator;

namespace YTPMVFormApp
{
    public partial class MainForm : Form
    {
        private string loadedAudioPath;
        private AudioAnalyzer.AudioFeatures[] audioFeatures;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadAudio_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Audio Files|*.wav;*.mp3";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadedAudioPath = ofd.FileName;
                txtAudioPath.Text = loadedAudioPath;
                audioFeatures = AudioAnalyzer.AnalyzeAudio(loadedAudioPath);
                MessageBox.Show("Audio loaded and analyzed!");
            }
        }

        private void btnGenerateVegasScript_Click(object sender, EventArgs e)
        {
            if (audioFeatures == null)
            {
                MessageBox.Show("Please load and analyze audio first.");
                return;
            }
            string vegasScript = VegasScriptGenerator.VegasScriptBuilder.GenerateScript(audioFeatures, loadedAudioPath);
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Vegas Script|*.cs";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, vegasScript);
                MessageBox.Show("Vegas script saved!");
            }
        }
    }
}