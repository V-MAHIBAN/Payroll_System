namespace Grifindo
{
    partial class AppliedLeave
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AppliedLeave_GridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Employee_ComboBox = new System.Windows.Forms.ComboBox();
            this.ID_txt = new System.Windows.Forms.TextBox();
            this.No_of_Day_txt = new System.Windows.Forms.TextBox();
            this.Reason_txt = new System.Windows.Forms.TextBox();
            this.StartDate_dtpicker = new System.Windows.Forms.DateTimePicker();
            this.EndDate_dtpicker = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AppliedLeave_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(78, 339);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(35, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 19);
            this.label5.TabIndex = 19;
            this.label5.Text = "ID :";
            // 
            // AppliedLeave_GridView
            // 
            this.AppliedLeave_GridView.BackgroundColor = System.Drawing.Color.White;
            this.AppliedLeave_GridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppliedLeave_GridView.Location = new System.Drawing.Point(39, 361);
            this.AppliedLeave_GridView.Name = "AppliedLeave_GridView";
            this.AppliedLeave_GridView.RowHeadersWidth = 51;
            this.AppliedLeave_GridView.RowTemplate.Height = 24;
            this.AppliedLeave_GridView.Size = new System.Drawing.Size(785, 247);
            this.AppliedLeave_GridView.TabIndex = 17;
            this.AppliedLeave_GridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AppliedLeave_GridView_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(34, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "ID";
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(866, 408);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(110, 55);
            this.SaveButton.TabIndex = 23;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UpdateButton
            // 
            this.UpdateButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdateButton.Location = new System.Drawing.Point(1040, 408);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(110, 55);
            this.UpdateButton.TabIndex = 22;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClearButton.Location = new System.Drawing.Point(866, 553);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(110, 55);
            this.ClearButton.TabIndex = 21;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteButton.Location = new System.Drawing.Point(1049, 553);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(110, 55);
            this.DeleteButton.TabIndex = 20;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(711, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Reason";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(711, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 25);
            this.label4.TabIndex = 26;
            this.label4.Text = "No of Day";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(34, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(167, 25);
            this.label7.TabIndex = 27;
            this.label7.Text = "StartDate/Time";
            // 
            // Employee_ComboBox
            // 
            this.Employee_ComboBox.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Employee_ComboBox.FormattingEnabled = true;
            this.Employee_ComboBox.Location = new System.Drawing.Point(866, 273);
            this.Employee_ComboBox.Name = "Employee_ComboBox";
            this.Employee_ComboBox.Size = new System.Drawing.Size(293, 33);
            this.Employee_ComboBox.TabIndex = 28;
            // 
            // ID_txt
            // 
            this.ID_txt.Enabled = false;
            this.ID_txt.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_txt.Location = new System.Drawing.Point(259, 37);
            this.ID_txt.Name = "ID_txt";
            this.ID_txt.Size = new System.Drawing.Size(293, 34);
            this.ID_txt.TabIndex = 16;
            this.ID_txt.Text = "Automatically Generate";
            // 
            // No_of_Day_txt
            // 
            this.No_of_Day_txt.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.No_of_Day_txt.Location = new System.Drawing.Point(866, 37);
            this.No_of_Day_txt.Name = "No_of_Day_txt";
            this.No_of_Day_txt.Size = new System.Drawing.Size(293, 34);
            this.No_of_Day_txt.TabIndex = 16;
            // 
            // Reason_txt
            // 
            this.Reason_txt.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reason_txt.Location = new System.Drawing.Point(866, 136);
            this.Reason_txt.Multiline = true;
            this.Reason_txt.Name = "Reason_txt";
            this.Reason_txt.Size = new System.Drawing.Size(293, 72);
            this.Reason_txt.TabIndex = 16;
            // 
            // StartDate_dtpicker
            // 
            this.StartDate_dtpicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.StartDate_dtpicker.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartDate_dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartDate_dtpicker.Location = new System.Drawing.Point(259, 139);
            this.StartDate_dtpicker.Name = "StartDate_dtpicker";
            this.StartDate_dtpicker.Size = new System.Drawing.Size(293, 33);
            this.StartDate_dtpicker.TabIndex = 29;
            // 
            // EndDate_dtpicker
            // 
            this.EndDate_dtpicker.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.EndDate_dtpicker.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EndDate_dtpicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndDate_dtpicker.Location = new System.Drawing.Point(259, 241);
            this.EndDate_dtpicker.Name = "EndDate_dtpicker";
            this.EndDate_dtpicker.Size = new System.Drawing.Size(293, 33);
            this.EndDate_dtpicker.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(34, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 25);
            this.label9.TabIndex = 25;
            this.label9.Text = "EndDate/Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(711, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 25);
            this.label2.TabIndex = 30;
            this.label2.Text = "Employee";
            // 
            // AppliedLeave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(38)))));
            this.ClientSize = new System.Drawing.Size(1180, 620);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EndDate_dtpicker);
            this.Controls.Add(this.StartDate_dtpicker);
            this.Controls.Add(this.Employee_ComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AppliedLeave_GridView);
            this.Controls.Add(this.ID_txt);
            this.Controls.Add(this.Reason_txt);
            this.Controls.Add(this.No_of_Day_txt);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AppliedLeave";
            this.Text = "AppliedLeave";
            this.Load += new System.EventHandler(this.AppliedLeave_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AppliedLeave_GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView AppliedLeave_GridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Employee_ComboBox;
        private System.Windows.Forms.TextBox ID_txt;
        private System.Windows.Forms.TextBox No_of_Day_txt;
        private System.Windows.Forms.TextBox Reason_txt;
        private System.Windows.Forms.DateTimePicker StartDate_dtpicker;
        private System.Windows.Forms.DateTimePicker EndDate_dtpicker;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
    }
}