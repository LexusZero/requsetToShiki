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
            this.input = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lookupButton
            // 
            this.lookupButton.Location = new System.Drawing.Point(280, 12);
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
            this.output.Location = new System.Drawing.Point(12, 38);
            this.output.MaximumSize = new System.Drawing.Size(343, 0);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(0, 15);
            this.output.TabIndex = 1;
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(12, 12);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(262, 23);
            this.input.TabIndex = 2;
            // 
            // LookupWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(367, 324);
            this.Controls.Add(this.input);
            this.Controls.Add(this.output);
            this.Controls.Add(this.lookupButton);
            this.Name = "LookupWindow";
            this.Text = "LookupWindow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button lookupButton;
        private Label output;
        private TextBox input;
    }
}
