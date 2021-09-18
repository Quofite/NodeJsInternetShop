
namespace Admin_Panel
{
    partial class Main
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
            this.textBox = new System.Windows.Forms.TextBox();
            this.ordersButton = new System.Windows.Forms.Button();
            this.reviewButton = new System.Windows.Forms.Button();
            this.asksButton = new System.Windows.Forms.Button();
            this.pageLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox.Location = new System.Drawing.Point(13, 102);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox.Size = new System.Drawing.Size(1127, 512);
            this.textBox.TabIndex = 0;
            // 
            // ordersButton
            // 
            this.ordersButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ordersButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ordersButton.Location = new System.Drawing.Point(13, 13);
            this.ordersButton.Name = "ordersButton";
            this.ordersButton.Size = new System.Drawing.Size(82, 83);
            this.ordersButton.TabIndex = 1;
            this.ordersButton.Text = "ЗАКАЗЫ";
            this.ordersButton.UseVisualStyleBackColor = true;
            this.ordersButton.Click += new System.EventHandler(this.ordersButton_Click);
            // 
            // reviewButton
            // 
            this.reviewButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.reviewButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.reviewButton.Location = new System.Drawing.Point(101, 13);
            this.reviewButton.Name = "reviewButton";
            this.reviewButton.Size = new System.Drawing.Size(82, 83);
            this.reviewButton.TabIndex = 2;
            this.reviewButton.Text = "ОТЗЫВЫ";
            this.reviewButton.UseVisualStyleBackColor = true;
            this.reviewButton.Click += new System.EventHandler(this.reviewButton_Click);
            // 
            // asksButton
            // 
            this.asksButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.asksButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.asksButton.Location = new System.Drawing.Point(189, 13);
            this.asksButton.Name = "asksButton";
            this.asksButton.Size = new System.Drawing.Size(82, 83);
            this.asksButton.TabIndex = 3;
            this.asksButton.Text = "ВОПРОСЫ";
            this.asksButton.UseVisualStyleBackColor = true;
            this.asksButton.Click += new System.EventHandler(this.asksButton_Click);
            // 
            // pageLabel
            // 
            this.pageLabel.AutoSize = true;
            this.pageLabel.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pageLabel.Location = new System.Drawing.Point(738, 41);
            this.pageLabel.Name = "pageLabel";
            this.pageLabel.Size = new System.Drawing.Size(147, 30);
            this.pageLabel.TabIndex = 5;
            this.pageLabel.Text = "СТРАНИЦА: -";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 626);
            this.Controls.Add(this.pageLabel);
            this.Controls.Add(this.asksButton);
            this.Controls.Add(this.reviewButton);
            this.Controls.Add(this.ordersButton);
            this.Controls.Add(this.textBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Main";
            this.Text = "Main Panel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button ordersButton;
        private System.Windows.Forms.Button reviewButton;
        private System.Windows.Forms.Button asksButton;
        private System.Windows.Forms.Label pageLabel;
    }
}

