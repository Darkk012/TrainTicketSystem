namespace TrainTicketSystem
{
    partial class TicketInfoForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kijelentkezésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.fcNumLabel = new System.Windows.Forms.Label();
            this.scNumlabel = new System.Windows.Forms.Label();
            this.seatsLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.couponLabel = new System.Windows.Forms.Label();
            this.stopLabel = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.kijelentkezésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(14, 5, 0, 5);
            this.menuStrip1.Size = new System.Drawing.Size(428, 29);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&Fájl";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "&Bezárás";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(46, 19);
            this.helpToolStripMenuItem.Text = "&Súgó";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.aboutToolStripMenuItem.Text = "&Infó";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // kijelentkezésToolStripMenuItem
            // 
            this.kijelentkezésToolStripMenuItem.Name = "kijelentkezésToolStripMenuItem";
            this.kijelentkezésToolStripMenuItem.Size = new System.Drawing.Size(86, 19);
            this.kijelentkezésToolStripMenuItem.Text = "&Kijelentkezés";
            this.kijelentkezésToolStripMenuItem.Click += new System.EventHandler(this.kijelentkezésToolStripMenuItem_Click);
            // 
            // routeLabel
            // 
            this.routeLabel.AutoSize = true;
            this.routeLabel.Location = new System.Drawing.Point(12, 49);
            this.routeLabel.Name = "routeLabel";
            this.routeLabel.Size = new System.Drawing.Size(49, 20);
            this.routeLabel.TabIndex = 9;
            this.routeLabel.Text = "Járat:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(12, 69);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(40, 20);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Név:";
            // 
            // fcNumLabel
            // 
            this.fcNumLabel.AutoSize = true;
            this.fcNumLabel.Location = new System.Drawing.Point(12, 89);
            this.fcNumLabel.Name = "fcNumLabel";
            this.fcNumLabel.Size = new System.Drawing.Size(155, 20);
            this.fcNumLabel.TabIndex = 11;
            this.fcNumLabel.Text = "Első osztályú helyek:";
            // 
            // scNumlabel
            // 
            this.scNumlabel.AutoSize = true;
            this.scNumlabel.Location = new System.Drawing.Point(12, 109);
            this.scNumlabel.Name = "scNumlabel";
            this.scNumlabel.Size = new System.Drawing.Size(172, 20);
            this.scNumlabel.TabIndex = 12;
            this.scNumlabel.Text = "Másod osztályú helyek:";
            // 
            // seatsLabel
            // 
            this.seatsLabel.AutoSize = true;
            this.seatsLabel.Location = new System.Drawing.Point(12, 129);
            this.seatsLabel.Name = "seatsLabel";
            this.seatsLabel.Size = new System.Drawing.Size(124, 20);
            this.seatsLabel.TabIndex = 13;
            this.seatsLabel.Text = "Űlőhelyek kódja:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(12, 149);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(64, 20);
            this.priceLabel.TabIndex = 14;
            this.priceLabel.Text = "Jegy ár:";
            // 
            // couponLabel
            // 
            this.couponLabel.AutoSize = true;
            this.couponLabel.Location = new System.Drawing.Point(12, 169);
            this.couponLabel.Name = "couponLabel";
            this.couponLabel.Size = new System.Drawing.Size(55, 20);
            this.couponLabel.TabIndex = 15;
            this.couponLabel.Text = "Kupon";
            // 
            // stopLabel
            // 
            this.stopLabel.AutoSize = true;
            this.stopLabel.Location = new System.Drawing.Point(12, 189);
            this.stopLabel.Name = "stopLabel";
            this.stopLabel.Size = new System.Drawing.Size(71, 20);
            this.stopLabel.TabIndex = 16;
            this.stopLabel.Text = "Leszálló:";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(16, 213);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(86, 34);
            this.backButton.TabIndex = 17;
            this.backButton.Text = "Vissza";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // TicketInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 283);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.stopLabel);
            this.Controls.Add(this.couponLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.seatsLabel);
            this.Controls.Add(this.scNumlabel);
            this.Controls.Add(this.fcNumLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.routeLabel);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "TicketInfoForm";
            this.Text = "Jegy részletes adatai";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TicketInfoForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kijelentkezésToolStripMenuItem;
        private System.Windows.Forms.Label routeLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label fcNumLabel;
        private System.Windows.Forms.Label scNumlabel;
        private System.Windows.Forms.Label seatsLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label couponLabel;
        private System.Windows.Forms.Label stopLabel;
        private System.Windows.Forms.Button backButton;
    }
}