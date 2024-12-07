using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class GameTimer
    {
        private Tetramino _tetramino;
        private System.Timers.Timer _timer;
        public double Interval
        {
            get => _timer.Interval; 
            set
            {
                _timer.Interval = value;
            }
        }

        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
        private void TetraminoMovement(object sender, System.Timers.ElapsedEventArgs e)
        {
            _tetramino.Y++;
        }

        public GameTimer(Tetramino tetramino, double interval)
        {
            _timer = new System.Timers.Timer(interval);
            _timer.AutoReset = true;
            _timer.Elapsed += TetraminoMovement;

            _tetramino = tetramino;
        }
    }
}
