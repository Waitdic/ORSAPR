
namespace TablePlugin.Forms
{
    partial class TableForm
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
            this.BuildButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkHole = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tableTopHeight = new System.Windows.Forms.NumericUpDown();
            this.tableTopWidth = new System.Windows.Forms.NumericUpDown();
            this.tableTopLength = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LegsTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.tableLegsNumber = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.SizeValue = new System.Windows.Forms.NumericUpDown();
            this.tableLegsHeight = new System.Windows.Forms.NumericUpDown();
            this.NameOfSize = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SetMinButton = new System.Windows.Forms.Button();
            this.SetMaxButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DefaultButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.holeRadius = new System.Windows.Forms.NumericUpDown();
            this.holeParamY = new System.Windows.Forms.NumericUpDown();
            this.holeParamX = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopLength)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsHeight)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holeRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamX)).BeginInit();
            this.SuspendLayout();
            // 
            // BuildButton
            // 
            this.BuildButton.Location = new System.Drawing.Point(182, 377);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(150, 49);
            this.BuildButton.TabIndex = 0;
            this.BuildButton.Text = "Построить 3D модель";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Длина";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ширина";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(331, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Высота";
            // 
            // checkHole
            // 
            this.checkHole.AutoSize = true;
            this.checkHole.Location = new System.Drawing.Point(11, 74);
            this.checkHole.Name = "checkHole";
            this.checkHole.Size = new System.Drawing.Size(130, 17);
            this.checkHole.TabIndex = 11;
            this.checkHole.Text = "Сквозное отверстие";
            this.checkHole.UseVisualStyleBackColor = true;
            this.checkHole.CheckedChanged += new System.EventHandler(this.CheckHole_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tableTopHeight);
            this.groupBox1.Controls.Add(this.tableTopWidth);
            this.groupBox1.Controls.Add(this.tableTopLength);
            this.groupBox1.Controls.Add(this.checkHole);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 110);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Столешница";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(403, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 13);
            this.label13.TabIndex = 19;
            this.label13.Text = "30-40 мм";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(247, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "600-800 мм";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(82, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "1000-2000 мм";
            // 
            // tableTopHeight
            // 
            this.tableTopHeight.Location = new System.Drawing.Point(333, 38);
            this.tableTopHeight.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.tableTopHeight.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.tableTopHeight.Name = "tableTopHeight";
            this.tableTopHeight.Size = new System.Drawing.Size(64, 20);
            this.tableTopHeight.TabIndex = 14;
            this.tableTopHeight.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // tableTopWidth
            // 
            this.tableTopWidth.Location = new System.Drawing.Point(177, 40);
            this.tableTopWidth.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.tableTopWidth.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.tableTopWidth.Name = "tableTopWidth";
            this.tableTopWidth.Size = new System.Drawing.Size(64, 20);
            this.tableTopWidth.TabIndex = 13;
            this.tableTopWidth.Value = new decimal(new int[] {
            700,
            0,
            0,
            0});
            // 
            // tableTopLength
            // 
            this.tableTopLength.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tableTopLength.Location = new System.Drawing.Point(13, 40);
            this.tableTopLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tableTopLength.Name = "tableTopLength";
            this.tableTopLength.Size = new System.Drawing.Size(63, 20);
            this.tableTopLength.TabIndex = 12;
            this.tableTopLength.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LegsTypeComboBox);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tableLegsNumber);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.SizeValue);
            this.groupBox2.Controls.Add(this.tableLegsHeight);
            this.groupBox2.Controls.Add(this.NameOfSize);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(11, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 142);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ножки";
            // 
            // LegsTypeComboBox
            // 
            this.LegsTypeComboBox.FormattingEnabled = true;
            this.LegsTypeComboBox.Items.AddRange(new object[] {
            "Круглые",
            "Квадратные"});
            this.LegsTypeComboBox.Location = new System.Drawing.Point(12, 103);
            this.LegsTypeComboBox.Name = "LegsTypeComboBox";
            this.LegsTypeComboBox.Size = new System.Drawing.Size(87, 21);
            this.LegsTypeComboBox.TabIndex = 23;
            this.LegsTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.LegsTypeComboBox_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DimGray;
            this.label18.Location = new System.Drawing.Point(265, 104);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(53, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "40-60 мм";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DimGray;
            this.label17.Location = new System.Drawing.Point(265, 41);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 13);
            this.label17.TabIndex = 21;
            this.label17.Text = "4-5 шт.";
            // 
            // tableLegsNumber
            // 
            this.tableLegsNumber.Location = new System.Drawing.Point(179, 39);
            this.tableLegsNumber.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tableLegsNumber.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.tableLegsNumber.Name = "tableLegsNumber";
            this.tableLegsNumber.Size = new System.Drawing.Size(80, 20);
            this.tableLegsNumber.TabIndex = 20;
            this.tableLegsNumber.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(105, 41);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "600-700 мм";
            // 
            // SizeValue
            // 
            this.SizeValue.Location = new System.Drawing.Point(179, 102);
            this.SizeValue.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.SizeValue.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.SizeValue.Name = "SizeValue";
            this.SizeValue.Size = new System.Drawing.Size(80, 20);
            this.SizeValue.TabIndex = 16;
            this.SizeValue.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // tableLegsHeight
            // 
            this.tableLegsHeight.Location = new System.Drawing.Point(12, 37);
            this.tableLegsHeight.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.tableLegsHeight.Minimum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.tableLegsHeight.Name = "tableLegsHeight";
            this.tableLegsHeight.Size = new System.Drawing.Size(87, 20);
            this.tableLegsHeight.TabIndex = 14;
            this.tableLegsHeight.Value = new decimal(new int[] {
            650,
            0,
            0,
            0});
            // 
            // NameOfSize
            // 
            this.NameOfSize.AutoSize = true;
            this.NameOfSize.Location = new System.Drawing.Point(176, 86);
            this.NameOfSize.Name = "NameOfSize";
            this.NameOfSize.Size = new System.Drawing.Size(110, 13);
            this.NameOfSize.TabIndex = 11;
            this.NameOfSize.Text = "Диаметр основания";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Тип ножек";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(176, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Количество ножек";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Длина ножек";
            // 
            // SetMinButton
            // 
            this.SetMinButton.Location = new System.Drawing.Point(11, 61);
            this.SetMinButton.Name = "SetMinButton";
            this.SetMinButton.Size = new System.Drawing.Size(134, 32);
            this.SetMinButton.TabIndex = 14;
            this.SetMinButton.Text = "Минимумы";
            this.SetMinButton.UseVisualStyleBackColor = true;
            this.SetMinButton.Click += new System.EventHandler(this.SetMinButton_Click);
            // 
            // SetMaxButton
            // 
            this.SetMaxButton.Location = new System.Drawing.Point(11, 102);
            this.SetMaxButton.Name = "SetMaxButton";
            this.SetMaxButton.Size = new System.Drawing.Size(134, 32);
            this.SetMaxButton.TabIndex = 15;
            this.SetMaxButton.Text = "Максимумы";
            this.SetMaxButton.UseVisualStyleBackColor = true;
            this.SetMaxButton.Click += new System.EventHandler(this.SetMaxButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DefaultButton);
            this.groupBox4.Controls.Add(this.SetMinButton);
            this.groupBox4.Controls.Add(this.SetMaxButton);
            this.groupBox4.Location = new System.Drawing.Point(346, 223);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(157, 142);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Параметры по умолчанию";
            // 
            // DefaultButton
            // 
            this.DefaultButton.Location = new System.Drawing.Point(11, 20);
            this.DefaultButton.Name = "DefaultButton";
            this.DefaultButton.Size = new System.Drawing.Size(134, 32);
            this.DefaultButton.TabIndex = 16;
            this.DefaultButton.Text = "По умолчанию";
            this.DefaultButton.UseVisualStyleBackColor = true;
            this.DefaultButton.Click += new System.EventHandler(this.DefaultButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.holeRadius);
            this.groupBox3.Controls.Add(this.holeParamY);
            this.groupBox3.Controls.Add(this.holeParamX);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Location = new System.Drawing.Point(11, 134);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(491, 79);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Отверстие";
            this.groupBox3.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(403, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "20-30 мм";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(247, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "90-700 мм";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(82, 44);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "120-1870 мм";
            // 
            // holeRadius
            // 
            this.holeRadius.Location = new System.Drawing.Point(333, 38);
            this.holeRadius.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.holeRadius.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.holeRadius.Name = "holeRadius";
            this.holeRadius.Size = new System.Drawing.Size(64, 20);
            this.holeRadius.TabIndex = 14;
            this.holeRadius.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // holeParamY
            // 
            this.holeParamY.Location = new System.Drawing.Point(177, 40);
            this.holeParamY.Maximum = new decimal(new int[] {
            700,
            0,
            0,
            0});
            this.holeParamY.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.holeParamY.Name = "holeParamY";
            this.holeParamY.Size = new System.Drawing.Size(64, 20);
            this.holeParamY.TabIndex = 13;
            this.holeParamY.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // holeParamX
            // 
            this.holeParamX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.holeParamX.Location = new System.Drawing.Point(13, 40);
            this.holeParamX.Maximum = new decimal(new int[] {
            1870,
            0,
            0,
            0});
            this.holeParamX.Minimum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.holeParamX.Name = "holeParamX";
            this.holeParamX.Size = new System.Drawing.Size(63, 20);
            this.holeParamX.TabIndex = 12;
            this.holeParamX.Value = new decimal(new int[] {
            900,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(331, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Радиус отверстия";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(175, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(123, 13);
            this.label15.TabIndex = 4;
            this.label15.Text = "Расстояние по ширине";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(9, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "Расстояние по длине";
            // 
            // TableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 434);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BuildButton);
            this.Name = "TableForm";
            this.Text = "TablePlugin";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableTopLength)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SizeValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableLegsHeight)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.holeRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.holeParamX)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkHole;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label NameOfSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown tableTopHeight;
        private System.Windows.Forms.NumericUpDown tableTopWidth;
        private System.Windows.Forms.NumericUpDown tableTopLength;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown tableLegsNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown SizeValue;
        private System.Windows.Forms.NumericUpDown tableLegsHeight;
        private System.Windows.Forms.Button SetMinButton;
        private System.Windows.Forms.Button SetMaxButton;
        private System.Windows.Forms.ComboBox LegsTypeComboBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button DefaultButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown holeRadius;
        private System.Windows.Forms.NumericUpDown holeParamY;
        private System.Windows.Forms.NumericUpDown holeParamX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
    }
}

