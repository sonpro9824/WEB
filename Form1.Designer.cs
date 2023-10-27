namespace WEB
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_back = new FontAwesome.Sharp.IconButton();
            this.button_next = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(2, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(138, 376);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(161, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(617, 376);
            this.panel2.TabIndex = 1;
            // 
            // button_back
            // 
            this.button_back.IconChar = FontAwesome.Sharp.IconChar.ArrowCircleLeft;
            this.button_back.IconColor = System.Drawing.Color.Black;
            this.button_back.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button_back.Location = new System.Drawing.Point(12, 5);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(63, 51);
            this.button_back.TabIndex = 0;
            this.button_back.UseVisualStyleBackColor = true;
            // 
            // button_next
            // 
            this.button_next.IconChar = FontAwesome.Sharp.IconChar.ArrowRightRotate;
            this.button_next.IconColor = System.Drawing.Color.Black;
            this.button_next.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button_next.Location = new System.Drawing.Point(81, 5);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(63, 51);
            this.button_next.TabIndex = 2;
            this.button_next.Text = "iconButton2";
            this.button_next.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton button_back;
        private FontAwesome.Sharp.IconButton button_next;
    }
}

