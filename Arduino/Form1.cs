using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Arduino
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; }
        public Form1()
        {
            InitializeComponent();
            //Crear serial port
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName="COM3";
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            //vincular eventos
            this.FormClosing += CerrandoForm1;
            this.btnApagar.Click += btnApagar_Click;
            this.btnEncender.Click += btnEncender_Click;
        }

        private void btnEncender_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }

        private void CerrandoForm1(object sender, FormClosingEventArgs e)
        {
            //Cerrar puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
    }
}
