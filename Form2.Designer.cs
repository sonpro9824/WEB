namespace WEB
{
    partial class Form2
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
            this.button_back = new FontAwesome.Sharp.IconButton();
            this.button_next = new FontAwesome.Sharp.IconButton();
            this.button_reload = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_bookmark = new FontAwesome.Sharp.IconButton();
            this.button_history = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_back
            // 
            this.button_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_back.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.button_back.IconColor = System.Drawing.Color.Black;
            this.button_back.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button_back.Location = new System.Drawing.Point(1, 1);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(63, 51);
            this.button_back.TabIndex = 1;
            this.button_back.UseVisualStyleBackColor = true;
            // 
            // button_next
            // 
            this.button_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_next.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleRight;
            this.button_next.IconColor = System.Drawing.Color.Black;
            this.button_next.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button_next.Location = new System.Drawing.Point(70, 1);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(63, 51);
            this.button_next.TabIndex = 3;
            this.button_next.UseVisualStyleBackColor = true;
            // 
            // button_reload
            // 
            this.button_reload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_reload.IconChar = FontAwesome.Sharp.IconChar.ArrowRightRotate;
            this.button_reload.IconColor = System.Drawing.Color.Black;
            this.button_reload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button_reload.Location = new System.Drawing.Point(139, 1);
            this.button_reload.Name = "button_reload";
            this.button_reload.Size = new System.Drawing.Size(63, 51);
            this.button_reload.TabIndex = 4;
            this.button_reload.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(225, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(386, 32);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "Search bar";
            this.textBox1.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // button_bookmark
            // 
            this.button_bookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_bookmark.IconChar = FontAwesome.Sharp.IconChar.Star;
            this.button_bookmark.IconColor = System.Drawing.Color.Black;
            this.button_bookmark.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.button_bookmark.Location = new System.Drawing.Point(626, 12);
            this.button_bookmark.Name = "button_bookmark";
            this.button_bookmark.Size = new System.Drawing.Size(63, 51);
            this.button_bookmark.TabIndex = 6;
            this.button_bookmark.UseVisualStyleBackColor = true;
            // 
            // button_history
            // 
            this.button_history.Location = new System.Drawing.Point(1, 58);
            this.button_history.Name = "button_history";
            this.button_history.Size = new System.Drawing.Size(138, 34);
            this.button_history.TabIndex = 7;
            this.button_history.Text = "History";
            this.button_history.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(395, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Welcome to our web!";
            this.label1.UseWaitCursor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(222, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Welcome to our web!";
            this.label2.UseWaitCursor = true;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Welcome to our web!";
            this.label3.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Welcome to our web!";
            this.label4.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(222, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Welcome to our web!";
            this.label5.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(222, 317);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Welcome to our web!";
            this.label6.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(656, 425);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(132, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Welcome to our web!";
            this.label7.UseWaitCursor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_history);
            this.Controls.Add(this.button_bookmark);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_reload);
            this.Controls.Add(this.button_next);
            this.Controls.Add(this.button_back);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton button_back;
        private FontAwesome.Sharp.IconButton button_next;
        private FontAwesome.Sharp.IconButton button_reload;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton button_bookmark;
        private System.Windows.Forms.Button button_history;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}