using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Audiere.Net;

namespace CreoleSSD
{
    class Audio
    {
        OutputStream[,] waves;
        AudioDevice device;

        public readonly int MaxPitch = 2500;
        public readonly int MinPitch = 250;

        public Audio()
        {
            int centrePitch = ((MaxPitch-MinPitch)/2)+MinPitch;
            int pitchStep = (MaxPitch - MinPitch) / 10;
            this.device = new AudioDevice();
            this.waves = new OutputStream[4, 5];
            int panLeft; int pitchHigh;
            for (int i = 0; i < 4; i++)
            {
                // If this quadrant is in the left 50%, pan left (-1), else pan right (1)
                panLeft = ((i % 2) == 0) ? -1 : 1;
                // If this quadrant is in the top 50%, add pitch steps to centre pitch, else subtract
                pitchHigh = (i < 2) ? 1 : -1;
                for (int j = 0; j < 5; j++)
                {
                    int pitch = centrePitch + (j * pitchStep * pitchHigh);
                    float pan = ((float)(5 + (j * panLeft)) / 5f) - 1f;
                    waves[i, j] = device.CreateTone((double)pitch);
                    waves[i, j].Volume = 0f;
                    waves[i, j].Pan = pan;
                    waves[i, j].Play();
                }
            }
        }

        public void SetLevels(int[,] values)
        {for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    float volume = ((float)values[i, j] / (256f * 20f));
                    waves[i, j].Volume = volume;
                }
            }
        }
    }
}
