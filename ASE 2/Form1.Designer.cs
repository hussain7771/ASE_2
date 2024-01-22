namespace ASE_2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Run = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Save = new System.Windows.Forms.Button();
            this.Open = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.CommandInput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Run
            // 
            this.Run.Location = new System.Drawing.Point(189, 390);
            this.Run.Name = "Run";
            this.Run.Size = new System.Drawing.Size(58, 35);
            this.Run.TabIndex = 16;
            this.Run.Text = "Run";
            this.Run.UseVisualStyleBackColor = true;
            this.Run.Click += new System.EventHandler(this.Run_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox.Location = new System.Drawing.Point(253, 26);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(544, 399);
            this.pictureBox.TabIndex = 15;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(64, 390);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(55, 35);
            this.Save.TabIndex = 14;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Open
            // 
            this.Open.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Open.Location = new System.Drawing.Point(125, 390);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(58, 35);
            this.Open.TabIndex = 13;
            this.Open.Text = "Open";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(3, 390);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(55, 35);
            this.Clear.TabIndex = 12;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // CommandInput
            // 
            this.CommandInput.Location = new System.Drawing.Point(3, 26);
            this.CommandInput.Name = "CommandInput";
            this.CommandInput.Size = new System.Drawing.Size(244, 348);
            this.CommandInput.TabIndex = 11;
            this.CommandInput.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Run);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Open);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.CommandInput);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Run;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Open;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.RichTextBox CommandInput;
    }
}

