﻿namespace Book_library_management_3.Views
{
    partial class MembersUC
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
            this.txtbox_username = new Guna.UI2.WinForms.Guna2TextBox();
            this.txt_admin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_members = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lv_Members = new System.Windows.Forms.ListView();
            this.btn_Edit = new Guna.UI2.WinForms.Guna2Button();
            this.btn_Delete = new Guna.UI2.WinForms.Guna2Button();
            this.btn_add = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel9.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel9
            // 
            this.guna2Panel9.Controls.Add(this.guna2Panel1);
            this.guna2Panel9.Controls.Add(this.txt_admin);
            this.guna2Panel9.Controls.Add(this.label3);
            this.guna2Panel9.Controls.Add(this.txt_members);
            this.guna2Panel9.Controls.Add(this.label2);
            this.guna2Panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel9.FillColor = System.Drawing.Color.White;
            this.guna2Panel9.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel9.Name = "guna2Panel9";
            this.guna2Panel9.ShadowDecoration.Color = System.Drawing.Color.Gainsboro;
            this.guna2Panel9.ShadowDecoration.Enabled = true;
            this.guna2Panel9.Size = new System.Drawing.Size(860, 63);
            this.guna2Panel9.TabIndex = 18;
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2Panel1.Controls.Add(this.txtbox_username);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.guna2Panel1.Location = new System.Drawing.Point(491, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(369, 63);
            this.guna2Panel1.TabIndex = 16;
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
            this.txtbox_username.Location = new System.Drawing.Point(132, 19);
            this.txtbox_username.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtbox_username.Name = "txtbox_username";
            this.txtbox_username.PasswordChar = '\0';
            this.txtbox_username.PlaceholderText = "Search";
            this.txtbox_username.SelectedText = "";
            this.txtbox_username.Size = new System.Drawing.Size(202, 32);
            this.txtbox_username.TabIndex = 2;
            this.txtbox_username.TextChanged += new System.EventHandler(this.txtbox_username_TextChanged);
            // 
            // txt_admin
            // 
            this.txt_admin.AutoSize = true;
            this.txt_admin.BackColor = System.Drawing.Color.Transparent;
            this.txt_admin.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_admin.Location = new System.Drawing.Point(199, 8);
            this.txt_admin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt_admin.Name = "txt_admin";
            this.txt_admin.Size = new System.Drawing.Size(54, 44);
            this.txt_admin.TabIndex = 15;
            this.txt_admin.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Admin";
            // 
            // txt_members
            // 
            this.txt_members.AutoSize = true;
            this.txt_members.BackColor = System.Drawing.Color.Transparent;
            this.txt_members.Font = new System.Drawing.Font("Montserrat", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_members.Location = new System.Drawing.Point(21, 8);
            this.txt_members.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt_members.Name = "txt_members";
            this.txt_members.Size = new System.Drawing.Size(54, 44);
            this.txt_members.TabIndex = 11;
            this.txt_members.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Montserrat", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(74, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 21);
            this.label2.TabIndex = 9;
            this.label2.Text = "Members";
            // 
            // lv_Members
            // 
            this.lv_Members.Font = new System.Drawing.Font("Montserrat", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_Members.HideSelection = false;
            this.lv_Members.Location = new System.Drawing.Point(32, 83);
            this.lv_Members.Name = "lv_Members";
            this.lv_Members.Size = new System.Drawing.Size(796, 444);
            this.lv_Members.TabIndex = 27;
            this.lv_Members.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Edit
            // 
            this.btn_Edit.BackColor = System.Drawing.Color.Transparent;
            this.btn_Edit.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btn_Edit.BorderRadius = 8;
            this.btn_Edit.BorderThickness = 1;
            this.btn_Edit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Edit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Edit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Edit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Edit.FillColor = System.Drawing.Color.Transparent;
            this.btn_Edit.Font = new System.Drawing.Font("Montserrat SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Edit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Edit.Location = new System.Drawing.Point(700, 533);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.PressedColor = System.Drawing.Color.Transparent;
            this.btn_Edit.Size = new System.Drawing.Size(127, 32);
            this.btn_Edit.TabIndex = 30;
            this.btn_Edit.Text = "Edit Account";
            this.btn_Edit.TextFormatNoPrefix = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_Delete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btn_Delete.BorderRadius = 8;
            this.btn_Delete.BorderThickness = 1;
            this.btn_Delete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_Delete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_Delete.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_Delete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_Delete.FillColor = System.Drawing.Color.Transparent;
            this.btn_Delete.Font = new System.Drawing.Font("Montserrat SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_Delete.Location = new System.Drawing.Point(568, 534);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.PressedColor = System.Drawing.Color.Transparent;
            this.btn_Delete.Size = new System.Drawing.Size(126, 32);
            this.btn_Delete.TabIndex = 29;
            this.btn_Delete.Text = "Delete Account";
            this.btn_Delete.TextFormatNoPrefix = true;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.Transparent;
            this.btn_add.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.btn_add.BorderRadius = 8;
            this.btn_add.BorderThickness = 1;
            this.btn_add.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btn_add.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btn_add.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btn_add.FillColor = System.Drawing.Color.Transparent;
            this.btn_add.Font = new System.Drawing.Font("Montserrat SemiBold", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btn_add.Location = new System.Drawing.Point(31, 534);
            this.btn_add.Name = "btn_add";
            this.btn_add.PressedColor = System.Drawing.Color.Transparent;
            this.btn_add.Size = new System.Drawing.Size(165, 32);
            this.btn_add.TabIndex = 28;
            this.btn_add.Text = "Create Account";
            this.btn_add.TextFormatNoPrefix = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // MembersUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lv_Members);
            this.Controls.Add(this.guna2Panel9);
            this.Font = new System.Drawing.Font("Montserrat", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "MembersUC";
            this.Size = new System.Drawing.Size(860, 582);
            this.guna2Panel9.ResumeLayout(false);
            this.guna2Panel9.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel9;
        private System.Windows.Forms.Label txt_members;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lv_Members;
        private System.Windows.Forms.Label txt_admin;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2TextBox txtbox_username;
        private Guna.UI2.WinForms.Guna2Button btn_Edit;
        private Guna.UI2.WinForms.Guna2Button btn_Delete;
        private Guna.UI2.WinForms.Guna2Button btn_add;
    }
}
