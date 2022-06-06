
namespace AutorepairShopView
{
    partial class FormStorehouseReplenishment
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
            this.labelStorehouse = new System.Windows.Forms.Label();
            this.labelComps = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.comboBox_Storehouse = new System.Windows.Forms.ComboBox();
            this.comboBox_Components = new System.Windows.Forms.ComboBox();
            this.textBox_Count = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelStorehouse
            // 
            this.labelStorehouse.AutoSize = true;
            this.labelStorehouse.Location = new System.Drawing.Point(44, 30);
            this.labelStorehouse.Name = "labelStorehouse";
            this.labelStorehouse.Size = new System.Drawing.Size(43, 15);
            this.labelStorehouse.TabIndex = 0;
            this.labelStorehouse.Text = "Склад:";
            // 
            // labelComps
            // 
            this.labelComps.AutoSize = true;
            this.labelComps.Location = new System.Drawing.Point(15, 60);
            this.labelComps.Name = "labelComps";
            this.labelComps.Size = new System.Drawing.Size(72, 15);
            this.labelComps.TabIndex = 1;
            this.labelComps.Text = "Компонент:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(12, 91);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(75, 15);
            this.labelCount.TabIndex = 2;
            this.labelCount.Text = "Количество:";
            // 
            // comboBox_Storehouse
            // 
            this.comboBox_Storehouse.FormattingEnabled = true;
            this.comboBox_Storehouse.Location = new System.Drawing.Point(107, 27);
            this.comboBox_Storehouse.Name = "comboBox_Storehouse";
            this.comboBox_Storehouse.Size = new System.Drawing.Size(258, 23);
            this.comboBox_Storehouse.TabIndex = 3;
            // 
            // comboBox_Components
            // 
            this.comboBox_Components.FormattingEnabled = true;
            this.comboBox_Components.Location = new System.Drawing.Point(107, 57);
            this.comboBox_Components.Name = "comboBox_Components";
            this.comboBox_Components.Size = new System.Drawing.Size(258, 23);
            this.comboBox_Components.TabIndex = 4;
            // 
            // textBox_Count
            // 
            this.textBox_Count.Location = new System.Drawing.Point(107, 88);
            this.textBox_Count.Name = "textBox_Count";
            this.textBox_Count.Size = new System.Drawing.Size(258, 23);
            this.textBox_Count.TabIndex = 5;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(197, 146);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(106, 28);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(324, 146);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 28);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormStorehouseReplenishment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 198);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBox_Count);
            this.Controls.Add(this.comboBox_Components);
            this.Controls.Add(this.comboBox_Storehouse);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelComps);
            this.Controls.Add(this.labelStorehouse);
            this.Name = "FormStorehouseReplenishment";
            this.Text = "Пополнение склада";
            this.Load += new System.EventHandler(this.FormStorehouseReplenishment_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelStorehouse;
        private System.Windows.Forms.Label labelComps;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBox_Storehouse;
        private System.Windows.Forms.ComboBox comboBox_Components;
        private System.Windows.Forms.TextBox textBox_Count;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
    }
}