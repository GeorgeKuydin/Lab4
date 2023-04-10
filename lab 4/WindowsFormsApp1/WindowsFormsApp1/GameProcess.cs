using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class GameProcess
    {
        private string _playerName;
        private int _difficultyLevel;
        private bool _soundEnabled;

        public GameProcess(string playerName, int difficultyLevel, bool soundEnabled)
        {
            _playerName = playerName;
            _difficultyLevel = difficultyLevel;
            _soundEnabled = soundEnabled;
        }

        public void Display()
        {
            MessageBox.Show("Game process:");
            MessageBox.Show("Player name: " + _playerName);
            MessageBox.Show("Difficulty level: " + _difficultyLevel);
            MessageBox.Show("Sound enabled: " + (_soundEnabled ? "Yes" : "No"));
        }
    }

    // Builder interface
    interface IGameProcessBuilder
    {
        void SetPlayerName(string playerName);
        void SetDifficultyLevel(int difficultyLevel);
        void SetSoundEnabled(bool soundEnabled);
        GameProcess GetGameProcess();
    }

    // Concrete builder class
    class GameProcessBuilder : IGameProcessBuilder
    {
        private string _playerName;
        private int _difficultyLevel;
        private bool _soundEnabled;

        public void SetPlayerName(string playerName)
        {
            _playerName = playerName;
        }

        public void SetDifficultyLevel(int difficultyLevel)
        {
            _difficultyLevel = difficultyLevel;
        }

        public void SetSoundEnabled(bool soundEnabled)
        {
            _soundEnabled = soundEnabled;
        }

        public GameProcess GetGameProcess()
        {
            return new GameProcess(_playerName, _difficultyLevel, _soundEnabled);
        }
    }

    // Director class
    class GameProcessDirector
    {
        private IGameProcessBuilder _builder;

        public GameProcessDirector(IGameProcessBuilder builder)
        {
            _builder = builder;
        }

        public void Construct(string playerName, int difficultyLevel, bool soundEnabled)
        {
            _builder.SetPlayerName(playerName);
            _builder.SetDifficultyLevel(difficultyLevel);
            _builder.SetSoundEnabled(soundEnabled);
        }
    }
}
