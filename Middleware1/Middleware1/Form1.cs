using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace Middleware1
{
    public class Form1:Form
    {
        
        public Button button1;
        public ListBox listBox1;
        public ListBox listBox2;
        public ListBox listBox3;
        public static Program m;

        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(256, 485);
            this.listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(318, 75);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(309, 485);
            this.listBox2.TabIndex = 2;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(664, 75);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(272, 485);
            this.listBox3.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(948, 616);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Middleware1";
            this.ResumeLayout(false);

        }

        public void Add_ReceivedMessage(string data)
        {
            listBox2.Invoke(new Action(() => listBox2.Items.Add(data)));
        }
        public void Add_SentMessage(string msg)
        {
            listBox1.Invoke(new Action(() => listBox1.Items.Add(msg)));
        }
        [STAThread]
        public static int Main(String[] args)
        {
            Form1 myForm = new Form1();
            m = new Program(myForm);
            Application.EnableVisualStyles();
            Task.Run(m.ReceiveMulticast).ConfigureAwait(false);
            Application.Run(myForm);
            return 0;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Task.Run(m.SendMessage).ConfigureAwait(false);
        }
    }
}
