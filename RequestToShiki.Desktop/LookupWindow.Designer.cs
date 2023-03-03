namespace RequestToShiki.Desktop
{
    partial class LookupWindow
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
            this.lookupButton = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lookupButton
            // 
            this.lookupButton.Location = new System.Drawing.Point(357, 22);
            this.lookupButton.Name = "lookupButton";
            this.lookupButton.Size = new System.Drawing.Size(75, 23);
            this.lookupButton.TabIndex = 0;
            this.lookupButton.Text = "Lookup";
            this.lookupButton.UseVisualStyleBackColor = true;
            this.lookupButton.Click += new System.EventHandler(this.lookupButton_Click);
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(12, 85);
            this.output.MaximumSize = new System.Drawing.Size(343, 0);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(0, 15);
            this.output.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(262, 23);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 41);
            this.input.Name = "input";
            this.input.PlaceholderText = "введите название";
            this.input.Size = new System.Drawing.Size(262, 23);
            this.input.TabIndex = 2;
            this.input.KeyDown += new System.Windows.Forms.KeyEventHandler(this.input_KeyDown);
            // 
            // LookupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(466, 403);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.input);
            this.Controls.Add(this.output);
            this.Controls.Add(this.lookupButton);
            this.Name = "LookupWindow";
            this.Text = "LookupWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button lookupButton;
        private Label output;
        private ComboBox comboBox1;
        private TextBox input;
    }
}
