using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KonamiEasterEgg
{
    public partial class Form1 : Form
    {
        private KonamiEasterEggNotifier _notifier;

        public Form1()
        {
            InitializeComponent();
            _notifier = new KonamiEasterEggNotifier();
            _notifier.KonamiSequenceEntered += _notifier_KonamiSequenceEntered;
            label1.Visible = false;
        }

        void _notifier_KonamiSequenceEntered(object sender, EventArgs e)
        {
            label1.Visible = true;
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            _notifier.KeyPressed(e.KeyChar);
            label1.Visible = _notifier.GetSequenceStatus();
        }

        private void label1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Notify(e.KeyCode);
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            Notify(e.KeyCode);
        }

        private void Notify(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Down:
                    _notifier.KeyPressed('D');
                    break;
                case Keys.Right:
                    _notifier.KeyPressed('R');
                    break;
                case Keys.Up:
                    _notifier.KeyPressed('U');
                    break;
                case Keys.Left:
                    _notifier.KeyPressed('L');
                    break;
            }

            label1.Visible = _notifier.GetSequenceStatus();
        }
    }
}
