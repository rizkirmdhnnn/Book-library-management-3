﻿namespace Book_library_management_3.Views
{
    partial class BooksUC
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
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.txt_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_total = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lv_Books = new System.Windows.Forms.ListView();
            this.guna2Panel9.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Controls.Add(this.guna2Panel1);
            this.guna2Panel9.Controls.Add(this.txt_total);
            this.guna2Panel9.Controls.Add(this.label2);
            this.guna2Panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.guna2Panel9.ShadowDecoration.Enabled = true;
            this.guna2Panel9.Size = new System.Drawing.Size(860, 63);
            this.guna2Panel9.TabIndex = 14;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.btn_add);
            this.guna2Panel1.Controls.Add(this.txt_username);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(491, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(369, 63);
            this.guna2Panel1.TabIndex = 12;
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BorderRadius = 8;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.Color.Transparent;
            this.btn_add.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.Black;
            this.btn_add.Image = global::Book_library_management_3.Properties.Resources.Add_Option;
            this.btn_add.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_add.Location = new System.Drawing.Point(273, 17);
            this.btn_add.Margin = new System.Windows.Forms.Padding(2);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(81, 31);
            this.btn_add.TabIndex = 10;
            this.btn_add.Text = "Add";
            this.btn_add.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txt_username
            // 
            this.txt_username.BackColor = System.Drawing.Color.Transparent;
            this.txt_username.BorderRadius = 8;
            this.txt_username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_username.DefaultText = "";
            this.txt_username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txt_username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txt_username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txt_username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txt_username.Location = new System.Drawing.Point(43, 17);
            this.txt_username.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txt_username.Name = "txt_username";
            this.txt_username.PasswordChar = '\0';
            this.txt_username.PlaceholderText = "Search";
            this.txt_username.SelectedText = "";
            this.txt_username.Size = new System.Drawing.Size(202, 32);
            this.txt_username.TabIndex = 2;
            this.txt_username.TextChanged += new System.EventHandler(this.txt_username_TextChanged);
            // 
            // txt_total
            // 
            this.txt_total.AutoSize = true;
            this.txt_total.BackColor = System.Drawing.Color.Transparent;
            this.txt_total.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_total.Location = new System.Drawing.Point(21, 7);
            this.txt_total.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(54, 44);
            this.txt_total.TabIndex = 11;
            this.txt_total.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Total Books";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button2.BorderRadius = 8;
            this.guna2Button2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button2.Font = new System.Drawing.Font("Montserrat", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2Button2.ForeColor = System.Drawing.Color.Black;
            this.guna2Button2.Image = global::Book_library_management_3.Properties.Resources.Delete;
            this.guna2Button2.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button2.Location = new System.Drawing.Point(593, 535);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(122, 31);
            this.guna2Button2.TabIndex = 23;
            this.guna2Button2.Text = "Delete Data";
            this.guna2Button2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Button1.BorderRadius = 8;
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.Transparent;
            this.guna2Button1.Font = new System.Drawing.Font("Montserrat", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Image = global::Book_library_management_3.Properties.Resources.Edit;
            this.guna2Button1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.guna2Button1.Location = new System.Drawing.Point(719, 535);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(2);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(106, 31);
            this.guna2Button1.TabIndex = 22;
            this.guna2Button1.Text = "Edit Data";
            this.guna2Button1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lv_Books
            // 
            this.lv_Books.HideSelection = false;
            this.lv_Books.Location = new System.Drawing.Point(29, 83);
            this.lv_Books.Name = "lv_Books";
            this.lv_Books.Size = new System.Drawing.Size(796, 444);
            this.lv_Books.TabIndex = 24;
            this.lv_Books.UseCompatibleStateImageBehavior = false;
            // 
            // BooksUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lv_Books);
            this.Controls.Add(this.guna2Button2);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.guna2Panel9);
            this.Name = "BooksUC";
            this.Size = new System.Drawing.Size(860, 582);
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private Guna.UI2.WinForms.Guna2TextBox txt_username;
        private Guna.UI2.WinForms.Guna2Button btn_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txt_total;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.ListView lv_Books;
    }
}
