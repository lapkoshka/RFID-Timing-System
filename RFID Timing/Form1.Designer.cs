using System;

namespace RFID_Timing
{
    partial class Form1
    {

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.regTitle = new System.Windows.Forms.Label();
            this.confTitle = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.matchTime = new System.Windows.Forms.Label();
            this.raceCount = new System.Windows.Forms.Label();
            this.regButton = new System.Windows.Forms.Button();
            this.mainInfoBox = new System.Windows.Forms.GroupBox();
            this.matchName = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.addLaps = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addInfo = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.mainInfoBox.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(15, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(669, 461);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.classname,
            this.tag});
            this.dataGridView1.Location = new System.Drawing.Point(20, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(584, 418);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(15, 522);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1037, 32);
            this.panel3.TabIndex = 2;
            // 
            // regTitle
            // 
            this.regTitle.AutoSize = true;
            this.regTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.regTitle.Location = new System.Drawing.Point(39, 14);
            this.regTitle.Name = "regTitle";
            this.regTitle.Size = new System.Drawing.Size(53, 26);
            this.regTitle.TabIndex = 3;
            this.regTitle.Text = "Text";
            // 
            // confTitle
            // 
            this.confTitle.AutoSize = true;
            this.confTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.confTitle.Location = new System.Drawing.Point(726, 13);
            this.confTitle.Name = "confTitle";
            this.confTitle.Size = new System.Drawing.Size(53, 26);
            this.confTitle.TabIndex = 4;
            this.confTitle.Text = "Text";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(20, 272);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(303, 112);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // matchTime
            // 
            this.matchTime.AutoSize = true;
            this.matchTime.Location = new System.Drawing.Point(25, 151);
            this.matchTime.Name = "matchTime";
            this.matchTime.Size = new System.Drawing.Size(35, 13);
            this.matchTime.TabIndex = 5;
            this.matchTime.Text = "label5";
            // 
            // raceCount
            // 
            this.raceCount.AutoSize = true;
            this.raceCount.Location = new System.Drawing.Point(26, 178);
            this.raceCount.Name = "raceCount";
            this.raceCount.Size = new System.Drawing.Size(35, 13);
            this.raceCount.TabIndex = 7;
            this.raceCount.Text = "label6";
            // 
            // regButton
            // 
            this.regButton.Location = new System.Drawing.Point(81, 398);
            this.regButton.Name = "regButton";
            this.regButton.Size = new System.Drawing.Size(179, 39);
            this.regButton.TabIndex = 9;
            this.regButton.Text = "button1";
            this.regButton.UseVisualStyleBackColor = true;
            // 
            // mainInfoBox
            // 
            this.mainInfoBox.Controls.Add(this.richTextBox2);
            this.mainInfoBox.Controls.Add(this.matchName);
            this.mainInfoBox.Controls.Add(this.dateTimePicker1);
            this.mainInfoBox.Location = new System.Drawing.Point(20, 12);
            this.mainInfoBox.Name = "mainInfoBox";
            this.mainInfoBox.Size = new System.Drawing.Size(303, 117);
            this.mainInfoBox.TabIndex = 10;
            this.mainInfoBox.TabStop = false;
            this.mainInfoBox.Text = "mainInfoBox";
            // 
            // matchName
            // 
            this.matchName.AutoSize = true;
            this.matchName.Location = new System.Drawing.Point(13, 23);
            this.matchName.Name = "matchName";
            this.matchName.Size = new System.Drawing.Size(35, 13);
            this.matchName.TabIndex = 0;
            this.matchName.Text = "label3";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(17, 79);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(138, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // addLaps
            // 
            this.addLaps.AutoSize = true;
            this.addLaps.Location = new System.Drawing.Point(26, 205);
            this.addLaps.Name = "addLaps";
            this.addLaps.Size = new System.Drawing.Size(35, 13);
            this.addLaps.TabIndex = 11;
            this.addLaps.Text = "label7";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.comboBox3);
            this.panel2.Controls.Add(this.comboBox2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.addInfo);
            this.panel2.Controls.Add(this.addLaps);
            this.panel2.Controls.Add(this.mainInfoBox);
            this.panel2.Controls.Add(this.regButton);
            this.panel2.Controls.Add(this.raceCount);
            this.panel2.Controls.Add(this.matchTime);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(702, 44);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(350, 461);
            this.panel2.TabIndex = 1;
            // 
            // addInfo
            // 
            this.addInfo.AutoSize = true;
            this.addInfo.Location = new System.Drawing.Point(26, 254);
            this.addInfo.Name = "addInfo";
            this.addInfo.Size = new System.Drawing.Size(35, 13);
            this.addInfo.TabIndex = 12;
            this.addInfo.Text = "label1";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(15, 42);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(272, 24);
            this.richTextBox2.TabIndex = 2;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // id
            // 
            this.id.HeaderText = "ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // name
            // 
            this.name.HeaderText = "name";
            this.name.Name = "name";
            this.name.Width = 200;
            // 
            // classname
            // 
            this.classname.HeaderText = "Class";
            this.classname.Name = "classname";
            // 
            // tag
            // 
            this.tag.HeaderText = "EPC Tag";
            this.tag.Name = "tag";
            this.tag.ReadOnly = true;
            this.tag.Width = 200;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "10:00",
            "15:00",
            "20:00",
            "25:00"});
            this.comboBox1.Location = new System.Drawing.Point(196, 151);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 21);
            this.comboBox1.TabIndex = 13;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(196, 178);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(127, 21);
            this.comboBox2.TabIndex = 14;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(196, 205);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(127, 21);
            this.comboBox3.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 562);
            this.Controls.Add(this.confTitle);
            this.Controls.Add(this.regTitle);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.mainInfoBox.ResumeLayout(false);
            this.mainInfoBox.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label regTitle;
        private System.Windows.Forms.Label confTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label matchTime;
        private System.Windows.Forms.Label raceCount;
        private System.Windows.Forms.Button regButton;
        private System.Windows.Forms.GroupBox mainInfoBox;
        private System.Windows.Forms.Label matchName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label addLaps;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label addInfo;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn classname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tag;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

