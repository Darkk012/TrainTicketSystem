namespace TrainTicketSystem
{
    partial class PayingForm
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
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fcLabel = new System.Windows.Forms.Label();
            this.scLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.routeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.couponBox = new System.Windows.Forms.TextBox();
            this.couponUse = new System.Windows.Forms.Button();
            this.stationBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buyTicketBt = new System.Windows.Forms.Button();
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
            this.menuStrip1.Size = new System.Drawing.Size(552, 29);
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
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(16, 67);
            this.nameBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(189, 26);
            this.nameBox.TabIndex = 9;
            this.nameBox.TextChanged += new System.EventHandler(this.nameBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Név:";
            // 
            // fcLabel
            // 
            this.fcLabel.AutoSize = true;
            this.fcLabel.Location = new System.Drawing.Point(242, 93);
            this.fcLabel.Name = "fcLabel";
            this.fcLabel.Size = new System.Drawing.Size(156, 20);
            this.fcLabel.TabIndex = 11;
            this.fcLabel.Text = "Első osztályú ülések:";
            // 
            // scLabel
            // 
            this.scLabel.AutoSize = true;
            this.scLabel.Location = new System.Drawing.Point(242, 116);
            this.scLabel.Name = "scLabel";
            this.scLabel.Size = new System.Drawing.Size(173, 20);
            this.scLabel.TabIndex = 12;
            this.scLabel.Text = "Másod osztályú ülések:";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Location = new System.Drawing.Point(242, 136);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(29, 20);
            this.priceLabel.TabIndex = 13;
            this.priceLabel.Text = "Ár:";
            // 
            // routeLabel
            // 
            this.routeLabel.AutoSize = true;
            this.routeLabel.Location = new System.Drawing.Point(242, 73);
            this.routeLabel.Name = "routeLabel";
            this.routeLabel.Size = new System.Drawing.Size(53, 20);
            this.routeLabel.TabIndex = 14;
            this.routeLabel.Text = "Járat: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Kuponkód:";
            // 
            // couponBox
            // 
            this.couponBox.Location = new System.Drawing.Point(16, 126);
            this.couponBox.Name = "couponBox";
            this.couponBox.Size = new System.Drawing.Size(100, 26);
            this.couponBox.TabIndex = 16;
            this.couponBox.Leave += new System.EventHandler(this.couponUse_Click);
            // 
            // couponUse
            // 
            this.couponUse.Location = new System.Drawing.Point(122, 126);
            this.couponUse.Name = "couponUse";
            this.couponUse.Size = new System.Drawing.Size(83, 27);
            this.couponUse.TabIndex = 17;
            this.couponUse.Text = "Aktivál";
            this.couponUse.UseVisualStyleBackColor = true;
            this.couponUse.Click += new System.EventHandler(this.couponUse_Click);
            // 
            // stationBox
            // 
            this.stationBox.FormattingEnabled = true;
            this.stationBox.ItemHeight = 20;
            this.stationBox.Location = new System.Drawing.Point(16, 189);
            this.stationBox.Name = "stationBox";
            this.stationBox.Size = new System.Drawing.Size(189, 164);
            this.stationBox.TabIndex = 18;
            this.stationBox.SelectedIndexChanged += new System.EventHandler(this.stationBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Megálló kiválasztása:";
            // 
            // buyTicketBt
            // 
            this.buyTicketBt.Location = new System.Drawing.Point(246, 189);
            this.buyTicketBt.Name = "buyTicketBt";
            this.buyTicketBt.Size = new System.Drawing.Size(169, 34);
            this.buyTicketBt.TabIndex = 20;
            this.buyTicketBt.Text = "Jegy megvétele";
            this.buyTicketBt.UseVisualStyleBackColor = true;
            this.buyTicketBt.Click += new System.EventHandler(this.buyTicketBt_Click);
            // 
            // PayingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 376);
            this.Controls.Add(this.buyTicketBt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.stationBox);
            this.Controls.Add(this.couponUse);
            this.Controls.Add(this.couponBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.routeLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.scLabel);
            this.Controls.Add(this.fcLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameBox);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "PayingForm";
            this.Text = "Fizetés";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PayingForm_FormClosed);
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
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label fcLabel;
        private System.Windows.Forms.Label scLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Label routeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox couponBox;
        private System.Windows.Forms.Button couponUse;
        private System.Windows.Forms.ListBox stationBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buyTicketBt;
    }
}