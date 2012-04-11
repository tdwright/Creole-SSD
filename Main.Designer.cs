namespace CreoleSSD
{
    partial class Main
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
            this.rawPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.repPictureBox = new System.Windows.Forms.PictureBox();
            this.ROIbox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.rawPictureBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.repPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROIbox)).BeginInit();
            this.SuspendLayout();
            // 
            // rawPictureBox
            // 
            this.rawPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rawPictureBox.Location = new System.Drawing.Point(3, 3);
            this.rawPictureBox.Name = "rawPictureBox";
            this.rawPictureBox.Size = new System.Drawing.Size(229, 175);
            this.rawPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rawPictureBox.TabIndex = 0;
            this.rawPictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.ROIbox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.rawPictureBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.repPictureBox, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 181);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // repPictureBox
            // 
            this.repPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.repPictureBox.Location = new System.Drawing.Point(473, 3);
            this.repPictureBox.Name = "repPictureBox";
            this.repPictureBox.Size = new System.Drawing.Size(232, 175);
            this.repPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.repPictureBox.TabIndex = 2;
            this.repPictureBox.TabStop = false;
            // 
            // ROIbox
            // 
            this.ROIbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ROIbox.Location = new System.Drawing.Point(238, 3);
            this.ROIbox.Name = "ROIbox";
            this.ROIbox.Size = new System.Drawing.Size(229, 175);
            this.ROIbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ROIbox.TabIndex = 3;
            this.ROIbox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 181);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Main";
            this.Text = "Creole SSD";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rawPictureBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.repPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ROIbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox rawPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox ROIbox;
        private System.Windows.Forms.PictureBox repPictureBox;
    }
}

