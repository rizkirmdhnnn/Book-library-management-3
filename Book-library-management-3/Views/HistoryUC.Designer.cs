namespace Book_library_management_3.Views
{
    partial class HistoryUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel9 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.lv_History = new System.Windows.Forms.ListView();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.guna2Panel9.ShadowDecoration.Enabled = true;
            this.guna2Panel9.Size = new System.Drawing.Size(882, 63);
            this.guna2Panel9.TabIndex = 14;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lv_History);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 63);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(882, 382);
            this.guna2Panel1.TabIndex = 15;
            // 
            // lv_History
            // 
            this.lv_History.HideSelection = false;
            this.lv_History.Location = new System.Drawing.Point(27, 19);
            this.lv_History.Name = "lv_History";
            this.lv_History.Size = new System.Drawing.Size(817, 338);
            this.lv_History.TabIndex = 16;
            this.lv_History.UseCompatibleStateImageBehavior = false;
            // 
            // HistoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel9);
            this.Name = "HistoryUC";
            this.Size = new System.Drawing.Size(882, 445);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ListView lv_History;
    }
}
