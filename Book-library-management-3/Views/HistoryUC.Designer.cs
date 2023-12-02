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
            this.txtbox_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Panel9.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Controls.Add(this.txtbox_username);
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
            // txtbox_username
            // 
            this.txtbox_username.BackColor = System.Drawing.Color.Transparent;
            this.txtbox_username.BorderRadius = 8;
            this.txtbox_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtbox_username.DefaultText = "";
            this.txtbox_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtbox_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtbox_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbox_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtbox_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbox_username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtbox_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtbox_username.Location = new System.Drawing.Point(685, 13);
            this.txtbox_username.Name = "txtbox_username";
            this.txtbox_username.PasswordChar = '\0';
            this.txtbox_username.PlaceholderText = "Search by username";
            this.txtbox_username.SelectedText = "";
            this.txtbox_username.Size = new System.Drawing.Size(159, 35);
            this.txtbox_username.TabIndex = 17;
            this.txtbox_username.TextChanged += new System.EventHandler(this.guna2TextBox1_TextChanged);
            // 
            // HistoryUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel9);
            this.Name = "HistoryUC";
            this.Size = new System.Drawing.Size(882, 445);
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ListView lv_History;
        private Guna.UI2.WinForms.Guna2TextBox txtbox_username;
    }
}
