namespace AmazonReviewCrawler
{
    partial class gui
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lbProductCode = new System.Windows.Forms.Label();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.gbReviewCount = new System.Windows.Forms.GroupBox();
            this.txt5star = new System.Windows.Forms.Label();
            this.lb1star = new System.Windows.Forms.Label();
            this.lb2star = new System.Windows.Forms.Label();
            this.lb3star = new System.Windows.Forms.Label();
            this.lb4star = new System.Windows.Forms.Label();
            this.lb5star = new System.Windows.Forms.Label();
            this.txtReviewCount = new System.Windows.Forms.Label();
            this.lbReviewCount = new System.Windows.Forms.Label();
            this.txt4star = new System.Windows.Forms.Label();
            this.txt3star = new System.Windows.Forms.Label();
            this.txt2star = new System.Windows.Forms.Label();
            this.txt1star = new System.Windows.Forms.Label();
            this.gbInput.SuspendLayout();
            this.gbReviewCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbProductCode
            // 
            this.tbProductCode.Location = new System.Drawing.Point(6, 30);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.Size = new System.Drawing.Size(139, 19);
            this.tbProductCode.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(151, 28);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "取得する";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // lbProductCode
            // 
            this.lbProductCode.AutoSize = true;
            this.lbProductCode.Location = new System.Drawing.Point(6, 15);
            this.lbProductCode.Name = "lbProductCode";
            this.lbProductCode.Size = new System.Drawing.Size(139, 12);
            this.lbProductCode.TabIndex = 2;
            this.lbProductCode.Text = "Amazonの商品コードを入力";
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.lbProductCode);
            this.gbInput.Controls.Add(this.btnGetData);
            this.gbInput.Controls.Add(this.tbProductCode);
            this.gbInput.Location = new System.Drawing.Point(3, 3);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(251, 62);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "入力箇所";
            // 
            // gbReviewCount
            // 
            this.gbReviewCount.Controls.Add(this.txt1star);
            this.gbReviewCount.Controls.Add(this.txt2star);
            this.gbReviewCount.Controls.Add(this.txt3star);
            this.gbReviewCount.Controls.Add(this.txt4star);
            this.gbReviewCount.Controls.Add(this.txt5star);
            this.gbReviewCount.Controls.Add(this.lb1star);
            this.gbReviewCount.Controls.Add(this.lb2star);
            this.gbReviewCount.Controls.Add(this.lb3star);
            this.gbReviewCount.Controls.Add(this.lb4star);
            this.gbReviewCount.Controls.Add(this.lb5star);
            this.gbReviewCount.Controls.Add(this.txtReviewCount);
            this.gbReviewCount.Controls.Add(this.lbReviewCount);
            this.gbReviewCount.Location = new System.Drawing.Point(3, 71);
            this.gbReviewCount.Name = "gbReviewCount";
            this.gbReviewCount.Size = new System.Drawing.Size(123, 94);
            this.gbReviewCount.TabIndex = 4;
            this.gbReviewCount.TabStop = false;
            this.gbReviewCount.Text = "レビュー";
            // 
            // txt5star
            // 
            this.txt5star.AutoSize = true;
            this.txt5star.Location = new System.Drawing.Point(74, 27);
            this.txt5star.Name = "txt5star";
            this.txt5star.Size = new System.Drawing.Size(9, 12);
            this.txt5star.TabIndex = 12;
            this.txt5star.Text = "_";
            // 
            // lb1star
            // 
            this.lb1star.AutoSize = true;
            this.lb1star.Location = new System.Drawing.Point(6, 75);
            this.lb1star.Name = "lb1star";
            this.lb1star.Size = new System.Drawing.Size(23, 12);
            this.lb1star.TabIndex = 11;
            this.lb1star.Text = "★1";
            // 
            // lb2star
            // 
            this.lb2star.AutoSize = true;
            this.lb2star.Location = new System.Drawing.Point(6, 63);
            this.lb2star.Name = "lb2star";
            this.lb2star.Size = new System.Drawing.Size(23, 12);
            this.lb2star.TabIndex = 10;
            this.lb2star.Text = "★2";
            // 
            // lb3star
            // 
            this.lb3star.AutoSize = true;
            this.lb3star.Location = new System.Drawing.Point(6, 51);
            this.lb3star.Name = "lb3star";
            this.lb3star.Size = new System.Drawing.Size(23, 12);
            this.lb3star.TabIndex = 9;
            this.lb3star.Text = "★3";
            // 
            // lb4star
            // 
            this.lb4star.AutoSize = true;
            this.lb4star.Location = new System.Drawing.Point(6, 39);
            this.lb4star.Name = "lb4star";
            this.lb4star.Size = new System.Drawing.Size(23, 12);
            this.lb4star.TabIndex = 8;
            this.lb4star.Text = "★4";
            // 
            // lb5star
            // 
            this.lb5star.AutoSize = true;
            this.lb5star.Location = new System.Drawing.Point(6, 27);
            this.lb5star.Name = "lb5star";
            this.lb5star.Size = new System.Drawing.Size(23, 12);
            this.lb5star.TabIndex = 7;
            this.lb5star.Text = "★5";
            // 
            // txtReviewCount
            // 
            this.txtReviewCount.AutoSize = true;
            this.txtReviewCount.Location = new System.Drawing.Point(74, 15);
            this.txtReviewCount.Name = "txtReviewCount";
            this.txtReviewCount.Size = new System.Drawing.Size(9, 12);
            this.txtReviewCount.TabIndex = 6;
            this.txtReviewCount.Text = "_";
            // 
            // lbReviewCount
            // 
            this.lbReviewCount.AutoSize = true;
            this.lbReviewCount.Location = new System.Drawing.Point(6, 15);
            this.lbReviewCount.Name = "lbReviewCount";
            this.lbReviewCount.Size = new System.Drawing.Size(62, 12);
            this.lbReviewCount.TabIndex = 5;
            this.lbReviewCount.Text = "レビューの数";
            // 
            // txt4star
            // 
            this.txt4star.AutoSize = true;
            this.txt4star.Location = new System.Drawing.Point(74, 39);
            this.txt4star.Name = "txt4star";
            this.txt4star.Size = new System.Drawing.Size(9, 12);
            this.txt4star.TabIndex = 13;
            this.txt4star.Text = "_";
            // 
            // txt3star
            // 
            this.txt3star.AutoSize = true;
            this.txt3star.Location = new System.Drawing.Point(74, 51);
            this.txt3star.Name = "txt3star";
            this.txt3star.Size = new System.Drawing.Size(9, 12);
            this.txt3star.TabIndex = 14;
            this.txt3star.Text = "_";
            // 
            // txt2star
            // 
            this.txt2star.AutoSize = true;
            this.txt2star.Location = new System.Drawing.Point(74, 63);
            this.txt2star.Name = "txt2star";
            this.txt2star.Size = new System.Drawing.Size(9, 12);
            this.txt2star.TabIndex = 15;
            this.txt2star.Text = "_";
            // 
            // txt1star
            // 
            this.txt1star.AutoSize = true;
            this.txt1star.Location = new System.Drawing.Point(74, 75);
            this.txt1star.Name = "txt1star";
            this.txt1star.Size = new System.Drawing.Size(9, 12);
            this.txt1star.TabIndex = 16;
            this.txt1star.Text = "_";
            // 
            // gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReviewCount);
            this.Controls.Add(this.gbInput);
            this.Name = "gui";
            this.Size = new System.Drawing.Size(800, 450);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbReviewCount.ResumeLayout(false);
            this.gbReviewCount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lbProductCode;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbReviewCount;
        private System.Windows.Forms.Label lb5star;
        private System.Windows.Forms.Label txtReviewCount;
        private System.Windows.Forms.Label lbReviewCount;
        private System.Windows.Forms.Label txt5star;
        private System.Windows.Forms.Label lb1star;
        private System.Windows.Forms.Label lb2star;
        private System.Windows.Forms.Label lb3star;
        private System.Windows.Forms.Label lb4star;
        private System.Windows.Forms.Label txt1star;
        private System.Windows.Forms.Label txt2star;
        private System.Windows.Forms.Label txt3star;
        private System.Windows.Forms.Label txt4star;
    }
}
