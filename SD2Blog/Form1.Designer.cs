namespace SD2Blog
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.labelOut = new System.Windows.Forms.Label();
            this.textBoxOut = new System.Windows.Forms.TextBox();
            this.labelRight = new System.Windows.Forms.Label();
            this.labelIn = new System.Windows.Forms.Label();
            this.textBoxIn = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxTemplate = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonSaveDictionary = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.japaneseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.englishName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbTemplateList = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(436, 357);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonConvert);
            this.tabPage1.Controls.Add(this.labelOut);
            this.tabPage1.Controls.Add(this.textBoxOut);
            this.tabPage1.Controls.Add(this.labelRight);
            this.tabPage1.Controls.Add(this.labelIn);
            this.tabPage1.Controls.Add(this.textBoxIn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(428, 331);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "変換";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Location = new System.Drawing.Point(347, 302);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(75, 23);
            this.buttonConvert.TabIndex = 5;
            this.buttonConvert.Text = "変換";
            this.buttonConvert.UseVisualStyleBackColor = true;
            this.buttonConvert.Click += new System.EventHandler(this.buttonConvert_Click);
            // 
            // labelOut
            // 
            this.labelOut.AutoSize = true;
            this.labelOut.Location = new System.Drawing.Point(228, 7);
            this.labelOut.Name = "labelOut";
            this.labelOut.Size = new System.Drawing.Size(33, 12);
            this.labelOut.TabIndex = 4;
            this.labelOut.Text = "【out】";
            // 
            // textBoxOut
            // 
            this.textBoxOut.Location = new System.Drawing.Point(230, 22);
            this.textBoxOut.Multiline = true;
            this.textBoxOut.Name = "textBoxOut";
            this.textBoxOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxOut.Size = new System.Drawing.Size(192, 274);
            this.textBoxOut.TabIndex = 3;
            this.textBoxOut.WordWrap = false;
            this.textBoxOut.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxOut_KeyDown);
            // 
            // labelRight
            // 
            this.labelRight.AutoSize = true;
            this.labelRight.Location = new System.Drawing.Point(207, 134);
            this.labelRight.Name = "labelRight";
            this.labelRight.Size = new System.Drawing.Size(17, 12);
            this.labelRight.TabIndex = 2;
            this.labelRight.Text = "→";
            // 
            // labelIn
            // 
            this.labelIn.AutoSize = true;
            this.labelIn.Location = new System.Drawing.Point(5, 7);
            this.labelIn.Name = "labelIn";
            this.labelIn.Size = new System.Drawing.Size(26, 12);
            this.labelIn.TabIndex = 1;
            this.labelIn.Text = "【in】";
            // 
            // textBoxIn
            // 
            this.textBoxIn.Location = new System.Drawing.Point(7, 22);
            this.textBoxIn.Multiline = true;
            this.textBoxIn.Name = "textBoxIn";
            this.textBoxIn.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxIn.Size = new System.Drawing.Size(194, 274);
            this.textBoxIn.TabIndex = 0;
            this.textBoxIn.WordWrap = false;
            this.textBoxIn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxIn_KeyDown);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cmbTemplateList);
            this.tabPage2.Controls.Add(this.buttonSave);
            this.tabPage2.Controls.Add(this.textBoxTemplate);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(428, 331);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "テンプレート";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(347, 302);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "保存";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxTemplate
            // 
            this.textBoxTemplate.Location = new System.Drawing.Point(7, 33);
            this.textBoxTemplate.Multiline = true;
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTemplate.Size = new System.Drawing.Size(415, 263);
            this.textBoxTemplate.TabIndex = 0;
            this.textBoxTemplate.WordWrap = false;
            this.textBoxTemplate.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTemplate_KeyDown);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonSaveDictionary);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(428, 331);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "辞書";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonSaveDictionary
            // 
            this.buttonSaveDictionary.Location = new System.Drawing.Point(346, 302);
            this.buttonSaveDictionary.Name = "buttonSaveDictionary";
            this.buttonSaveDictionary.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveDictionary.TabIndex = 1;
            this.buttonSaveDictionary.Text = "保存";
            this.buttonSaveDictionary.UseVisualStyleBackColor = true;
            this.buttonSaveDictionary.Click += new System.EventHandler(this.buttonSaveDictionary_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.key,
            this.japaneseName,
            this.englishName});
            this.dataGridView1.Location = new System.Drawing.Point(7, 7);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(415, 289);
            this.dataGridView1.TabIndex = 0;
            // 
            // key
            // 
            this.key.HeaderText = "Key";
            this.key.Name = "key";
            this.key.ReadOnly = true;
            // 
            // japaneseName
            // 
            this.japaneseName.HeaderText = "和名";
            this.japaneseName.Name = "japaneseName";
            // 
            // englishName
            // 
            this.englishName.HeaderText = "英名";
            this.englishName.Name = "englishName";
            // 
            // cmbTemplateList
            // 
            this.cmbTemplateList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplateList.FormattingEnabled = true;
            this.cmbTemplateList.Location = new System.Drawing.Point(7, 7);
            this.cmbTemplateList.Name = "cmbTemplateList";
            this.cmbTemplateList.Size = new System.Drawing.Size(121, 20);
            this.cmbTemplateList.TabIndex = 2;
            this.cmbTemplateList.SelectedIndexChanged += new System.EventHandler(this.cmbTemplateList_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(461, 382);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SD2Blog";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label labelIn;
        private System.Windows.Forms.TextBox textBoxIn;
        private System.Windows.Forms.Label labelRight;
        private System.Windows.Forms.Label labelOut;
        private System.Windows.Forms.TextBox textBoxOut;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.TextBox textBoxTemplate;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSaveDictionary;
        private System.Windows.Forms.DataGridViewTextBoxColumn key;
        private System.Windows.Forms.DataGridViewTextBoxColumn japaneseName;
        private System.Windows.Forms.DataGridViewTextBoxColumn englishName;
        private System.Windows.Forms.ComboBox cmbTemplateList;
    }
}

