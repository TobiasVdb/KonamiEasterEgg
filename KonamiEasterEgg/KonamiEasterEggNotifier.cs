using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonamiEasterEgg
{
    public class KonamiEasterEggNotifier
    {
        private List<char> _keyList;
        public event EventHandler KonamiSequenceEntered;
        public KonamiEasterEggNotifier()
        {
            _keyList = new List<char>();
        }

        private void OnKonamiSequenceDetected()
        {
            EventHandler handler = KonamiSequenceEntered;
            if (null != handler) handler(this, EventArgs.Empty);
        }

        public void KeyPressed(char key)
        {
            //Track pressed keys, space is clear!
            if(SequenceChecks(key))//Do sequence checks here
                OnKonamiSequenceDetected();
        }

        public bool GetSequenceStatus()
        {
            return SequenceChecks(null);
        }

        private bool SequenceChecks(char? key)
        {
            if (key != null)
            {
                if (key.Value == (char)Keys.Space)
                    _keyList.Clear();
                else
                    _keyList.Add(key.Value);
            }
            //Konami Code ↑ ↑ ↓ ↓ ← → ← → B A Enter
            var correctSequence = true;
            if (_keyList.Count == 1) correctSequence = correctSequence && _keyList[0] == 'U';
            if(_keyList.Count == 2) correctSequence = correctSequence && _keyList[1] == 'U';
            if(_keyList.Count == 3) correctSequence = correctSequence && _keyList[2] == 'D';
            if(_keyList.Count == 4) correctSequence = correctSequence && _keyList[3] == 'D';
            if(_keyList.Count == 5) correctSequence = correctSequence && _keyList[4] == 'L';
            if(_keyList.Count == 6) correctSequence = correctSequence && _keyList[5] == 'R';
            if(_keyList.Count == 7) correctSequence = correctSequence && _keyList[6] == 'L';
            if(_keyList.Count == 8) correctSequence = correctSequence && _keyList[7] == 'R';
            if(_keyList.Count == 9) correctSequence = correctSequence && _keyList[8] == 'B';
            if(_keyList.Count == 10) correctSequence = correctSequence && _keyList[9] == 'A';
            if(_keyList.Count == 11) 
                correctSequence = correctSequence && _keyList[10] == '\r';

            return (_keyList.Count == 11) && correctSequence;
        }

        public void KeyPressed(PreviewKeyDownEventArgs keyPressEventArgs)
        {
            if (SequenceChecks((char)keyPressEventArgs.KeyCode))//Do sequence checks here
                OnKonamiSequenceDetected();
        }
    }
}
