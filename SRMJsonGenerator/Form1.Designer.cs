namespace SRMJsonGenerator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            generate = new Button();
            listBox1 = new ListBox();
            button1 = new Button();
            ofd = new OpenFileDialog();
            SuspendLayout();
            // 
            // generate
            // 
            generate.Location = new Point(-2, 141);
            generate.Name = "generate";
            generate.Size = new Size(75, 23);
            generate.TabIndex = 0;
            generate.Text = "Generate";
            generate.UseVisualStyleBackColor = true;
            generate.Click += generate_Click;
            // 
            // listBox1
            // 
            listBox1.Font = new Font("Segoe UI", 7F, FontStyle.Regular, GraphicsUnit.Point);
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 12;
            listBox1.Location = new Point(100, 1);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(175, 160);
            listBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(79, 142);
            button1.Name = "button1";
            button1.Size = new Size(20, 20);
            button1.TabIndex = 2;
            button1.Text = "📂";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // ofd
            // 
            ofd.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 161);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(generate);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button generate;
        private ListBox listBox1;
        private Button button1;
        private OpenFileDialog ofd;
    }
}